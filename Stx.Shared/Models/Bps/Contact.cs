using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stx.Shared.Bps
{
	[Table("Contact")]
	public class Contact
	{
		public short CompanyID { get; set; }
		public int DocNum { get; set; }
		public int ContactID { get; set; }
		public string ContactGroup { get; set; }
		public string Title { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string OtherNames { get; set; }
		public string Category { get; set; }
		public string Company { get; set; }
		public string JobTitle { get; set; }
		public string Email { get; set; }
		public string Home { get; set; }
		public string Mobile { get; set; }
		public string Office { get; set; }
		public string LowyerType { get; set; }
		public string Website { get; set; }
		public string Fax { get; set; }
		public string Address { get; set; }
		public string City { get; set; }
		public string State { get; set; }
		public string Country { get; set; }
		public string Zip { get; set; }
		public string Gender { get; set; }
		public byte DocStatus { get; set; }
		public string Reference1 { get; set; }
		public string Reference2 { get; set; }
		public string Reference3 { get; set; }
		public string RefObject { get; set; }
		public string Nationality { get; set; }
		public string ForeignName { get; set; }
		public DateTime? DOB { get; set; }
		public string IC { get; set; }
		public string Notes { get; set; }
		public string Privacy { get; set; }
		public decimal? DynmCurrBalance { get; set; }
		public decimal? DynmDueBalance { get; set; }
		public decimal? DynmPaidAmt { get; set; }
		public decimal? DynmBillableAmt { get; set; }
		public DateTime? CreatedOn { get; set; }
		public string CreatedBy { get; set; }
		public DateTime? ModifiedOn { get; set; }
		public string ModifiedBy { get; set; }
		public string ImportRef { get; set; }
		public string SessionID { get; set; }

	}
}
