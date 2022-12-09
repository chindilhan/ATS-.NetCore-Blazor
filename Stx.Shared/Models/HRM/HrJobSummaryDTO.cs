using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stx.Shared.Models.HRM
{
	[NotMapped]
	public class HrJobSummaryDTO
	{
		public int CorporateID { get; set; }
		public int JobOrderID { get; set; }
		public string JobCode { get; set; }
		public string Title { get; set; }
		public short Country { get; set; }
		public string CountryName { get; set; }
		public string Location { get; set; }
		public string Description { get; set; }
		public string Requirements { get; set; }
		public string Benefits { get; set; }
		public short? EmploymentType { get; set; }
		public int? JobIndustry { get; set; }
		public string JobIndustryName { get; set; }
		public int? JobSpecialty { get; set; }
		public int? NumOfAvilJobs { get; set; }
		public string TravelRequirements { get; set; }
		public string CorporateContact { get; set; }
		public DateTime? DateStart { get; set; }
		public DateTime? DateEnd { get; set; }
		public string ApplyByEmail { get; set; }
		public string ApplyByMobileNum { get; set; }
		public bool? IsDeleted { get; set; }
		public string Status { get; set; }
		public int? SourcedCount { get; set; }
		public int? AppliedCount { get; set; }
		public int? PhoneScreenCount { get; set; }
		public int? InterviewCount { get; set; }
		public int? OfferCount { get; set; }
		public int? HiredCount { get; set; }
		public DateTime? DateLastApplied { get; set; }


	}
}
