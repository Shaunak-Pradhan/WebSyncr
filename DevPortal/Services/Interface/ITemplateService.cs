using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevPortal.Services.Interface
{
    public interface ITemplateService
    {
        void CustomTemplateHTML(int TemplateID, string filename);
        void BindTemplate(int TemplateID, string PageName, string DisplayName, string extension);
    }
}
