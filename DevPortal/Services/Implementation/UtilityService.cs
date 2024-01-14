using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using DevPortal.Services.Interface;
using DevPortal.Models;
using DevPortal.DTOs;
using System.Data;
using System.Web.Services;

namespace DevPortal.Services.Implementation
{
    public class UtilityService : IUtilityService
    {
        readonly IWebHostService _webHostService = new WebHostService();
        public int GetFileID(string filename)
        {
            return 1;
        }

        public string PagesFolder(string PageName)
        {
            return _webHostService.Directory(PageName);
        }
        public string JsFolderOld(string filename)
        {
            return @"C:\Users\ShaunakSunilPradhan\Downloads\DevPortal\DevPortal\js\" + filename;
        }
        public string ResourcePath(string TemplateName, string filetype, string filename)
        {
            return @"C:\Users\ShaunakSunilPradhan\source\repos\DevPortal\DevPortal\Resource\" + TemplateName + "\\" + filetype + "\\" + filename;
        }
        public string SpeedTestAPI(string filename)
        {
            return "AIzaSyAAbYLoGX6zziRD6sga_d99VoTpwP_Cu-I";
        }
        public string CoinAPI(string filename)
        {
            return "63E1DC47-3026-420B-A9D4-708D81C42D2E-I";
        }
        public string JsFolder(string TemplateName)
        {
            return @"C:\Users\ShaunakSunilPradhan\Downloads\DevPortal\DevPortal\Resource\" + TemplateName + "\\js\\";
        }
        public string DesignFolder()
        {
            return @"C:\Users\ShaunakSunilPradhan\source\repos\DevPortal\DevPortal\Designs\";
        }
        public string LogicFolder()
        {
            return @"C:\Users\ShaunakSunilPradhan\source\repos\DevPortal\DevPortal\Logic\";
        }

        public string Deploy()
        {
            return "";
        }
        public string WriteComponent(string elementName, string value, string elementType = null)
        {
            string HeadTag = "";
            string Body = "";
            string Footer = "";
            string Script = "";
            string Link = "";
            if (elementType == "HTML")
            {
                if (elementName == "HeadTag")
                {
                    HeadTag = value;
                }
                else if (elementName == "Body")
                {
                    Body = value;
                }
                else if (elementName == "Footer")
                {
                    Footer = value;
                }
                else if (elementName == "Script")
                {
                    Script = value;
                }
                else if (elementName == "Link")
                {
                    Link = value;
                }
                else
                {
                }
            }
            else
            {
            }
            return "";
        }
        public string ReadComponentByID(string ID)
        {
            return "";
        }
        public string placeholder(string tag, string uniqueID = null)
        {
            uniqueID = "0909";
            string Expression = $@"[<>]{tag}{uniqueID}[</>]";
            return Expression;
        }
        public string renderPlaceholder(string placeholder)
        {
            ReadComponentByID("");
            return "";
        }
        public string rename(string tag, string templateID, string value)
        {
            try
            {
                string filePath = "your_file.txt";
                string fileContent = System.IO.File.ReadAllText(filePath);
                fileContent = fileContent.Replace(tag, value);
                System.IO.File.WriteAllText(filePath, fileContent);
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred: " + e.Message);
            }
            return "";
        }
        public string renamecompiler(int templateID)
        {
            try
            {
                string filePath = "your_file.txt";
                string fileContent = System.IO.File.ReadAllText(filePath);
                fileContent = fileContent.Replace("", "");
                System.IO.File.WriteAllText(filePath, fileContent);
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred: " + e.Message);
            }
            return "";
        }
        public string oldcompiler(string filename, string tag, string value)
        {
            try
            {
                string filePath = @"C:\Users\ShaunakSunilPradhan\Desktop\" + filename;
                string fileContent = System.IO.File.ReadAllText(filePath);
                fileContent = fileContent.Replace(placeholder(tag), value);
                System.IO.File.WriteAllText(filePath, fileContent);
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred: " + e.Message);
            }
            return "compiled succesfully";
        }
        public string getHTML(string filename, string tag)
        {
            string filePath = @"C:\Users\ShaunakSunilPradhan\Desktop\" + filename;
            try
            {
                string fileContent = System.IO.File.ReadAllText(filePath);
                string headContent = _getHTML(fileContent, tag);
                return headContent;
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred: " + e.Message);
            }
            return "";
        }
        public string writeHTML(string filename, string tag, string value)
        {
            string filePath = @"C:\Users\ShaunakSunilPradhan\Desktop\" + filename;
            string htmlContent = System.IO.File.ReadAllText(filePath);
            int Start = htmlContent.IndexOf($@"<{tag}>");
            int End = htmlContent.IndexOf($@"</{tag}>");
            if (Start != -1 && End != -1)
            {
                string modifiedHtml = htmlContent.Substring(0, Start + tag.Length + 2) + value + htmlContent.Substring(End);
                System.IO.File.WriteAllText(filePath, modifiedHtml);
            }
            return "done";
        }
        public string _getHTML(string input, string tagName)
        {
            string pattern = $"<{tagName}.*?>(.*?)</{tagName}>";
            Match match = Regex.Match(input, pattern, RegexOptions.Singleline);
            if (match.Success)
            {
                return match.Groups[1].Value;
            }
            return string.Empty;
        }
        public string GetTemplate(int templateID, Placeholderdto data)
        {

            string[] Template = new string[4];
            Template[0] = "";
            Template[1] = $@"<html>
                               <head>
                                  <meta charset='utf-8'>
                                  <title>{data.Title}</title>
                               </head>
                               <font color='#A6ACAF' size='5'>
                                  <marquee><b><i>{data.Heading1}</i></b></marquee>
                               </font>
                               <body background='' link='white' alink='blue' vlink='#F8F8FF' >
                                  <h1 align='center'> <font color='#F0B27A' size='9' id='heading'> {data.Heading2} <br/> </font>{data.Heading3}</h1>
                                  <h3 align='center'>
                                  <font face='Lato' color='red' size='3'> {data.Paragraph1} </font> <br /><br /><br /><br /><br /><br/><br/><br/><br/> 
                                  <hr width='1500px'>
                                  <footer id='footer'>
                                     <center> <b> <font face='cinzel' size='4'> <a href ='#'>About Us| <a href ='#'>Contact Us | <a href ='#'> Privacy Policy | <a href ='#'> Terms | <a href ='#'>Media Kit | <a href ='#'> Sitemap | <a href ='#'> Report a Bug | <a href ='#'> FAQ Partners</a><br/> <a href ='#'>C# Tutorials| <a href ='#'> Common Interview Questions| <a href ='#'> Stories | <a href ='#'>Consultants | <a href ='#'> Ideas | <a href ='#'> Certifications </a><br/><br/> <font color='#FF0000'>all@copyrights 2020</font> </font> </b> </center>
                                  </footer>
                               </body>
                            </html>";
            return Template[templateID];
        }
    }

}