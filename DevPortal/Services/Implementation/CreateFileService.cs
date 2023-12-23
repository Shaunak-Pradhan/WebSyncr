using DevPortal.Services.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using DevPortal.Models;
using System.Linq;
using System.Text;

namespace DevPortal.Services.Implementation
{
    public class CreateFileService : ICreateFileService
    {
        ISQLService ISQLService { get; set; }
        UtilityService utilityService = new UtilityService(); 
        public void CreateFile(string filename, string folderpath, string dotextension)
        {
            if (dotextension == ".js" || dotextension == ".css")
            {
                FillDefaultJavascript(filename, folderpath);
            }
        }
        private void FillEmptyText(string filename, string folderpath)
        {
            string content = "";
            File.WriteAllText(folderpath + filename, content);
            string readText = File.ReadAllText(folderpath + filename);
            Console.WriteLine(readText);
        }
        protected void FillDefaultJavascript(string filename, string folderpath)
        {
            string content = $@"
            window.onload = function() {{
                console.log('Page has finished loading!');
            }};
            
            function makeAjaxRequest() {{
                var xhr = new XMLHttpRequest();
                xhr.open('GET', '/example/data', true);
                xhr.onload = function() {{
                    if (xhr.status >= 200 && xhr.status < 300) {{
                        console.log('Success! Response:', xhr.responseText);
                    }} else {{
                        console.error('Request failed. Status:', xhr.status, 'Response:', xhr.responseText);
                    }}
                }};
                xhr.onerror = function() {{
                    console.error('Network error occurred');
                }};
                xhr.send();
            }}
            ";
            File.WriteAllText(folderpath + filename, content);
            string readText = File.ReadAllText(folderpath + filename);
            Console.WriteLine(readText);
        }
        public void CreateEmptyHTMLPage(string filename, string content)
        {
            File.WriteAllText(@"C:\Users\ShaunakSunilPradhan\Downloads\DevPortal\DevPortal\Pages\" + filename + ".html", content);
        }
    }
}