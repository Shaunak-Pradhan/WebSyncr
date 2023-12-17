using DevPortal.Services;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace DevPortal.FrontEnd
{
    public partial class CMS1 : System.Web.UI.Page
    {
        protected readonly IGridViewService gridViewService = new GridViewService();
        protected readonly IReadFileService readFileService = new ReadFileService();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!User.Identity.IsAuthenticated)
            {
                Response.Redirect("~/FrontEnd/Login.aspx");
            }
        }
        protected void ReadFromFile(string filename)
        {
            string Heading = readFileService.ReadUsingID("heading", filename);
            string Footer = readFileService.ReadUsingID("footer", filename);
        }
        protected void WriteIntoPageUsingID(string Pagename, string ID, string content)
        {
            var doc = new HtmlDocument();
            doc.Load(@"C:\Users\ShaunakSunilPradhan\Downloads\DevPortal\DevPortal\Pages\" + Pagename + ".html");
            var element = doc.GetElementbyId(ID);
            if (element != null)
            {
                element.InnerHtml = content;
                doc.Save(GetPagePath(Pagename));
            }
        }
        protected object DevPortalObj()
        {
            WebForm1 DevPortal = new WebForm1();
            return DevPortal;
        }
        protected void HeaderOnClick(object sender, EventArgs e)
        {
            string content = "";
            string ID = "heading";
            string PageID = Request.QueryString["PageID"];
            WriteIntoPageUsingID("page" + PageID, ID, content);
        }
        protected string GetPagePath(string filename)
        {
            return @"C:\Users\ShaunakSunilPradhan\Downloads\DevPortal\DevPortal\Pages\" + filename + ".html";
        }
        protected void FooterOnClick(object sender, EventArgs e)
        {
            string content = "";
            string ID = "footer";
            string PageID = Request.QueryString["PageID"];
            WriteIntoPageUsingID("page" + PageID, ID, content);
        }
        protected void lnkManagePage_Click(object sender, EventArgs e)
        {
            gridViewService.GridViewCall("Pages", "Pages", "html", GridView);

        }
        protected void lnkManageDesign_Click(object sender, EventArgs e)
        {
            gridViewService.GridViewCall("Pages", "Pages", "css", GridView);
        }
        protected void lnkManageLogic_Click(object sender, EventArgs e)
        {
            gridViewService.GridViewCall("Pages", "Pages", "js", GridView);
        }
    }
}