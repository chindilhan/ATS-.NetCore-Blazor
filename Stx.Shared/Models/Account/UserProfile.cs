using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stx.Shared.Models.HRM
{
	[Table("UserProfile")]
	public class UserProfile
	{

		[StringLength(256)]
		public string UserName { get; set; }
		[StringLength(100)]
		public string FirstName { get; set; }
		[StringLength(100)]
		public string MiddleName { get; set; }
		[StringLength(100)]
		public string LastName { get; set; }
		[StringLength(50)]
		public string NickName { get; set; }
		[StringLength(1)]
		public string Gender { get; set; }
		[StringLength(6)]
		public string NamePrefix { get; set; }
		[StringLength(6)]
		public string NameSuffix { get; set; }
		[StringLength(20)]
		public string Mobile { get; set; }
		[StringLength(20)]
		public string Phone { get; set; }
		[StringLength(20)]
		public string Phone2 { get; set; }
		[StringLength(20)]
		public string WorkPhone { get; set; }
		[StringLength(150)]
		public string Email { get; set; }
		[StringLength(150)]
		public string Email2 { get; set; }
		[StringLength(20)]
		public string Fax { get; set; }
		[StringLength(20)]
		public string Fax2 { get; set; }
		[StringLength(200)]
		public string Address { get; set; }
		[StringLength(200)]
		public string Address2 { get; set; }
		public short? CountryID { get; set; }
		public short? Nationality { get; set; }
		[StringLength(800)]
		public string SecondaryAddress { get; set; }
		[StringLength(10)]
		public string PostalCode { get; set; }
		[StringLength(50)]
		public string City { get; set; }
		[StringLength(3000)]
		public string Comments { get; set; }
		[StringLength(6)]
		public string MaritalStatus { get; set; }
		public DateTime? DateOfBirth { get; set; }
		public DateTime DateAdded { get; set; }
		public DateTime? DateLastModified { get; set; }
		public int? TimeZoneOffsetEST { get; set; }
		[StringLength(50)]
		public bool? Active { get; set; }
		public bool? IsEditable { get; set; }
		public bool? IsDeleted { get; set; }
		public bool? IsRegistered { get; set; }
		public bool? IsCandidate { get; set; }
		public bool? IsCorporateUser { get; set; }
		public short? Privacy { get; set; }
	}
}
