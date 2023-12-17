using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevPortal.Services.Interface
{
    public interface IUtilityService
    {
        int GetFileID(string filename);
        string GetTemplate(int templateID, object data);
        string JsFolderOld(string filename);
        string SpeedTestAPI(string filename);
        string DesignFolder();
        string PagesFolder(string PageName);
        string LogicFolder();
    }
}
