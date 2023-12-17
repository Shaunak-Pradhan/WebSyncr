using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevPortal.Services
{
    public interface IReadFileService
    {
        List<string> FileExtensions();
        string ReadFile(string filename, List<string> fileExtensions);
        string ReadUsingID(string ID, string filename);
        string ReadFileUsingProp(string filetype, string fileid, string filename, string extenstion, string propertyid);
        
    }
}
