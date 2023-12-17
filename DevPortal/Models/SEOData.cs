using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DevPortal.Models
{
    public class SEOData
    {
        public class ApiResponse
        {
            public string Title { get; set; }
        }
        public class OptimizationResult
        {
            public int Points { get; set; }
            public string Summary { get; set; }
        }
    }
}