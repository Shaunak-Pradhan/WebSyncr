using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevPortal.Services.Interface
{
    public interface ICreateFileService
    {
        void CreateFile(string filename, string folderpath, string dotextension);
        void CreateEmptyHTMLPage(string filename, string content);
        void CustomTemplateHTML(int TemplateID, string filename);
        void BindTemplate(int TemplateID, string PageName, string DisplayName, string extension);
    }
}
