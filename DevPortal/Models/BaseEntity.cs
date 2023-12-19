using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;

namespace DevPortal.Models
{
    public class BaseEntity
    {
        [Required]
        public DateTime CreateDate { get; set; } = DateTime.Now;
        [Required]
        public DateTime UpdateDate { get; set; } = DateTime.Now;
        public int CreatedUser { get; set; }
        public string UpdatedUser { get; set; }
    }
}