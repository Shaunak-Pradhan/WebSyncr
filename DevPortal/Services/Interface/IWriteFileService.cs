using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DevPortal.Services
{
    public interface IWriteFileService
    {
        void WriteFile(string filename, string content);
        void WriteIntoPageUsingID(string PageID, string ID, string content);
        void WriteIntoPageUsingClass(string PageID, string Class, string content);
        void WriteIntoPageUsingName(string Pagename, string ID, string content);
        void DeleteFile(string filename);
        void SaveToFolder(int RequestType, string filename);
        void RewriteFile(string filename, string content);
        string RequestType(int TypeID);
        void MiddlewareRewrite(string pageID,int templateid);
        void WriteIntoPage(string PageName, string content);
    }
}