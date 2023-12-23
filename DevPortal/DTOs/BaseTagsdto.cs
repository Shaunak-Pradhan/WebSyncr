using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DevPortal.DTOs
{
    public class BaseTagsdto : Identifierdto
    {
        public string HTML { get; set; }
        public string Body { get; set; }
        public string Head { get; set; }
        public string Footer { get; set; }
        public string Section { get; set; }
        public string Title { get; set; }
        public string Paragraph1 { get; set; }
        public string Paragraph2 { get; set; }
        public string Paragraph3 { get; set; }
        public string Paragraph4 { get; set; }
        public string Heading1 { get; set; }
        public string Heading2 { get; set; }
        public string Heading3 { get; set; }
        public string Heading4 { get; set; }
        public string Anchor { get; set; }
        public string Image { get; set; }
        public string List { get; set; }
        public string Table { get; set; }
        public string Form { get; set; }
        public string Input { get; set; }
        public string Button { get; set; }
        public string Keywords { get; set; }
        public string Description { get; set; }
        public string GoogleFontLink { get; set; }
        public string JsonLD { get; set; }
        public string ThemeColor { get; set; }
        public string OgTitle { get; set; }
        public string OgType { get; set; }
        public string HomePage { get; set; }
        public string HomePageTitle { get; set; }
        public string BodyClass { get; set; }
        public string Language { get; set; }
    }
}