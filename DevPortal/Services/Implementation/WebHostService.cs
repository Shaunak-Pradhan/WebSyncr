using DevPortal.Services.Interface;
using System;
using System.Configuration;

public class WebHostService : IWebHostService
{
    public string HostSettings()
    {
        string environment = "Local";
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
}
