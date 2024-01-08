using DevPortal.Services.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web.Management;

namespace DevPortal.Services.Implementation
{
    public class SQLService : ISQLService
    {
        IWebHostService webHostService = new WebHostService();
        private string connectionstring()
        {
            //return @"Data Source=.;Initial Catalog=Cbsequick;Integrated Security=True;MultipleActiveResultSets=true;"
            return @"Data Source=SQL8006.site4now.net;Initial Catalog=db_aa37fc_cbsequick;User Id=db_aa37fc_cbsequick_admin;Password=P@ssw0rd";
        }
        public SqlConnection SqlConnectionObj()
        {
            SqlConnection sqlconn = new SqlConnection(webHostService.Environment());
            try
            {
                sqlconn.Open();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            return sqlconn;
        }
        public void InsertToPages(int Index, string FileName, string DisplayName)
        {
            SqlConnection connection1 = new SqlConnection(webHostService.Environment());
            SqlDataAdapter cmd = new SqlDataAdapter();
            cmd.InsertCommand = new SqlCommand("insert into Pages ( PID,PageName,DisplayName,TemplateID,TemplateName,PageURL,EditLink) values(@PID,@PageName,@DisplayName,null,null,@PageURL,@EditLink) ", connection1);
            connection1.Open();
            cmd.InsertCommand.Parameters.Add("@PID", SqlDbType.Int).Value = Index;
            cmd.InsertCommand.Parameters.Add("@PageName", SqlDbType.VarChar).Value = FileName;
            cmd.InsertCommand.Parameters.Add("@DisplayName", SqlDbType.VarChar).Value = DisplayName;
            cmd.InsertCommand.Parameters.Add("@PageURL", SqlDbType.VarChar).Value = "/Pages/" + FileName;
            cmd.InsertCommand.Parameters.Add("@EditLink", SqlDbType.VarChar).Value = "CMSRecord.aspx?PageID=" + Index;
            int rowsAffected = cmd.InsertCommand.ExecuteNonQuery();
            connection1.Close();
        }
        public void InsertToLogic(int Index, string FileName, string DisplayName)
        {
            SqlConnection connection1 = new SqlConnection(webHostService.Environment());
            SqlDataAdapter cmd = new SqlDataAdapter();
            cmd.InsertCommand = new SqlCommand("insert into Pages ( PID,PageName,DisplayName,TemplateID,TemplateName,PageURL,EditLink) values(@PID,@PageName,@DisplayName,null,null,@PageURL,@EditLink) ", connection1);
            connection1.Open();
            cmd.InsertCommand.Parameters.Add("@PID", SqlDbType.Int).Value = Index;
            cmd.InsertCommand.Parameters.Add("@PageName", SqlDbType.VarChar).Value = FileName;
            cmd.InsertCommand.Parameters.Add("@DisplayName", SqlDbType.VarChar).Value = DisplayName;
            cmd.InsertCommand.Parameters.Add("@PageURL", SqlDbType.VarChar).Value = "/Logic/" + FileName;
            cmd.InsertCommand.Parameters.Add("@EditLink", SqlDbType.VarChar).Value = "CMSRecord.aspx?LogicID=" + Index;
            int rowsAffected = cmd.InsertCommand.ExecuteNonQuery();
            connection1.Close();
        }
        public void InsertToDesign(int Index, string FileName, string DisplayName)
        {
            SqlConnection connection1 = new SqlConnection(webHostService.Environment());
            SqlDataAdapter cmd = new SqlDataAdapter();
            cmd.InsertCommand = new SqlCommand("insert into Pages ( PID,PageName,DisplayName,TemplateID,TemplateName,PageURL,EditLink) values(@PID,@PageName,@DisplayName,null,null,@PageURL,@EditLink) ", connection1);
            connection1.Open();
            cmd.InsertCommand.Parameters.Add("@PID", SqlDbType.Int).Value = Index;
            cmd.InsertCommand.Parameters.Add("@PageName", SqlDbType.VarChar).Value = FileName;
            cmd.InsertCommand.Parameters.Add("@DisplayName", SqlDbType.VarChar).Value = DisplayName;
            cmd.InsertCommand.Parameters.Add("@PageURL", SqlDbType.VarChar).Value = "/Designs/" + FileName;
            cmd.InsertCommand.Parameters.Add("@EditLink", SqlDbType.VarChar).Value = "CMSRecord.aspx?DesignID=" + Index;
            int rowsAffected = cmd.InsertCommand.ExecuteNonQuery();
            connection1.Close();
        }
        public void InsertToDataBlocks(int Index, string PropertyName, string PropertyValue, int PageID)
        {
            SqlConnection connection1 = new SqlConnection(webHostService.Environment());
            SqlDataAdapter cmd = new SqlDataAdapter();
            cmd.InsertCommand = new SqlCommand($@"insert into DataBlocks ( ID,[PropertyName],[PropertyValue],[PageID]) values(@ID,@PropertyName,@PropertyValue,@PageID) ", connection1);
            connection1.Open();
            cmd.InsertCommand.Parameters.Add("@ID", SqlDbType.Int).Value = Index;
            cmd.InsertCommand.Parameters.Add("@PropertyName", SqlDbType.VarChar).Value = PropertyName;
            cmd.InsertCommand.Parameters.Add("@PropertyValue", SqlDbType.VarChar).Value = PropertyValue;
            cmd.InsertCommand.Parameters.Add("@PageID", SqlDbType.VarChar).Value = PageID;
            int rowsAffected = cmd.InsertCommand.ExecuteNonQuery();
            connection1.Close();
        }
        public void InsertToTemplates(int Index, string PropertyName, string PropertyValue, int PageID)
        {
            SqlConnection connection1 = new SqlConnection(webHostService.Environment());
            SqlDataAdapter cmd = new SqlDataAdapter();
            cmd.InsertCommand = new SqlCommand($@"insert into Templates ( ID,[PropertyName],[PropertyValue],[PageID]) values(@ID,@PropertyName,@PropertyValue,@PageID) ", connection1);
            connection1.Open();
            cmd.InsertCommand.Parameters.Add("@ID", SqlDbType.Int).Value = Index;
            cmd.InsertCommand.Parameters.Add("@PropertyName", SqlDbType.VarChar).Value = PropertyName;
            cmd.InsertCommand.Parameters.Add("@PropertyValue", SqlDbType.VarChar).Value = PropertyValue;
            cmd.InsertCommand.Parameters.Add("@PageID", SqlDbType.VarChar).Value = PageID;
            int rowsAffected = cmd.InsertCommand.ExecuteNonQuery();
            connection1.Close();
        }
        public void DeleteFromTable(string Table)
        {
            SqlCommand sqlcmd3 = new SqlCommand("delete from " + Table, SqlConnectionObj());
            sqlcmd3.ExecuteReader();
        }
        public void DeletePage(string id)
        {
            SqlCommand sqlcmd3 = new SqlCommand("delete from Pages where  PID =" + id, SqlConnectionObj());
            sqlcmd3.ExecuteReader();

        }
        public void UpdateTableSQL(string Table, string PrimaryKeyName, int ID, string colname, string value)
        {
            SqlCommand sqlcmd3 = new SqlCommand("update " + Table + " set " + colname + " = " + value + " where " + PrimaryKeyName + " =" + ID, SqlConnectionObj());
            try
            {
                sqlcmd3.ExecuteReader();
            }
            catch
            {
                SqlCommand sqlcmd2 = new SqlCommand("update " + Table + " set " + colname + " = '" + value + "' where " + PrimaryKeyName + " =" + ID, SqlConnectionObj());
                sqlcmd2.ExecuteReader();
            }
        }
        public object GetValueForID(string Table, string Colname, string PrimaryKeyName, int ID)
        {
            SqlCommand sqlcmd3 = new SqlCommand("select " + Colname + " from " + Table + " where " + PrimaryKeyName + " = " + ID, SqlConnectionObj());
            var IndexObj = sqlcmd3.ExecuteReader();
            object temp = "";
            if (IndexObj.Read())
            {
                temp = IndexObj[Colname];
            }
            return temp;
        }
    }
}