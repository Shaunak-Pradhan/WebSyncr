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
    }
}
