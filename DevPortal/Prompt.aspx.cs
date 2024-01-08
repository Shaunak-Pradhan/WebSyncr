using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;
using System.IO;
using System.Net;
using DevPortal.Services.Interface;
using DevPortal.Services.Implementation;
using DevPortal.Services;
namespace DevPortal.FrontEnd
{
    public partial class Prompt : System.Web.UI.Page
    {
        IPrompterService _prompterService = new PrompterService();
        IWriteFileService writeFileService = new WriteFileService();
        ICreateFileService createFileService = new CreateFileService();
        ISQLService sQLService = new SQLService();
        readonly IAuthService authService = new AuthService();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (authService.EnableAuth())
            {
                if (!User.Identity.IsAuthenticated)
                {
                    Response.Redirect("~/Login.aspx");
                }
            }
        }
        protected async void SubmitButton(object sender, EventArgs e)
        {
            var guid = Convert.ToInt32(Guid.NewGuid().ToString("N").Substring(0, 4), 16);
            string html = await _prompterService.GetHtmlAsync(prompt.Text);
            _prompterService.Compiler(html);
            createFileService.CreateEmptyHTMLPage($"Page{guid}", "");
            writeFileService.WriteFile($"Page{guid}", html);
            sQLService.InsertToPages(guid, $"Page{guid}.html", "Page");
            // await ChatGPT(prompt.Text);
        }
        protected async void SubmitHTMLButton(object sender, EventArgs e)
        {
        }
    }
}