﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web.UI.WebControls;
using DevPortal.FrontEnd;
using HtmlAgilityPack;
namespace DevPortal.Services
{
    public class ReadFileService : IReadFileService
    {
        public List<string> FileExtensions()
        {
            List<string> fileExtensionsToSearch = new List<string> {
            ".html",
            ".js",
            ".css" 
            };
            return fileExtensionsToSearch;
        }
        public string ReadFile(string filename, List<string> fileExtensions)
        {
            string innerText = "";
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
                        return File.ReadAllText(filePath);
                    }
                }
            }

            return innerText;
        }
        public string ReadUsingID(string ID, string filename)
        {
            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.Load(@"C:\Users\ShaunakSunilPradhan\Downloads\DevPortal\DevPortal\Pages\" + filename + ".html");
            string innerText = "";
            string elementId = ID;
            HtmlNode element = htmlDoc.GetElementbyId(elementId);
            if (element != null)
            {
                innerText = element.InnerText;
                string attributeValue = element.GetAttributeValue("attributeName", "");
            }
            else
            {
            }
            return innerText;
        }
        public string ReadFileUsingProp(string filetype, string fileid, string filename, string extension, string propertyid = "")
        {
            HtmlDocument htmlDoc = new HtmlDocument();
            string filePath = @"C:\Users\ShaunakSunilPradhan\Downloads\DevPortal\DevPortal\" + filetype + @"\" + filename + "." + extension;
            htmlDoc.Load(filePath);
            if (extension == "html")
            {
                string innerText = "";
                string elementId = propertyid;
                HtmlNode element = htmlDoc.GetElementbyId(elementId);
                if (element != null)
                {
                    innerText = element.InnerText;     
                }
                return innerText;
            }
            return htmlDoc.DocumentNode.OuterHtml;
        }
        
    }
}