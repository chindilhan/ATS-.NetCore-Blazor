using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Stx.Shared.Models.Common
{
    [Table("EmailTemplate")]
    public class EmailTemplate
    {
        public string TemplateID { get; set; }
        public string TemplateCatg { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public string Options { get; set; }
    }
}