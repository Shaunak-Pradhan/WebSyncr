using DevPortal.Services.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web.Security;
namespace DevPortal.Services.Implementation
{
    public class AuthService : IAuthService
    {
        readonly ISQLService sQLService = new SQLService();
        public bool IsValidUser(string username, string password)
        {
            return ValidateCredential(username, password);
        }
        private void SetCookie(string username)
        {
            FormsAuthentication.SetAuthCookie(username, true);
        }
        private bool ValidateCredential(string username, string password)
        {
            if (username != "")
            {
                string query = $@"SELECT Password FROM Users WHERE Login = '{username}'";
                using (SqlCommand command = new SqlCommand(query, (SqlConnection)sQLService.SqlConnectionObj()))
                {
                    command.Parameters.AddWithValue("@Username", username);
                    object result = command.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        bool isPasswordValid = ValidateHash(password);
                        if (isPasswordValid)
                        {
                            SetCookie(username);
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
            return false;
        }
        private bool ValidateHash(string inputPassword)
        {
            string query = $@"SELECT HashedPassword FROM Users WHERE Password = '{inputPassword}'";
            using (SqlCommand command = new SqlCommand(query, (SqlConnection)sQLService.SqlConnectionObj()))
            {
                string hashedPasswordFromDB;
                command.Parameters.AddWithValue("@HashedPassword", inputPassword);
                object result = command.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                {
                    hashedPasswordFromDB = result.ToString();
                    bool isPasswordValid = string.Equals(hashedPasswordFromDB, ConvertToSHA256(inputPassword));
                    return isPasswordValid;
                }
                return false;
            }
        }
        private string ConvertToSHA256(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
        }
    }
}