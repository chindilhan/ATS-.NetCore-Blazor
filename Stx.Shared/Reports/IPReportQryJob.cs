using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Stx.Shared.Reports
{
	[NotMapped]
	public class IPReportQryJob
	{
		public int DocNum { get; set; }
		public int? FileNum { get; set; }
		public short? MatterType { get; set; }
		public string ApplcNum { get; set; }
		public string Desc { get; set; }
		public string PctNum { get; set; }
		public short? RecStatus { get; set; }
		public string PriorityDetail { get; set; }
		public string DatePriority { get; set; }
		public DateTime? DateFiling { get; set; }
		public DateTime? DateReg { get; set; }
		public DateTime? DateExpire { get; set; }
		public string BPCode { get; set; }
		public string BPName { get; set; }
		public string BPAddrs { get; set; }
		public string BPEmail { get; set; }
		public string BPPhone { get; set; }
		public string BPFax { get; set; }
		public string JobSrcSender { get; set; }
		public string JobSrcEmail { get; set; }
		public string JobSrcCC { get; set; }
		public DateTime? JobSrcDate { get; set; }
		public string InvNum { get; set; }
		public DateTime? InvDate { get; set; }
		public decimal? InvAmt { get; set; }
		public string Ref1 { get; set; }
		public string Ref2 { get; set; }
		public string Ref3 { get; set; }
		public string DocStatusDesc { get; set; }
		public string DocStatusColor { get; set; }
		public string MatterTypeDesc { get; set; }
		public string Ref1Title { get; set; }
		public string Ref2Title { get; set; }
		public string Ref3Title { get; set; }
		public DateTime? CreatedOn { get; set; }
		public string CreatedBy { get; set; }
		public DateTime? ModifiedOn { get; set; }
		public string ModifiedBy { get; set; }
		public string TerminalID { get; set; }
		public string SessionID { get; set; }

	}
}
