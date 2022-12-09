using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stx.Shared.Models.CRM
{
	/// <summary>
	/// This returns all related info for a selected corporate entity.
	/// </summary>
	[NotMapped]
	public class CorporateDTO
	{
		//>>copid flds are from JO are wrong; add correct flds;
		public int JobOrderID { get; set; }
		public int CandidateID { get; set; }
		public string JobCode { get; set; }
		public string Title { get; set; }
		public string Country { get; set; }
		public string Location { get; set; }
		public string Description { get; set; }
		public string Requirements { get; set; }
		public string Benefits { get; set; }
		public bool? IsShowSalary { get; set; } = false;
		public decimal? Salary { get; set; }
		public decimal? SalaryTo { get; set; }
		public string SalaryCurrCD { get; set; }
		public string SalaryUnit { get; set; }
		public string EmploymentType { get; set; }
		public string JobIndustry { get; set; }
		public string JobSpecialty { get; set; }
		public decimal? JobHoursPerWeek { get; set; }
		public int? NumOfAvilJobs { get; set; }
		public string FileAttachments { get; set; }
		public decimal? MinYearsExpRequired { get; set; } = 0;
		public short? MinExperienceLevel { get; set; } = 0;
		public short? MinEducationLevel { get; set; } = 0;
		public string Comments { get; set; }
		public string TravelRequirements { get; set; }
		public string CorporateContact { get; set; }
		public int CorporateID { get; set; }
		public string CorporateAddress { get; set; }
		public string CorporateOperationHours { get; set; }
		public string ApplyByMobileNum { get; set; } //Mobile num to apply via sms or call 
		public string ApplyByEmail { get; set; } //Email addr to send applications 
		public int? JobPostPrivacy { get; set; }
		public DateTime? DateStart { get; set; }
		public DateTime? DateEnd { get; set; }
		public DateTime? DateClosed { get; set; }
		public DateTime? DateLastPublished { get; set; }
		public DateTime? DateAdded { get; set; }
		public string Status { get; set; }
		public string ReportToName { get; set; }
		public string ReportToClientContact { get; set; }
		public string CorporateName { get; set; }
		public string Address { get; set; }
		public string Address2 { get; set; }
		public string PostalCode { get; set; }
		public string City { get; set; }
		public string State { get; set; }
		public string Website { get; set; }
		public string Phone { get; set; }
		public string Privacy { get; set; }
		public string CountryName { get; set; }
		public int? PrevSendoutID { get; set; }

	}
}
