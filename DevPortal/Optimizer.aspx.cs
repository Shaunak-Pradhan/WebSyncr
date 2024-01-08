using DevPortal.Services.Implementation;
using DevPortal.Services.Interface;
using HtmlAgilityPack;
using NUglify;
using NUglify.Html;
using OpenAI_API.Moderation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
namespace DevPortal.FrontEnd
{
    public partial class Optimizer : System.Web.UI.Page
    {
        WebForm1 DevPortal = new WebForm1();
        UtilityService utilityService = new UtilityService();
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
        protected void Button1_Click(object sender, EventArgs e)
        {
            GridViewCall("Pages");
            //string folderpath = BackEnd.Repository.JsFolderOld("Sample.js");
            //string minifiedjs = MinifyJs(folderpath);
        }
        protected void OptimizeBtn(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "DoAction")
            {
                string TemplateName = e.CommandArgument.ToString();
                if (TemplateName != "")
                {
                    //OptimizeFeatures(2, TemplateName, "Sample.js");
                    FormatHtml("Page1");
                    MinifyJs("Sample.js");
                    string script = "alert('File is Minfied');";
                    ClientScript.RegisterStartupScript(this.GetType(), "Alert", script, true);
                }
                else
                {
                    string script = "alert('Page Design Is Missing!');";
                    ClientScript.RegisterStartupScript(this.GetType(), "Alert", script, true);
                }
            }
        }
        protected void OptimizeFeatures(int FeatureID, string TemplateName, string filename)
        {
            int HTML = 1;
            int JS = 2;
            int CSS = 3;
            if (FeatureID is 2)
            {
                MinifyJs(utilityService.JsFolderOld(TemplateName) + filename);
                //DevPortal.RewriteFile(filename, minifiedjs);
            }
        }
        protected void MinifyJs(string filename)
        {
            string filePath = utilityService.JsFolderOld(filename);
            string fileContents;
            StringBuilder sb = new StringBuilder();
            using (StreamReader sr = new StreamReader(filePath))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                    sb.AppendLine(line);
                }
            } 
            fileContents = sb.ToString();
            var minifier = Uglify.Js(fileContents);
            string outputFilePath = Path.Combine(Path.GetDirectoryName(filePath), Path.GetFileNameWithoutExtension(filename) + ".min.js");
            File.WriteAllText(outputFilePath, minifier.Code);
        }
        public void FormatHtml(string filename)
        {
            string filePath = utilityService.PagesFolder(filename);
            string html = File.ReadAllText(filePath);
            var doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(html);
            // Set the indentation settings
            doc.OptionOutputAsXml = true;
            doc.OptionWriteEmptyNodes = true;
            using (var writer = new StreamWriter(filePath, false)) 
            {
                doc.Save(writer);
            }
        }
        public void GridViewCall(string Table)
        {
            using (SqlConnection sqlconn = sQLService.SqlConnectionObj())
            {
                try
                {
                    SqlCommand sqlcmd = new SqlCommand("select * from " + Table, sqlconn);
                    SqlDataAdapter sda = new SqlDataAdapter();
                    sda.SelectCommand = sqlcmd;
                    DataSet ds = new DataSet();
                    sda.Fill(ds, "table1");
                    DataTable dataTable = ds.Tables["table1"];
                    GridView.DataSource = ds;
                    GridView.DataBind();
                    if (GridView.Rows.Count > 0)
                    {
                        GridView.Visible = true;
                        GridView.Rows[0].Cells[0].Visible = true;
                    }
                    else
                    {
                        GridView.Visible = false;
                    }
                }
                catch (Exception ex)
                {
                    // Handle the exception appropriately, e.g., log it or display an error message.
                    throw new Exception(ex.ToString());
                }
            }
        }
        protected object DevPortalObj()
        {
            WebForm1 DevPortal = new WebForm1();
            return DevPortal;
        }
    }
}