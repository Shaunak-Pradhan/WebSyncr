using DevPortal.Services.Implementation;
using DevPortal.Services.Interface;
using System;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;

namespace DevPortal.FrontEnd
{
    public partial class Login : System.Web.UI.Page
    {
        readonly ISQLService sQLService = new SQLService();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;


            //SqlConnectionObj().Open();

            string query = "SELECT Password FROM Users WHERE Login = @Username";
            using (SqlCommand command = new SqlCommand(query, (SqlConnection)SqlConnectionObj()))
            {
                command.Parameters.AddWithValue("@Username", username);

                // Execute the query and retrieve the hashed password from the database
                object result = command.ExecuteScalar();

                if (result != null && result != DBNull.Value)
                {
                    string hashedPasswordFromDB = result.ToString();

                    // Compare the hashed password from the database with the user's input
                    bool isPasswordValid = password == hashedPasswordFromDB ? true : false;//VerifyPassword(password, hashedPasswordFromDB);

                    if (isPasswordValid)
                    {
                        // Valid credentials, perform further actions
                        Response.Redirect("DevPortal.aspx");
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "myFunction", "updateErrorMessage('Invalid password.');", true);
                    }
                }
                
                else
                {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "myFunction", "updateErrorMessage('User not found.');", true);
                }
            }

        }

        private bool VerifyPassword(string password, string hashedPassword)
        {
            // Implement your password verification logic here
            // This can involve hashing the user input and comparing it with the hashed password from the database

            // Example using System.Security.Cryptography.SHA256
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < hashedBytes.Length; i++)
                {
                    builder.Append(hashedBytes[i].ToString("x2"));
                }

                string hashedPasswordInput = builder.ToString();

                return (hashedPasswordInput == hashedPassword);
            }
        }

        protected object SqlConnectionObj()
        {
            WebForm1 DevPortal = new WebForm1();
            return sQLService.SqlConnectionObj();
        }

    }
}