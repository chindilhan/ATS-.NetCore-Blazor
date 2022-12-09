using Stx.Shared.Status;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stx.Shared.Ips
{
    public class IPTrademark
	{
		[NotMapped]
		public EntryState State { get; set; } = EntryState.Unset;
		public int TenantID { get; set; }
		public int TrademarkID { get; set; }
		public int FileNum { get; set; }
		public string TMNum { get; set; }
		public string TMWord { get; set; }
		public string TMLogoName { get; set; }
		public string TMLogoFile { get; set; }
		public string ClassID { get; set; }
		public short TMStatus { get; set; }
		public string TMTranslation { get; set; }
		public string ClaimingColor { get; set; }
		public string GoodsNServcs { get; set; }
		public short MatterType { get; set; }
		public string SimilarSounds { get; set; }
		public string BPCode { get; set; }
		public string BPName { get; set; }
		public string BPAddrs { get; set; }
		public string BPPhone { get; set; }
		public string BPEmail { get; set; }
		public string BPFax { get; set; }
		public DateTime? DateFiling { get; set; }
		public DateTime? DateReg { get; set; }
		public DateTime? DateExpire { get; set; }
		public DateTime? DatePriority { get; set; }
		public string PriorityDetail { get; set; }
		public string TMRef1 { get; set; }
		public string TMRef2 { get; set; }
		public string TMRef3 { get; set; }
		public string JobSrcSender { get; set; }
		public string JobSrcEmail { get; set; }
		public string JobSrcCC { get; set; }
		public DateTime? JobSrcDate { get; set; }
		public string InvNum { get; set; }
		public DateTime? InvDate { get; set; }
		public decimal InvAmt { get; set; }
		public bool? Active { get; set; } = true;
		public short PageUid { get; set; }
		public string TerminalID { get; set; }
		public DateTime? CreatedOn { get; set; }
		public string CreatedBy { get; set; }
		public DateTime? ModifiedOn { get; set; }
		public string ModifiedBy { get; set; }
		public DateTime? ImportedOn { get; set; }
		public string ImportRef { get; set; }
		public string SessionID { get; set; }

	}
}
