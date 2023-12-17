using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevPortal.Services.Interface
{
    public interface IPrompterService
    {
        void Compiler(string html);
        Dictionary<string, string> ExtractData(string html);
        Task<string> GetHtmlAsync(string url);
        Task ChatGPT(string prompt);
    }
}
