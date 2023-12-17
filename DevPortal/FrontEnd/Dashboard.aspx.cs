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
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace DevPortal.FrontEnd
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        private DataTable dataTable = new DataTable();
        readonly IGridViewService gridViewService = new GridViewService();
        readonly ICreateFileService createFileService = new CreateFileService();
        readonly IWriteFileService writeFileService = new WriteFileService();
        readonly ISQLService sQLService = new SQLService();
        protected void Page_Load(object sender, EventArgs e)
        {
            //GetInsight();
        }
        protected void Generate(object sender, EventArgs e)
        {
            var DisplayName = TextBox1.Text;
            var Page_ext = writeFileService.RequestType(Int32.Parse(ddlType.SelectedValue));
            string folderPath = "";
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
            string pathName = @"C:\Users\ShaunakSunilPradhan\Downloads\DevPortal\DevPortal\Pages\" + filename + Index + Page_ext;
            string Filename = filename + Index + Page_ext;
            createFileService.BindTemplate(1, Filename, DisplayName,Page_ext);
            if (Page_ext == ".js")
            {
                folderPath = @"C:\Users\ShaunakSunilPradhan\Downloads\DevPortal\DevPortal\Logic\";
                sQLService.InsertToLogic(Index, Filename, DisplayName);
            }
            else if (Page_ext == ".html")
            {
                folderPath = @"C:\Users\ShaunakSunilPradhan\Downloads\DevPortal\DevPortal\Pages\";
                sQLService.InsertToPages(Index, Filename, DisplayName);
            }
            else
            {
                folderPath = @"C:\Users\ShaunakSunilPradhan\Downloads\DevPortal\DevPortal\Designs\";
                sQLService.InsertToDesign(Index, Filename, DisplayName);
            }
            // string[] files = Directory.GetFiles(folderPath);
            // if (files.Length > 0)
            // {
            //     Console.WriteLine("The folder contains files.");
            // }
            // else
            // {
            //     sQLService.DeleteFromTable("Pages");
            //     Console.WriteLine("The folder is empty.");
            // }
            createFileService.CreateFile(Filename, folderPath, Page_ext);
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
            DropDownList ddlName = (DropDownList)sender; // Cast sender as DropDownList
            GridViewRow row = (GridViewRow)ddlName.NamingContainer;
            int rowIndex = row.RowIndex;
            GridViewRow row2 = GridView.Rows[rowIndex];
            string PID = row2.Cells[0].Text;
            string selectedValue = ddlName.SelectedValue;
            ListItem TemplateName = ddlName.Items.FindByValue(selectedValue);
            sQLService.UpdateTableSQL("Pages", "PID", Int32.Parse(PID), "TemplateID", selectedValue);
            sQLService.UpdateTableSQL("Pages", "PID", Int32.Parse(PID), "TemplateName", TemplateName.Text);
            gridViewService.GridViewForTable("Pages",GridView);
            //object reader2 = GetValueFromTable("Pages", "DisplayName", "PID", Int32.Parse(PID));
            createFileService.BindTemplate(Int32.Parse(selectedValue), "Page" + PID + ".html", sQLService.GetValueFromTable("Pages", "DisplayName", "PID", Int32.Parse(PID)).ToString(), ".html");
            //CustomTemplateHTML(Int32.Parse(selectedValue),"Page"+PID);
        }
        protected void ShowGridView(object sender, EventArgs e)
        {
            gridViewService.GridViewForTable("Pages",GridView);
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            //var tb1 = Int32.Parse(TextBox1.Text);
            //var tb2 = TextBox2.Text;
            var tb1 = TextBox1.Text;
            //GeneratePage(tb1, tb2);
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