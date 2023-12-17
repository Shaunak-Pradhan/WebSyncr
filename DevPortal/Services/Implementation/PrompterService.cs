using DevPortal.Services.Interface;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DevPortal.Services.Implementation
{
    public class PrompterService : IPrompterService
    {
        public void Compiler(string html)
        {
            Dictionary<string, string> nodesObject = ExtractData(html);
            CreateNodes(nodesObject);
        }
        public Dictionary<string, string> ExtractData(string html)
        {
            var doc = new HtmlDocument();
            doc.LoadHtml(html);
            var extractedData = new Dictionary<string, string>();
            var elementsWithId = doc.DocumentNode.SelectNodes("//*[@id]");
            if (elementsWithId != null)
            {
                foreach (var element in elementsWithId)
                {
                    string id = element.GetAttributeValue("id", "");
                    string text = element.InnerText;
                    string variableName = "id_" + id.ToLower();
                    extractedData[variableName] = text;
                }
            }
            var elementsWithClass = doc.DocumentNode.SelectNodes("//*[@class]");
            if (elementsWithClass != null)
            {
                foreach (var element in elementsWithClass)
                {
                    string className = element.GetAttributeValue("class", "");
                    string text = element.InnerText;
                    string variableName = "class_" + className.ToLower();
                    extractedData[variableName] = text;
                }
            }
            return extractedData;
        }
        protected void DefineProperty()
        {

        }
        protected void CreateNodes(Dictionary<string, string> NodesData)
        {

        }
        public async Task<string> GetHtmlAsync(string url)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync(url);
                    if (response.IsSuccessStatusCode)
                    {                        
                        return await response.Content.ReadAsStringAsync();
                    }
                    else
                    {
                        Console.WriteLine($"Error: {response.StatusCode}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
            }
            return string.Empty;
        }
        public async Task ChatGPT(string prompt)
        {
            string apiKey = "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";
            string model = "gpt-3.5-turbo";
            using (HttpClient client = new HttpClient())
            {
                string url = "https://api.openai.com/v1/chat/completions";
                var request = new HttpRequestMessage(HttpMethod.Post, url);
                request.Headers.Add("Authorization", $"Bearer {apiKey}");
                string payload = @"
        {
            ""model"": """ + model + @""",
            ""messages"": [
                { ""role"": ""system"", ""content"": ""You are a helpful assistant."" },
                { ""role"": ""user"", ""content"": """ + prompt + @""" }
            ]
        }";
                var content = new StringContent(payload, Encoding.UTF8, "application/json");
                request.Content = content;
                bool retry = true;
                int retryCount = 0;
                while (retry && retryCount < 3)
                {
                    try
                    {
                        HttpResponseMessage response = await client.SendAsync(request);
                        if (response.IsSuccessStatusCode)
                        {
                            string responseJson = await response.Content.ReadAsStringAsync();
                            Console.WriteLine("Response: " + responseJson);
                            retry = false;
                        }
                        else if ((int)response.StatusCode == 429)
                        {
                            retryCount++;
                            int delaySeconds = (int)Math.Pow(2, retryCount);
                            Console.WriteLine($"Rate limited. Retrying in {delaySeconds} seconds.");
                            await Task.Delay(TimeSpan.FromSeconds(delaySeconds));
                        }
                        else
                        {
                            Console.WriteLine("Error: " + response.StatusCode);
                            retry = false;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                        retry = false;
                    }
                }
                if (retryCount >= 3)
                {
                    Console.WriteLine("Max retries reached. Unable to complete the request.");
                }
            }
        }
    }
}