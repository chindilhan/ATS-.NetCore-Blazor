using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stx.Shared.Models.CRM
{
	/// <summary>
	/// Corporate details (public details) transfer object (DTO)
	/// This returns all related info for a selected corporate entity.
	/// SP used to retreive data: CRMCorporatePreview
	/// </summary>
	[NotMapped]
	public class CorporatePublicDTO
	{
		public int CorporateID { get; set; }
		public string UserName { get; set; }
		public string CorporateType { get; set; }
		public string CorporateGroup { get; set; }
		public string Name { get; set; }
		public string ShortName { get; set; }
		public string LegalType { get; set; }
		public string Category { get; set; }
		public string Address { get; set; }
		public string Address2 { get; set; }
		public string PostalCode { get; set; }
		public string City { get; set; }
		public string State { get; set; }
		public short CountryID { get; set; }
		public short Nationality { get; set; }
		public string Website { get; set; }
		public string Phone { get; set; }
		public string Phone2 { get; set; }
		public string Mobile { get; set; }
		public string Fax { get; set; }
		public string Email { get; set; }
		public string Email2 { get; set; }
		public string CurrCD { get; set; }
		public string Remarks { get; set; }
		public string Reference1 { get; set; }
		public string Reference2 { get; set; }
		public string Reference3 { get; set; }
		public string RefObject { get; set; }
		public string CompanyLawyers { get; set; }
		public string CommercialRegInfo { get; set; }
		public string CommercialRegNum { get; set; }
		public short? Privacy { get; set; }
		public string Source { get; set; }
		public string ImportRef { get; set; }
		public DateTime DateAdded { get; set; }
		public DateTime DateLastModified { get; set; }
		public string CountryName { get; set; }

	}
}
