using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DevPortal.DTOs
{
    public class Placeholderdto : BaseTagsdto
    {
        public string TemplateName { get; set; }
        public string WebsiteName { get; set; }
        public string ContactNo { get; set; }
    }
}