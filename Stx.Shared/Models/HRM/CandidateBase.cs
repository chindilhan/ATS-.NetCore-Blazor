using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stx.Shared.Models.HRM
{
	[NotMapped]
	public class CandidateBase
	{
		//public int CandidateID { get; set; }
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
		public short? Nationality { get; set; }
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
		[StringLength(10)]
		public string PostalCode { get; set; }
		[StringLength(50)]
		public string City { get; set; }
		public short? CountryID { get; set; }
		[StringLength(800)]
		public string SecondaryAddress { get; set; }
		public short? JobIndustry { get; set; }
		/*
		public string Category { get; set; }
		public string Categories { get; set; }
		public string Certifications { get; set; }
		*/
		[StringLength(6)]
		public string ExperienceLevel { get; set; } //W_2007|Fresh|Student
		[StringLength(100)]
		public string CurrOccupation { get; set; }
		[StringLength(100)]
		public string CurrCompanyName { get; set; }
		[StringLength(150)]
		public string CurrCompanyURL { get; set; }
		public decimal? ExpectedSalary { get; set; }
		public decimal? ExpectedSalaryLow { get; set; }
		[StringLength(100)]
		public string PreferredLocations { get; set; }
		[StringLength(30)]
		public string HighestEduLevel { get; set; } //phd|master|degree
		[StringLength(4000)]
		public string SkillSetDesc { get; set; }
		[StringLength(500)]
		public string PrimarySkills { get; set; }
		[StringLength(500)]
		public string SecondarySkills { get; set; }
		[StringLength(200)]
		public string Specialties { get; set; }
		[StringLength(3000)]
		public string Description { get; set; }
		[StringLength(3000)]
		public string Comments { get; set; }
		public int? TotalExperience { get; set; }
		[StringLength(6)]
		public string MaritalStatus { get; set; }
		public DateTime? DateOfBirth { get; set; }
		public DateTime DateAdded { get; set; }
		[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0: dd/MM/yyyy}")]
		public DateTime? DateAvailable { get; set; }
		[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
		public DateTime? DateLastComment { get; set; }
		[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0: dd/MM/yyyy}")]
		public DateTime? DateLastModified { get; set; }
		[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0: dd/MM/yyyy}")]
		public DateTime? DateNextCall { get; set; }
		public int? TimeZoneOffsetEST { get; set; }
		[StringLength(50)]
		public string PreferredContactModes { get; set; }
		[StringLength(10)]
		public string JobSearchingMode { get; set; }
		public bool? IsMassMailOptOut { get; set; }
		public bool? IsSmsOptIn { get; set; }
		public bool? IsWhatsappOptIn { get; set; }
		public bool? IsMessengerOptIn { get; set; }
		public bool? Active { get; set; }
		public bool? IsEditable { get; set; }
		public bool? IsDeleted { get; set; }
		public short? Privacy { get; set; }
		public bool? IsExempt { get; set; }
		[StringLength(100)]
		public string ExternalID { get; set; }
		[StringLength(50)]
		public string EmploymentPreference { get; set; }
		[StringLength(20)]
		public string Disability { get; set; }
		[StringLength(30)]
		public string LinkedCorpContact { get; set; } //Corporate
		[StringLength(50)]
		public string Owner { get; set; }
		[StringLength(20)]
		public string OnboardingStatus { get; set; }
		[StringLength(20)]
		public string Placements { get; set; }
		public string ProfileImgKey{ get; set; }
		public string ProfileThumbImgKey { get; set; }


		/// <summary>
		/// Non Mapped Dynamic Image Url field which uses to generated profile image Url. 
		/// </summary>
		[NotMapped]
		public string DynmcImageUrl { get; set; }
	}
}
