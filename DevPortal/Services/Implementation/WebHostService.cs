using DevPortal.Services.Interface;
using System;
using System.Configuration;
using System.IO;
using System.Security.AccessControl;
using System.Web.UI.WebControls;

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
    public string Directory(string PageName = null, string FolderName = null)
    {
        if (environment == "Local")
        {
            if (PageName == null)
            {
                return @"C:\Users\ShaunakSunilPradhan\Downloads\DevPortal\DevPortal\" + FolderName + "\\";
            }
            else if (PageName == null && FolderName == null)
            {
                return $@"h:\root\home\shaunakpradhan - 001\www\websyncr\publish";
            }
            else
                return @"C:\Users\ShaunakSunilPradhan\Downloads\DevPortal\DevPortal\Pages\" + PageName + ".html"; ;
        }
        else if (environment == "SmarterASP")
        {
            if (PageName == null)
            {
                return $@"h:\root\home\shaunakpradhan - 001\www\websyncr\publish\{FolderName}";
            }
            else if (PageName == null && FolderName == null)
            {
                return $@"h:\root\home\shaunakpradhan - 001\www\websyncr\publish";
            }
            else
                return @"h:\root\home\shaunakpradhan - 001\www\websyncr\publish\Pages\" + PageName + ".html"; ;
        }
        else
        {
            throw new InvalidOperationException($"Unsupported environment: {environment}");
        }
    }

    string directoryPath = @"h:\root\home\shaunakpradhan-001\www\websyncr\publish";
    public string AccessCheck()
    {
        try
        {
            if (!System.IO.Directory.Exists(directoryPath))
            {
                return "Directory not detected";
            }
            else
            {
                DirectorySecurity directorySecurity = System.IO.Directory.GetAccessControl(directoryPath);
                string userAccount = "shaunakpradhan-001"; 

                // Define the type of access control to grant (e.g., FileSystemRights.Read, FileSystemRights.Write).
                FileSystemRights accessRights = FileSystemRights.FullControl;

                // Define the access control type (e.g., Allow or Deny).
                AccessControlType controlType = AccessControlType.Allow;

                // Add a new FileSystemAccessRule with the specified parameters.
                FileSystemAccessRule accessRule = new FileSystemAccessRule(userAccount, accessRights, controlType);
                directorySecurity.AddAccessRule(accessRule);

                // Apply the modified security settings to the directory.
                System.IO.Directory.SetAccessControl(directoryPath, directorySecurity);

                return "Permissions granted successfully.";
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            return "Error";
        }
    }
}
