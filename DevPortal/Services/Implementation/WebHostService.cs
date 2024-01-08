using DevPortal.Services.Interface;
using System;
using System.Configuration;

public class WebHostService : IWebHostService
{
    string environment = "SmarterASP";
    public string Environment()
    {
        string connectionString;
        if (environment == "Local")
        {
            Console.WriteLine($"Deploying in environment: {environment}");
            return connectionString = ConfigurationManager.ConnectionStrings["LocalConnection"].ConnectionString;
        }
        else if (environment == "SmarterASP")
        {
            Console.WriteLine($"Deploying in environment: {environment}");
            return connectionString = ConfigurationManager.ConnectionStrings["SmarterASPConnection"].ConnectionString;
        }
        else
        {
            throw new InvalidOperationException($"Unsupported environment: {environment}");
        }
        
    }
    public string Directory(string PageName=null)
    {
        if (environment == "Local")
        {
            if (PageName == null)
            {
                return @"C:\Users\ShaunakSunilPradhan\Downloads\DevPortal\DevPortal\Pages\";
            }
            else
            return @"C:\Users\ShaunakSunilPradhan\Downloads\DevPortal\DevPortal\Pages\" + PageName + ".html"; ;
        }
        else if (environment == "SmarterASP")
        {
            if (PageName == null)
            {
                return @"\Pages\";
            }
            return @"\Pages\" + PageName + ".html"; ;
        }
        else
        {
            throw new InvalidOperationException($"Unsupported environment: {environment}");
        }
    }
}
