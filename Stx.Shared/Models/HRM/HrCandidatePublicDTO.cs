using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stx.Shared.Models.HRM
{
	[NotMapped]
	public class HrCandidatePublicDTO
	{
		public int CandidateID { get; set; }
		public string UserName { get; set; }
		public string FirstName { get; set; }
		public string MiddleName { get; set; }
		public string LastName { get; set; }
		public string NickName { get; set; }
		public string Gender { get; set; }
		//public string NamePrefix { get; set; }
		//public string NameSuffix { get; set; }
		public short? Nationality { get; set; }
		public string Mobile { get; set; }
		public string Phone { get; set; }
		public string Phone2 { get; set; }
		public string WorkPhone { get; set; }
		public string Email { get; set; }
		public string Email2 { get; set; }
		public string Fax { get; set; }
		//public string Fax2 { get; set; }
		public string Address { get; set; }
		public string PostalCode { get; set; }
		//public string SecondaryAddress { get; set; }
		public string CountryName { get; set; }
		public string City { get; set; }
		public string MaritalStatus { get; set; }
		public DateTime? DateOfBirth { get; set; }
		public DateTime? DateAvailable { get; set; }
		public DateTime? DateLastComment { get; set; }
		public DateTime? DateLastModified { get; set; }
		public DateTime? DateNextCall { get; set; }
		public int? TimeZoneOffsetEST { get; set; }
		public bool? Active { get; set; }
		public string Disability { get; set; }
		public string CandidateSource { get; set; }
		public int? JobOrderID { get; set; }
		public string CurrentJob { get; set; }
		public int? TotalExperience { get; set; }		
		public string Education { get; set; }
		public string ExpectedJobs { get; set; }
		public decimal? ExpectedSalary { get; set; }
		public string SummaryDesc { get; set; }
		public string ProfileImgKey { get; set; }

		/// <summary>
		/// Non Mapped Dynamic Image Url field which uses to generated profile image Url. 
		/// </summary>
		[NotMapped]
		public string DynmcImageUrl { get; set; }
	}
}
