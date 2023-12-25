using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace DevPortal.Services.Interface
{
    public interface ITemplateService
    {
        void BindTemplate(int TemplateID, string PageName, string DisplayName, string extension);
        void SwitchTemplate(string selectedValue, string PID, string TemplateName, GridView gridview);
        void CustomTemplateHTML(int TemplateID, string filename);
    }
}
