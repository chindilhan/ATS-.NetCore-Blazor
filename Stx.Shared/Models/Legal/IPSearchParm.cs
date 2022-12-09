using System;
using System.Collections.Generic;
using System.Text;

namespace Stx.Shared.Ips
{
    public class IPSearchParm
    {
        public short PageUID { get; set; }
        public string SearchMode { get; set; }
        public string FileNum { get; set; }
        public string DocCateg { get; set; }
        public string MatterType { get; set; }
        public string RecNum { get; set; }
        public string TitleOrTM { get; set; }
        public string Class { get; set; }
        public string PctNum { get; set; }
        public string DocStatus { get; set; }
        public DateTime? PriorityDate { get; set; }
        public DateTime? FillingDate { get; set; }
        public DateTime? RegDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public string ClientName { get; set; }
        public string SenderEmail { get; set; }
    }
}
