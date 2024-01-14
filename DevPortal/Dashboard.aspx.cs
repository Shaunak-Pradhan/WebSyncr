using DevPortal.Services;
using DevPortal.Services.Implementation;
using DevPortal.Services.Interface;
using HtmlAgilityPack;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Runtime.Remoting.Contexts;
using System.Security.AccessControl;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace DevPortal.FrontEnd
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        private DataTable dataTable = new DataTable();
        readonly IGridViewService gridViewService = new GridViewService();
        readonly ICreateFileService createFileService = new CreateFileService();
        readonly ITemplateService templateService = new TemplateService();
        readonly IWriteFileService writeFileService = new WriteFileService();
        readonly ISQLService sQLService = new SQLService();
        readonly IAuthService authService = new AuthService();
        readonly IWebHostService webHostService = new WebHostService(); 
        protected void Page_Load(object sender, EventArgs e)
        {
            if(authService.EnableAuth()){
                if (!User.Identity.IsAuthenticated)
                {
                    Response.Redirect("~/Login.aspx");
                }
            }
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;

            Console.WriteLine("Project Directory: " + baseDirectory);
        }
        protected void Generate(object sender, EventArgs e)
        {
            var DisplayName = TextBox1.Text;
            var Page_ext = writeFileService.RequestType(Int32.Parse(ddlType.SelectedValue));
            string folderPath = webHostService.Directory();
            var Table = "Pages";
            var Index = 0;
            SqlCommand sqlcmd3 = new SqlCommand("select Count(PID) as count from " + Table, sQLService.SqlConnectionObj());
            var IndexObj = sqlcmd3.ExecuteReader();
            if (IndexObj.Read())
            {
                var temp = IndexObj["count"];
                Index = int.Parse(string.Format("{0}", temp));
                Index++;
            }
            var filename = "";
            if (Page_ext == ".js") filename = "Logic";
            else if (Page_ext == ".html") filename = "Page";
            else filename = "Design";
            string pathName = webHostService.Directory(null,"Pages") + filename + Index + Page_ext;
            string Filename = filename + Index + Page_ext;
            //createFileService.CreateFile(Filename, folderPath, Page_ext);
            createFileService.CreateEmptyHTMLPage(filename + Index, "test");
            //templateService.BindTemplate(1, filename + Index, DisplayName, Page_ext);
            if (Page_ext == ".js")
            {
                folderPath = webHostService.Directory(null,"Logic");
                sQLService.InsertToLogic(Index, Filename, DisplayName);
            }
            else if (Page_ext == ".html")
            {
                folderPath = webHostService.Directory(null, "Pages");
                sQLService.InsertToPages(Index, Filename, DisplayName);
            }
            else
            {
                folderPath = webHostService.Directory(null, "Design");
                sQLService.InsertToDesign(Index, Filename, DisplayName);
            }
            gridViewService.GridViewForTable(Table, GridView);
        }
        protected void DeleteButton(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "DoAction")
            {
                string id = e.CommandArgument.ToString();
                var Page_ext = writeFileService.RequestType(Int32.Parse(ddlType.SelectedValue));
                if (Page_ext == ".html")
                {
                    writeFileService.DeleteFile("Page" + id);
                }
                else if (Page_ext == ".js")
                {
                    writeFileService.DeleteFile("Logic" + id);
                }
                else
                {
                    writeFileService.DeleteFile("Design" + id);
                }
                sQLService.DeletePage(id);
                gridViewService.GridViewForTable("Pages", GridView);
            }
        }

        protected void ddlName_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddlName = (DropDownList)sender;
            GridViewRow row = (GridViewRow)ddlName.NamingContainer;
            int rowIndex = row.RowIndex;
            GridViewRow row2 = GridView.Rows[rowIndex];
            string PID = row2.Cells[0].Text;
            string selectedValue = ddlName.SelectedValue;
            ListItem TemplateName = ddlName.Items.FindByValue(selectedValue);
            templateService.SwitchTemplate(selectedValue, PID, TemplateName.Text, GridView);
        }
        protected void ShowGridView(object sender, EventArgs e)
        {
            gridViewService.GridViewForTable("Pages", GridView);
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            //var tb1 = Int32.Parse(TextBox1.Text);
            //var tb2 = TextBox2.Text;
            var tb1 = TextBox1.Text;
            //GeneratePage(tb1, tb2);
        }
        [WebMethod]
        public static string GetBaseDirectory()
        {
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            return baseDirectory;
        }
        [WebMethod]
        public static string AccessCheck()
        {
            try
            {
                string directoryPath = @"h:\root\home\shaunakpradhan-001\www\websyncr\publish";
                if (!System.IO.Directory.Exists(directoryPath))
                {
                    return "Directory not detected";
                }
                else
                {
                    DirectorySecurity directorySecurity = System.IO.Directory.GetAccessControl(directoryPath);
                    string userAccount = "shaunakpradhan-001";

                    // Define the type of access control to grant (e.g., FileSystemRights.Read, FileSystemRights.Write).
                    FileSystemRights accessRights = FileSystemRights.FullControl;

                    // Define the access control type (e.g., Allow or Deny).
                    AccessControlType controlType = AccessControlType.Allow;

                    // Add a new FileSystemAccessRule with the specified parameters.
                    FileSystemAccessRule accessRule = new FileSystemAccessRule(userAccount, accessRights, controlType);
                    directorySecurity.AddAccessRule(accessRule);

                    // Apply the modified security settings to the directory.
                    System.IO.Directory.SetAccessControl(directoryPath, directorySecurity);

                    return "Permissions granted successfully.";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return ex.Message;
            }
        }
        /* Main Functions End */
        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {
        }
        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {
        }
    }
}