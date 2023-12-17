using DevPortal.Services;
using DevPortal.Services.Implementation;
using DevPortal.Services.Interface;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing.Drawing2D;
using System.IO;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using static DevPortal.Services.Implementation.DataBlocksService;
namespace DevPortal.FrontEnd
{
    public partial class CMS : System.Web.UI.Page
    {
        private static string pageID;
        readonly IReadFileService readFileService= new ReadFileService();
        readonly IGridViewService gridViewService= new GridViewService();
        readonly IWriteFileService writeFileService= new WriteFileService();
        readonly IDataBlocksService dataBlocks = new DataBlocksService();
        readonly ISQLService sQLService = new SQLService();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!User.Identity.IsAuthenticated)
            {
                Response.Redirect("~/FrontEnd/Login.aspx");
            }else

            dataBlocks.MapDataBlocks(@"C:\Users\ShaunakSunilPradhan\Downloads\DevPortal\DevPortal\Pages\ClonedPage_55951.html", @"C:\Users\ShaunakSunilPradhan\Downloads\DevPortal\DevPortal\Pages\Page6.html");
            if (!IsPostBack)
            {
                if (Request.QueryString["PageID"] != null)
                {
                    pageID = Request.QueryString["PageID"];
                    gridViewService.GetRowForFile("Page" + pageID + ".html", "PageName", GridView);
                    PageData nodes = dataBlocks.CreateDataBlocks("Page" + pageID);
                    foreach (var property in nodes.DynamicProperties)
                    {
                        dataBlocks.CreateDynamicControls(dynamicLabelsPlaceholder, property.Key, property.Value);
                    }
                }
                else if (Request.QueryString["LogicID"] != null)
                {
                    string logicID = Request.QueryString["LogicID"];
                    gridViewService.GetRowForFile("Logic" + logicID + ".js", "PageName", GridView);
                    headingField.Text = readFileService.ReadFile("Logic" + logicID, readFileService.FileExtensions());
                    ClientScript.RegisterStartupScript(this.GetType(), "HideLabelsDiv", "<script>$('#Labels').hide();$('#headingField').show();$('#Button2').show();</script>");
                }
                else
                {
                    string designID = Request.QueryString["DesignID"];
                    gridViewService.GetRowForFile("Design" + designID + ".css", "PageName", GridView);
                    headingField.Text = readFileService.ReadFile("Design" + designID, readFileService.FileExtensions());
                    ClientScript.RegisterStartupScript(this.GetType(), "HideLabelsDiv", "<script>$('#Labels').hide();$('#headingField').show();$('#Button2').show();</script>");
                }
            }
        }
        [WebMethod]
        public static void DynamicControlOnClick(string propertyName, string textareaText)
        {
            SQLService sqlService = new SQLService();
            WriteFileService writeFileService = new WriteFileService();
            sqlService.InsertToDataBlocks(1,propertyName,textareaText,Int32.Parse(pageID));
            writeFileService.WriteIntoPageUsingID(pageID,propertyName, textareaText);
        }
        protected void HeaderOnClick(object sender, EventArgs e)
        {
            if (Request.QueryString["PageID"] != null)
            {
                pageID = Request.QueryString["PageID"];
                string content = headingField.Text;
                writeFileService.WriteFile("Page"+ pageID, content);
            }
            else if (Request.QueryString["LogicID"] != null)
            {
                string logicID = Request.QueryString["LogicID"];
                string content = headingField.Text;
                writeFileService.WriteFile("Logic" + logicID, content);
            }
            else
            {
                string designID = Request.QueryString["DesignID"];
                string content = headingField.Text;
                writeFileService.WriteFile("Design" + designID, content);
            }
        }
        protected void FooterOnClick(object sender, EventArgs e)
        {
            string content = footerField.Text;
            string ID = "footer";
            string PageID = Request.QueryString["PageID"];
            writeFileService.WriteIntoPageUsingName("page" + PageID, ID, content);
        }
    }
}