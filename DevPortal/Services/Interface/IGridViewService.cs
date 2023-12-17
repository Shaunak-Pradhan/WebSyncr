using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace DevPortal.Services
{
    public interface IGridViewService
    {
        void GridViewCall(string filename, string table, string extension, GridView gridView);
        void GridViewQuery(string filename, string sql, GridView gridView);
        void GetRowForFile(string filename, string filtercolumn, GridView gridView);
        void GetRowForTable(string filename, string filtercolumn, GridView gridView);
        void GridViewForTable(string table, GridView gridView);
    }
}
