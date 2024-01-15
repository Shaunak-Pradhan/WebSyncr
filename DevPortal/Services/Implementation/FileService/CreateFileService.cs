using DevPortal.Services.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using DevPortal.Models;
using System.Linq;
using System.Text;
using System.Security.AccessControl;

namespace DevPortal.Services.Implementation
{
    public class CreateFileService : ICreateFileService
    {
        WebHostService webHostService = new WebHostService();
        public void CreateFile(string filename, string folderpath, string dotextension)
        {
            if (dotextension == ".js" || dotextension == ".css")
            {
                FillDefaultJavascript(filename, folderpath);
            }
            else CreateEmptyHTMLPage(filename, folderpath);
        }
        private void FillEmptyText(string filename, string folderpath)
        {
            string content = "";
            System.IO.File.WriteAllText(folderpath + filename, content);
            string readText = System.IO.File.ReadAllText(folderpath + filename);
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
            System.IO.File.WriteAllText(folderpath + filename, content);
            string readText = System.IO.File.ReadAllText(folderpath + filename);
            Console.WriteLine(readText);
        }
        public void CreateEmptyHTMLPage(string filename, string content)
        {
            try
            {
                string filePath = webHostService.Directory(filename);
                //string filePath = $@"h:\root\home\shaunakpradhan-001\www\websyncr\publish\Pages\{filename}.html";
                string directoryPath = Path.GetDirectoryName(filePath);

                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }
                System.IO.File.WriteAllText(filePath, content);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}