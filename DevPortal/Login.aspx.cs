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
        readonly IAuthService loginService = new AuthService();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (loginService.IsValidUser(txtUsername.Text, txtPassword.Text))
            {
                System.Web.Security.FormsAuthentication.SetAuthCookie(txtUsername.Text, false);
                Response.Redirect("~/Dashboard.aspx");
            }
        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            string query = "SELECT Password FROM Users WHERE Login = @Username";
            using (SqlCommand command = new SqlCommand(query, (SqlConnection)sQLService.SqlConnectionObj()))
            {
                command.Parameters.AddWithValue("@Username", username);
                object result = command.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                {
                    if (loginService.IsValidUser(txtUsername.Text, txtPassword.Text))
                    {
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
    }
}