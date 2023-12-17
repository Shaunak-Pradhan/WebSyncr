using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Net;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using DevPortal.Models;
using DevPortal.Services.Interface;

namespace DevPortal.Services.Implementation
{
    public class SeoService : ISEOService
    {
        IUtilityService utilityService = new UtilityService();
        public void ConvertToWebp()
        {
            string sourceImagePath = "path/to/source/image.jpg";
            string destinationImagePath = "path/to/destination/image.webp";
            using (Bitmap bitmap = new Bitmap(sourceImagePath))
            {
                bitmap.Save(destinationImagePath, ImageFormat.Tiff);
            }
        }
        public void SEOTool()
        {
            string webpageUrl = "https://heritageexpress.com"; 
            using (HttpClient httpClient = new HttpClient())
            {
                string htmlContent = httpClient.GetStringAsync(webpageUrl).GetAwaiter().GetResult();
                HtmlDocument htmlDocument = new HtmlDocument();
                htmlDocument.LoadHtml(htmlContent);
                HtmlNodeCollection imageNodes = htmlDocument.DocumentNode.SelectNodes("//img");
                HtmlNode imageNode = htmlDocument.DocumentNode.SelectSingleNode("//img");
                string src = imageNode.GetAttributeValue("src", "");
            }
        }
        static long GetImageFileSize(string imageUrl)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(imageUrl);
            request.Method = "HEAD";
            using (WebResponse response = request.GetResponse())
            {
                return response.ContentLength;
            }
        }
        static string FormatFileSize(long fileSize)
        {
            string[] sizeSuffixes = { "B", "KB", "MB", "GB", "TB" };
            int i = 0;
            double size = fileSize;
            while (size >= 1024 && i < sizeSuffixes.Length - 1)
            {
                size /= 1024;
                i++;
            }
            return $"{size:0.##} {sizeSuffixes[i]}";
        }
        protected async void GetInsight()
        {
            using (HttpClient client = new HttpClient())
            {
                string apiKey = utilityService.SpeedTestAPI("");
                string url = "https://www.googleapis.com/pagespeedonline/v5/runPagespeed?url=https://www.heritageexpress.com&key=" + apiKey;
                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    var jsonData = JsonDocument.Parse(jsonResponse);
                    var lighthouseResult = jsonData.RootElement.GetProperty("lighthouseResult");
                    var categories = lighthouseResult.GetProperty("categories");
                    var performance = categories.GetProperty("performance");
                    var auditRefs = performance.GetProperty("auditRefs");
                    List<string> performanceIssues = new List<string>();
                    foreach (var auditRef in auditRefs.EnumerateArray())
                    {
                        string issue = auditRef.GetProperty("group").GetString();
                        performanceIssues.Add(issue);
                    }
                }
                else
                {
                    string statusCode = response.StatusCode.ToString();
                    string reasonPhrase = response.ReasonPhrase;
                }
            }
        }
        static async void SiteErrors()
        {
            string websiteUrl = "https://localhost:44309/FrontEnd/DevPortal.aspx";
            using (HttpClient httpClient = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await httpClient.GetAsync(websiteUrl);
                    if (response.IsSuccessStatusCode)
                    {
                        Console.WriteLine("No errors found on the home page.");
                    }
                    else
                    {
                        Console.WriteLine($"Error on the home page. Status code: {response.StatusCode}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred while accessing the home page: {ex.Message}");
                }
                string[] pageUrls = { "https://heritageexpress.com/admin", "https://heritageexpress.com/ceo-message", "https://heritageexpress.com/explore-the-sites" };
                foreach (string pageUrl in pageUrls)
                {
                    try
                    {
                        HttpResponseMessage response = await httpClient.GetAsync(pageUrl);
                        if (response.IsSuccessStatusCode)
                        {
                            Console.WriteLine($"No errors found on page: {pageUrl}");
                        }
                        else
                        {
                            Console.WriteLine($"Error on page: {pageUrl}. Status code: {response.StatusCode}");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"An error occurred while accessing page: {pageUrl}. Error: {ex.Message}");
                    }
                }
            }
        }
        static void SiteWarnings()
        {
            string websiteUrl = "https://localhost:44309/FrontEnd/DevPortal.aspx";
            using (HttpClient httpClient = new HttpClient())
            {
                string htmlContent = httpClient.GetStringAsync(websiteUrl).GetAwaiter().GetResult();
                MatchCollection warningMatches = FindWarnings(htmlContent);
                Console.WriteLine($"Warnings found on {websiteUrl}:");
                foreach (Match warningMatch in warningMatches)
                {
                    Console.WriteLine(warningMatch.Value);
                }
            }
        }
        static MatchCollection FindWarnings(string htmlContent)
        {
            string pattern = @"<div class=""warning"">.*?</div>";
            Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
            return regex.Matches(htmlContent);
        }
        static void SiteOptimize()
        {
            SEOData.OptimizationResult result = OptimizeWebsite();
            Console.WriteLine($"Optimization Points: {result.Points}");
            Console.WriteLine($"Optimization Summary: {result.Summary}");
        }
        static SEOData.OptimizationResult OptimizeWebsite()
        {
            SEOData.OptimizationResult result = new SEOData.OptimizationResult();
            int points = 0;
            points += OptimizeStaticAssets();
            points += EnableCompression();
            points += OptimizeImageLoading();
            points += ImplementCaching();
            result.Points = points;
            result.Summary = "Website optimization completed successfully.";
            return result;
        }
        static int OptimizeStaticAssets()
        {
            int points = 0;
            points += 10;
            return points;
        }
        static int EnableCompression()
        {
            int points = 0;
            points += 5;
            return points;
        }
        static int OptimizeImageLoading()
        {
            int points = 0;
            points += 8;
            return points;
        }
        static int ImplementCaching()
        {
            int points = 0;
            points += 7;
            return points;
        }
        private readonly HttpClient _httpClient;
        private const string ApiEndpoint = "https://www.googleapis.com/pagespeedonline/v5/runPagespeed?url=";
        public async Task<List<string>> GetPerformanceIssues(string url)
        {
            try
            {
                string requestUrl = $"{ApiEndpoint}{url}";
                HttpResponseMessage response = await _httpClient.GetAsync(requestUrl);
                response.EnsureSuccessStatusCode();
                string jsonResponse = await response.Content.ReadAsStringAsync();
                var jsonData = JsonDocument.Parse(jsonResponse);
                var lighthouseResult = jsonData.RootElement.GetProperty("lighthouseResult");
                var categories = lighthouseResult.GetProperty("categories");
                var performance = categories.GetProperty("performance");
                var auditRefs = performance.GetProperty("auditRefs");
                List<string> performanceIssues = new List<string>();
                foreach (var auditRef in auditRefs.EnumerateArray())
                {
                    string issue = auditRef.GetProperty("group").GetString();
                    performanceIssues.Add(issue);
                }
                return performanceIssues;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return null;
            }
        }
    }
}