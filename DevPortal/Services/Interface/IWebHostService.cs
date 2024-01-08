using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevPortal.Services.Interface
{
    public interface IWebHostService
    {
        string Environment();
        string Directory(string PageName=null);
    }
}
