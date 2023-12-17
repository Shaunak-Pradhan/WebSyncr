using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.UI.WebControls;
using DevPortal.FrontEnd;
using DevPortal.Services.Interface;
using DevPortal.Services.Implementation;
namespace DevPortal.Services
{
    public class GridViewService : IGridViewService
    {
        readonly ISQLService sQLService = new SQLService();
        public void GridViewCall(string filename, string table, string extension, GridView gridView)
        {
            try
            {
                WebForm1 devPortal = new WebForm1();
                SqlCommand sqlCommand = new SqlCommand($"SELECT PageName, DisplayName, PageURL, EditLink FROM {table}", sQLService.SqlConnectionObj());
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                sqlDataAdapter.SelectCommand = sqlCommand;
                DataSet dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet, "table1");
                DataTable dataTable = dataSet.Tables["table1"];
                var dataRows = dataSet.Tables["table1"].AsEnumerable().Where(row => row.Field<string>("PageName").EndsWith("." + extension)).CopyToDataTable();
                gridView.Visible = true;
                gridView.DataSource = dataRows;
                gridView.DataBind();
                gridView.Rows[0].Cells[0].Visible = true;
            }
            catch (Exception ex)
            {
                gridView.Visible = false;
            }
        }
        public void GridViewQuery(string filename, string sql, GridView gridView)
        {
            try
            {
                WebForm1 devPortal = new WebForm1();
                SqlCommand sqlCommand = new SqlCommand($"{sql}", sQLService.SqlConnectionObj());
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                sqlDataAdapter.SelectCommand = sqlCommand;
                DataSet dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet, "table1");
                DataTable dataTable = dataSet.Tables["table1"];
                gridView.DataSource = dataSet;
                gridView.DataBind();
                gridView.Rows[0].Cells[0].Visible = true;
            }
            catch (Exception ex)
            {
                gridView.Visible = false;
            }
        }
        public void GetRowForFile(string filename,string filtercolumn, GridView gridView)
        {
            try
            {
                WebForm1 devPortal = new WebForm1();
                SqlCommand sqlCommand = new SqlCommand($"SELECT * FROM Pages", sQLService.SqlConnectionObj());
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                sqlDataAdapter.SelectCommand = sqlCommand;
                DataSet dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet, "table1");
                DataTable dataTable = dataSet.Tables["table1"];
                var dataRows = dataTable.AsEnumerable().Where(row =>
                    string.Equals(row.Field<string>(filtercolumn), filename, StringComparison.OrdinalIgnoreCase)
                ).ToArray();
                DataTable filteredDataTable = dataTable.Clone();
                foreach (var dataRow in dataRows)
                {
                    filteredDataTable.ImportRow(dataRow);
                }
                gridView.Visible = true;
                gridView.DataSource = filteredDataTable;
                gridView.DataBind();
                gridView.Rows[0].Cells[0].Visible = true;
            }
            catch (Exception ex)
            {
                gridView.Visible = true;
            }
        }
        public void GetRowForTable(string filename, string filtercolumn, GridView gridView)
        {
            try
            {
                WebForm1 devPortal = new WebForm1();
                SqlCommand sqlCommand = new SqlCommand($"SELECT * FROM Pages", sQLService.SqlConnectionObj());
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                sqlDataAdapter.SelectCommand = sqlCommand;
                DataSet dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet, "table1");
                DataTable dataTable = dataSet.Tables["table1"];
                var dataRows = dataTable.AsEnumerable().Where(row =>
                    string.Equals(row.Field<string>(filtercolumn), filename, StringComparison.OrdinalIgnoreCase)
                ).ToArray();
                DataTable filteredDataTable = dataTable.Clone();
                foreach (var dataRow in dataRows)
                {
                    filteredDataTable.ImportRow(dataRow);
                }
                gridView.Visible = true;
                gridView.DataSource = filteredDataTable;
                gridView.DataBind();
                gridView.Rows[0].Cells[0].Visible = true;
            }
            catch (Exception ex)
            {
                gridView.Visible = true;
            }
        }
        public void GridViewForTable(string table, GridView gridView)
        {
            try
            {
                var sqlCommand = new SqlCommand($"SELECT * FROM {table}", sQLService.SqlConnectionObj());
                var sqlDataAdapter = new SqlDataAdapter();
                sqlDataAdapter.SelectCommand = sqlCommand;
                var dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet, "table1");
                DataTable dataTable = dataSet.Tables["table1"];
                gridView.Visible = true;
                gridView.DataSource = dataTable;
                gridView.DataBind();
                gridView.Rows[0].Cells[0].Visible = true;
            }
            catch (Exception ex)
            {
                gridView.Visible = false;
            }
        }
    }
}
