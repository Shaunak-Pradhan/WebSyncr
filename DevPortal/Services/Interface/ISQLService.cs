using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;

namespace DevPortal.Services.Interface
{
    public interface ISQLService
    {
        SqlConnection SqlConnectionObj();
        void InsertToPages(int Index, string FileName, string DisplayName);
        void InsertToLogic(int Index, string FileName, string DisplayName);
        void InsertToDesign(int Index, string FileName, string DisplayName);
        void InsertToDataBlocks(int Index, string PropertyName,string PropertyValue, int PageID);
        void DeleteFromTable(string Table);
        void DeletePage(string id);
        void UpdateTableSQL(string Table, string PrimaryKeyName, int ID, string colname, string value);
        object GetValueForID(string Table, string Colname, string PrimaryKeyName, int ID);
    }
}