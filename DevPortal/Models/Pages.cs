using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DevPortal.Models
{
    public class Pages : BaseEntity
    {
        public int PID { set; get; }
        public string PageName { set; get; }
        public string DisplayName { set; get; }
        public int TemplateID { set; get; }
        public string TemplateName { set; get; }
        public string PageURL { set; get; }
        public string EditLink { set; get; }

    }
}