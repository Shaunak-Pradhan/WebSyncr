using DevPortal.Services.Implementation;
using DevPortal.Services.Interface;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using static DevPortal.Services.Implementation.TemplateService;

namespace DevPortal.Services
{
    public class WriteFileService : IWriteFileService
    {
        IUtilityService utilityService = new UtilityService();
        IMiddlewareService middlewareService;
        protected string GetPagePath(string filename)
        {
            return @"C:\Users\ShaunakSunilPradhan\Downloads\DevPortal\DevPortal\Pages\" + filename + ".html";
        }
        protected List<string> FileExtensions()
        {
            List<string> fileExtensionsToSearch = new List<string> {
            ".html",
            ".js",
            ".css"
            };
            return fileExtensionsToSearch;
        }
        public void WriteIntoPageUsingID(string PageID, string ID, string content)
        {
            string cleanedID = ID.StartsWith("id_") ? ID.Substring(3) : ID;
            var doc = new HtmlDocument();
            doc.Load(@"C:\Users\ShaunakSunilPradhan\Downloads\DevPortal\DevPortal\Pages\Page" + PageID + ".html");
            var element = doc.GetElementbyId(cleanedID);
            if (element != null)
            {
                element.InnerHtml = content;
                doc.Save(GetPagePath("Page" + PageID));
            }
        }
        public void WriteIntoPageUsingClass(string PageID, string Class, string content)
        {
            string cleanedID = Class.StartsWith("id_") ? Class.Substring(6) : Class;
            var doc = new HtmlDocument();
            doc.Load(@"C:\Users\ShaunakSunilPradhan\Downloads\DevPortal\DevPortal\Pages\Page" + PageID + ".html");
            var element = doc.GetElementbyId(cleanedID);
            if (element != null)
            {
                element.InnerHtml = content;
                doc.Save(GetPagePath("Page" + PageID));
            }
        }
        public void MiddlewareRewrite(string pageID,int templateid)
        {
            List<string> fileExtensionsToSearch = FileExtensions();
            string filePath = FindFile("Page"+pageID, fileExtensionsToSearch);
            if (!string.IsNullOrEmpty(filePath))
            {
                File.WriteAllText(filePath, middlewareService.Pattern(pageID,templateid));
            }
        }
        public void WriteIntoPageUsingName(string Pagename, string ID, string content)
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
        public void WriteFile(string filename, string content)
        {
            List<string> fileExtensionsToSearch = FileExtensions();
            string filePath = FindFile(filename, fileExtensionsToSearch);
            if (!string.IsNullOrEmpty(filePath))
            {
                File.WriteAllText(filePath, content);
            }
        }
        private string FindFile(string filename, List<string> fileExtensions)
        {
            List<string> directoriesToSearch = new List<string>
        {
            @"C:\Users\ShaunakSunilPradhan\Downloads\DevPortal\DevPortal\Pages\",
            @"C:\Users\ShaunakSunilPradhan\Downloads\DevPortal\DevPortal\Designs\",
            @"C:\Users\ShaunakSunilPradhan\Downloads\DevPortal\DevPortal\Logic\"
        };
            foreach (var directory in directoriesToSearch)
            {
                foreach (var extension in fileExtensions)
                {
                    string filePath = Path.Combine(directory, filename + extension);
                    if (File.Exists(filePath))
                    {
                        return filePath;
                    }
                }
            }
            return null;
        }
        public void DeleteFile(string filename)
        {
            string filePath = GetPagePath(filename);
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }
        public void RewriteFile(string filename, string content)
        {
            using (StreamWriter sw = new StreamWriter(GetFilePath(filename)))
            {
                sw.Write(content);
            }
        }
        private string GetFilePath(string filename)
        {
            string[] files = Directory.GetFiles(@"C:\Users\ShaunakSunilPradhan\source\repos\DevPortal\DevPortal\", filename, SearchOption.AllDirectories);
            if (files.Length > 0)
            {
                string filePath = files[0];
                return filePath;
            }
            else
            {
                return null;
            }
        }
        public string RequestType(int TypeID)
        {
            if (TypeID is 1)
            {
                return ".html";
            }
            else if (TypeID is 2)
            {
                return ".css";
            }
            else
            {
                return ".js";
            }
            return null;
        }
        public void SaveToFolder(int RequestType, string filename)
        {
            if (RequestType is 2)
            {
                File.WriteAllText(utilityService.DesignFolder() + filename, "Hello");
                //string readText = File.ReadAllText(@"C:\Users\ShaunakSunilPradhan\Downloads\DevPortal\DevPortal\Pages\" + PageName);
            }
            else if (RequestType is 3)
            {
                utilityService.LogicFolder();
            }
        }
        public void WriteIntoPage(string PageName,string content)
        {
            File.WriteAllText(utilityService.PagesFolder(PageName), content);
        }
    }
}