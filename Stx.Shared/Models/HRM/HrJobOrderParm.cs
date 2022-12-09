using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stx.Shared.Models.HRM
{
	[NotMapped]
	public class HrJobOrderParm
	{
		public int JobOrderID { get; set; }
		[StringLength(50)]
		public string JobCode { get; set; }
		[StringLength(100)]
		public string Title { get; set; }
		[StringLength(100)]
		public string Country { get; set; }
		[StringLength(100)]
		public string Location { get; set; }
		[StringLength(3000)]
		public string Description { get; set; }
		[StringLength(3000)]
		public string Requirements { get; set; }
		[StringLength(3000)]
		public string Benefits { get; set; }
		public decimal? Salary { get; set; }
		public decimal? SalaryTo { get; set; }
		[StringLength(3)]
		public string SalaryCurrCD { get; set; }
		[StringLength(1)]
		public string SalaryUnit { get; set; } //Y|M|W|D
		public bool IsShowSalary { get; set; }
		[StringLength(15)]
		public string EmploymentType { get; set; }
		[StringLength(100)]
		public string JobIndustry { get; set; }
		[StringLength(100)]
		public string JobSpecialty { get; set; }
		public double? JobHoursPerWeek { get; set; }
		public int NumOfAvilJobs { get; set; }
		public decimal? MinYearsExpRequired { get; set; }
		public short? MinExperienceLevel { get; set; } //Not applicable, Internship, Entry Level, Associate, Mid-Senior level, executive, director
		public short? MinEducationLevel { get; set; } //Not applicable, Degree, Deploma, Certificate, 
		public decimal? Latitude { get; set; } //GPS Latitude
		public decimal? Longitude { get; set; } //GPS Longitude
		[StringLength(100)]
		public string Comments { get; set; }
		[StringLength(200)]
		public string TravelRequirements { get; set; }
		[StringLength(100)]
		public string FileAttachments { get; set; }
		public int CorporateID { get; set; } //Company
		[StringLength(30)]
		public string CorporateContact { get; set; }
		[StringLength(500)]
		public string CorporateAddress { get; set; }
		[StringLength(50)]
		public string CorporateOperationHours { get; set; }
		[StringLength(30)]
		public string ApplyByMobileNum { get; set; } //Mobile num to apply via sms or call 
		[StringLength(100)]
		public string ApplyByEmail { get; set; } //Email addr to send applications 
		[StringLength(6)]
		public string PostingJobBy { get; set; } //O-Owner | A-Agency 
		public short? JobPostPrivacy { get; set; }
		public bool IsDeleted { get; set; }
		public bool? Active { get; set; }
		public bool? IsInterviewRequired { get; set; }
		public bool? IsJobcastPublished { get; set; }
		[StringLength(50)]
		public string JobOrderIntegrations { get; set; }
		public DateTime DateStart { get; set; }
		public DateTime? DateEnd { get; set; }
		public DateTime? DateClosed { get; set; }
		public DateTime? DateLastPublished { get; set; }
		public DateTime DateAdded { get; set; }
		public DateTime? DateLastModified { get; set; }
		[StringLength(20)]
		public string Status { get; set; }
		[StringLength(50)]
		public string ReasonClosed { get; set; }
		[StringLength(100)]
		public string JobPostSource { get; set; }
		[StringLength(100)]
		public string ReportToName { get; set; }
		[StringLength(100)]
		public string ReportToClientContact { get; set; }
		[StringLength(200)]
		public string AssignedUsers { get; set; }
		[StringLength(100)]
		public string ExternalID { get; set; }
		public bool IsBillable { get; set; }
		[StringLength(100)]
		public string BillingProfile { get; set; }
		public decimal? BillingRate { get; set; }



	}
}
