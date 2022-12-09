using System;
using System.Collections.Generic;
using System.Text;

namespace Stx.Shared.Ips
{
    public class IPTrademarkSearchResultDto
    {
		public string ProximityPCT { get; set; }
		public int? FileNum { get; set; }
		public int? DocNum { get; set; }
		public string RecNum { get; set; }
		public string TitleOrTM { get; set; }
		public string ImagePath { get; set; }
		public string ImageDesc { get; set; }
		public string ClassId { get; set; }
		public string ClassName { get; set; }
		public short? DocStatus { get; set; }
		public string DocStatusDesc { get; set; }
		public string ClientCode { get; set; }
		public string ClientName { get; set; }
		public string DocCateg { get; set; }
		public short? MatterType { get; set; }
		public string MatterTypeDesc { get; set; }
		public string DatePriority { get; set; }
		public DateTime? DateFilling { get; set; }
		public DateTime? DateReg { get; set; }
		public DateTime? DateExpiry { get; set; }
		public string StatusColor { get; set; }
	}
}
