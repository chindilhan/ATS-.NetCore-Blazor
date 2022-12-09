using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stx.Shared.Models.CRM
{
	[Table("Corporate")]
	public class Corporate
	{
		public int CorporateID { get; set; }
		[StringLength(256)]
		public string UserName { get; set; }
		[StringLength(10)]
		public string CorporateType { get; set; }
		[StringLength(20)]
		public string CorporateGroup { get; set; }
		[StringLength(100)]
		public string Name { get; set; }
		[StringLength(50)]
		public string ShortName { get; set; }
		[StringLength(30)]
		public string LegalType { get; set; }
		[StringLength(30)]
		public string Category { get; set; }
		[StringLength(200)]
		public string Address { get; set; }
		[StringLength(200)]
		public string Address2 { get; set; }
		[StringLength(10)]
		public string PostalCode { get; set; }
		[StringLength(50)]
		public string City { get; set; }
		[StringLength(50)]
		public string State { get; set; }
		public short? CountryID { get; set; }
		public short? Nationality { get; set; }
		[StringLength(100)]
		public string Website { get; set; }
		[StringLength(30)]
		public string Phone { get; set; }
		[StringLength(30)]
		public string Phone2 { get; set; }
		[StringLength(30)]
		public string Mobile { get; set; }
		[StringLength(30)]
		public string Fax { get; set; }
		[StringLength(100)]
		public string Email { get; set; }
		[StringLength(100)]
		public string Email2 { get; set; }
		[StringLength(3)]
		public string CurrCD { get; set; }
		[StringLength(3000)]
		public string Remarks { get; set; }
		[StringLength(100)]
		public string Reference1 { get; set; }
		[StringLength(100)]
		public string Reference2 { get; set; }
		[StringLength(100)]
		public string Reference3 { get; set; }
		public string RefObject { get; set; }
		[StringLength(500)]
		public string CompanyLawyers { get; set; }
		[StringLength(200)]
		public string CommercialRegInfo { get; set; }
		[StringLength(100)]
		public string CommercialRegNum { get; set; }
		public bool? Active { get; set; }
		public bool? IsDeleted { get; set; }
		public short? Privacy { get; set; }
		[StringLength(30)]
		public string Source { get; set; }
		[StringLength(50)]
		public string ImportRef { get; set; }
		[StringLength(100)]
		public string UserAdded { get; set; }
		[StringLength(100)]
		public string UserModified { get; set; }
		public DateTime? DateAdded { get; set; }
		public DateTime? DateLastModified { get; set; }
		public string LogoImgKey { get; set; }
		public string LogoThumbImgKey { get; set; }

		/// <summary>
		/// Non Mapped Dynamic Image Url field which uses to generated profile image Url. 
		/// </summary>
		[NotMapped]
		public string DynmcImageUrl { get; set; }
	}
}
