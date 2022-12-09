using System;
using System.Collections.Generic;
using System.Text;

namespace Stx.Shared.Ips
{
    public class IPJobSearchResultDto
    {
		public string ProximityPCT { get; set; }
		public int? FileNum { get; set; }
		public string RecNum { get; set; }
		public string PctNum { get; set; }
		public string TitleOrTM { get; set; }
		public short? MatterType { get; set; }
		public string MatterTypeDesc { get; set; }
		public short? DocStatus { get; set; }
		public string DocStatusDesc { get; set; }
		public string ImagePath { get; set; }
		public string ImageDesc { get; set; }
		public string ClassId { get; set; }
		public string ClassName { get; set; }
		public string ClientCode { get; set; }
		public string ClientName { get; set; }
		public short? DocCateg { get; set; }
		public string JobSrcSender { get; set; }
		public string JobSrcEmail { get; set; }
		public string JobSrcCC { get; set; }
		public DateTime? JobSrcDate { get; set; }
		public string InvNum { get; set; }
		public DateTime? InvDate { get; set; }
		public decimal? InvAmt { get; set; }
		public string JobRef1 { get; set; }
		public string JobRef2 { get; set; }
		public string JobRef3 { get; set; }
		public bool? Active { get; set; }
		public string PriorityDetail { get; set; }
		public string DatePriority { get; set; }
		public DateTime? DateFilling { get; set; }
		public DateTime? DateReg { get; set; }
		public DateTime? DateExpiry { get; set; }
		public DateTime? ModifiedOn { get; set; }
		public string ModifiedBy { get; set; }
		public string StatusColor { get; set; }

	}
}
