using Stx.Shared.Status;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stx.Shared
{
    [Table("IPMatter")]
    public class IPMatter
	{
		[NotMapped]
		public EntryState State { get; set; } = EntryState.Unset;
		public int TenantID { get; set; }
		public int MatterID { get; set; }
		public short? CompanyID { get; set; }
		public string MatterName { get; set; }
		public string MatterDesc { get; set; }
		public short MatterType { get; set; }
		public string ClientID { get; set; }
		public string ClientName { get; set; }
		public string RequestedBy { get; set; }
		public string OriginatedBy { get; set; }
		public string AssignedBy { get; set; }
		public string AssignedTo { get; set; }
		public DateTime? DateReceived { get; set; }
		public DateTime? DateFiled { get; set; }
		public DateTime? DateDue { get; set; }
		public DateTime? DateClosed { get; set; }
		public byte Status { get; set; }
		public short? MatterStatus { get; set; }
		public byte MatterPriority { get; set; }
		public string MatterFileNum { get; set; }
		public decimal? MatterValue { get; set; }
		public string EstimatedEffort { get; set; }
		public string Privacy { get; set; }
		public string RateType { get; set; }
		public decimal? Rate { get; set; }
		public decimal? ContngncyRatePct { get; set; }
		public decimal? DynmPaidAmt { get; set; }
		public decimal? DynmBillableAmt { get; set; }
		public string CaseNumber { get; set; }
		public string BillingMethod { get; set; }
		public string MatterHandler { get; set; }
		public string MatterHandlerLead { get; set; }
		public short? SrcModule { get; set; }
		public string ImportRef { get; set; }
		public string CreatedBy { get; set; }
		public DateTime? CreatedOn { get; set; }
		public string ModifiedBy { get; set; }
		public DateTime? ModifiedOn { get; set; }

	}
}
