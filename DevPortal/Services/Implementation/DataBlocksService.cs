using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.Management;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using DevPortal.Models;
using DevPortal.Services.Interface;
namespace DevPortal.Services.Implementation
{
    public class DataBlocksService : IDataBlocksService
    {
        readonly IReadFileService readFileService = new ReadFileService();
        readonly ISQLService sQLService = new SQLService();
        readonly IPrompterService prompterService = new PrompterService();
        readonly IUtilityService utilityService = new UtilityService();
        public class PageData
        {
            public Dictionary<string, string> DynamicProperties { get; set; } = new Dictionary<string, string>();
        }
        public PageData CreateDataBlocks(string filename)
        {
            PageData pageData = new PageData();
            string html = readFileService.ReadFile(filename, readFileService.FileExtensions());
            Dictionary<string, string> nodes = prompterService.ExtractData(html);
            foreach (var node in nodes)
            {
                pageData.DynamicProperties[node.Key] = node.Value;
            }
            pageData.DynamicProperties["Heading"] = readFileService.ReadUsingID("heading", filename);
            pageData.DynamicProperties["Footer"] = readFileService.ReadUsingID("footer", filename);
            return pageData;
        }
        public PageData GetDataBlocks(string filename)
        {
            PageData pageData = new PageData();
            string html = readFileService.ReadFile(filename, readFileService.FileExtensions());
            Dictionary<string, string> nodes = prompterService.ExtractData(html);
            foreach (var node in nodes)
            {
                pageData.DynamicProperties[node.Key] = node.Value;
            }
            return pageData;
        }
        public void CreateDynamicControls(PlaceHolder dynamicLabelsPlaceholder, string propertyName, string propertyValue)
        {
            TextBox textarea = new TextBox
            {
                ID = $"{propertyName}Field",
                TextMode = TextBoxMode.MultiLine,
                CssClass = "txt",
                ClientIDMode = ClientIDMode.Static,
                Text = propertyValue
            };
            textarea.Style["width"] = "99%";
            textarea.Style["height"] = "500px";
            textarea.Style["display"] = "none";
            string buttonScript = $@"
              $('#{propertyName}Button').on('click', function () {{
                    var text = $('#{propertyName}Field').val();
                    $.ajax({{
                    type: ""POST"",
                    url: ""CMSRecord.aspx/DynamicControlOnClick"",
                    data: JSON.stringify({{ propertyName: '{propertyName}', textareaText: text }}),
                    contentType: ""application/json; charset=utf-8"",
                    dataType: ""json"",
                    success: function (response) {{
                    }},
                    error: function (response) {{
                    }}
                }});
            }});
            ";
            string buttonOnClick = $@"document.getElementById('{propertyName}Button').addEventListener('click', function () {{
                debugger;
                 DynamicControlOnClick('{propertyName}');
             }});";
            ScriptManager.RegisterStartupScript(dynamicLabelsPlaceholder, dynamicLabelsPlaceholder.GetType(), $"ButtonScript_{propertyName}", buttonScript, true);
            ScriptManager.RegisterStartupScript(dynamicLabelsPlaceholder, dynamicLabelsPlaceholder.GetType(), $"ButtonScript_{propertyName}", buttonOnClick, true);
            Button submitButton = new Button
            {
                ID = $"{propertyName}Button",
                Text = "Submit",
                ClientIDMode = ClientIDMode.Static,
                CssClass = "button-29"
            };
            submitButton.Style["display"] = "none";
            dynamicLabelsPlaceholder.Controls.Add(new LiteralControl("<br />"));
            dynamicLabelsPlaceholder.Controls.Add(new LiteralControl($"<strong class='button-29' id='{propertyName}Label' onclick=\"expandLabel('{propertyName}Label', '{propertyName}Field', '{propertyName}Button');\">{propertyName}:</strong>"));
            dynamicLabelsPlaceholder.Controls.Add(textarea);
            dynamicLabelsPlaceholder.Controls.Add(submitButton);
        }
        private void DynamicControlOnClick(PlaceHolder dynamicLabelsPlaceholder, string propertyName, TextBox textarea, Button submitButton)
        {
            string textareaID = $"{propertyName}Field";
            string divID = $"{propertyName}Div";
            HtmlGenericControl dynamicControlDiv = dynamicLabelsPlaceholder.FindControl(divID) as HtmlGenericControl;
            if (textarea != null && dynamicControlDiv != null)
            {
                string textareaText = textarea.Text;
                dynamicControlDiv.Style["display"] = textarea.Style["display"];
            }
        }
        public void PropertyFinder(string property, string value, string pageid)
        {
            string filePath = Path.Combine(@"C:\Users\ShaunakSunilPradhan\Downloads\DevPortal\DevPortal\Pages\", $"Page{pageid}.html");
            if (File.Exists(filePath))
            {
                string htmlContent = File.ReadAllText(filePath);
                string replacedHtml = ReplacePropertyValue(htmlContent, property, value);
                File.WriteAllText(filePath, replacedHtml);
                Console.WriteLine($"Property '{property}' in Page{pageid}.html has been replaced with '{value}'.");
            }
            else
            {
                Console.WriteLine($"Page{pageid}.html not found in the specified directory.");
            }
        }
        private string ReplacePropertyValue(string htmlContent, string property, string value)
        {
            string propertyPattern = $"id=\"{property}\"";
            string replacedHtml = htmlContent.Replace(propertyPattern, $"{property}=\"{value}\"");
            return replacedHtml;
        }
        public void MapDataBlocks(string fromHtmlPath, string toHtmlPath)
        {
            try
            {
                string fromHtmlContent = File.ReadAllText(fromHtmlPath);
                string toHtmlContent = File.ReadAllText(toHtmlPath);
                toHtmlContent = MapTags(fromHtmlContent, toHtmlContent);
                File.WriteAllText(toHtmlPath, toHtmlContent);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
        public void MapAlgorithm()
        {
        }
        public string MapTags(string fromHtmlContent, string toHtmlContent)
        {
            Type tagType = typeof(DataBlockTags);
            foreach (var prop in tagType.GetProperties())
            {
                string pattern = $@"<{prop.Name}\s+id=""([^""]+)""[^>]*>.*?<\/{prop.Name}>";
                var fromMatches = Regex.Matches(fromHtmlContent, pattern, RegexOptions.Singleline);
                foreach (Match match in fromMatches)
                {
                    string id = match.Groups[1].Value;
                    string tagName = Regex.Match(pattern, @"<(\w+)", RegexOptions.IgnoreCase).Groups[1].Value;
                    bool tagExists = Regex.IsMatch(toHtmlContent, pattern, RegexOptions.Singleline);
                    if (tagExists)
                    {
                        string replacement = $"<{prop.Name} id='{id}'>{match.Groups[0].Value}</{prop.Name}>";
                        string tagPattern = $@"<{prop.Name}\s+id=(""|')\s*{id}\s*(""|')[^>]*>.*?<\/{prop.Name}>";
                        toHtmlContent = Regex.Replace(toHtmlContent, tagPattern, replacement, RegexOptions.IgnoreCase | RegexOptions.Singleline);
                    }
                }
            }
            return toHtmlContent;
        }
        public void MaskDataBlocks(string fromHtmlPath, string toHtmlPath, string propertyName, string propertyValue)
        {

        }
    }
}
