using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using static DevPortal.Services.Implementation.DataBlocksService;

namespace DevPortal.Services.Interface
{
    public interface IDataBlocksService
    {
        PageData CreateDataBlocks(string filename);
        PageData GetDataBlocks(string filename);
        void CreateDynamicControls(PlaceHolder dynamicLabelsPlaceholder, string propertyName, string propertyValue); 
        void MapDataBlocks(string fromHtmlPath, string toHtmlPath);
        void MaskDataBlocks(string fromHtmlPath, string toHtmlPath, string propertyName, string propertyValue);
        void PropertyFinder(string property, string value, string pageid);
    }
}
