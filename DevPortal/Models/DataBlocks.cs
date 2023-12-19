using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Text;

namespace DevPortal.Models
{
    public class DataBlocks : BaseEntity
    {
        public int ID { set; get; }
        public string PropertyName { set; get; }
        public string PropertyValue { set; get; }
        public int TemplateID { set; get; }
        public bool IsHidden { set; get; }
        [ForeignKey("PageID")]
        public int PageID { set; get; }
        public int SectionID { set; get; }
        public string PreviousValue { set; get; }
        public string PropertyType { set; get; }
    }
}