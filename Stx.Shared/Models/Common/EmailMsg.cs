using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Stx.Shared.Models.Common
{
    [NotMapped]
    public class EmailMsg
    {
        public string Recipients { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string Attachments { get; set; }
    }
}