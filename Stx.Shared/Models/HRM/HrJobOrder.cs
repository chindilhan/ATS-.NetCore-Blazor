using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stx.Shared.Models.HRM
{
	[Table("HrJobOrder")]
	public class HrJobOrder
	{
		public int JobOrderID { get; set; }
		[StringLength(50)]
		public string JobCode { get; set; }
		[StringLength(100)]
		public string Title { get; set; }
		public short Country { get; set; }
		[StringLength(100)]
		public string Location { get; set; }
		[StringLength(3000)]
		public string Description { get; set; }
		[StringLength(3000)]
		public string Requirements { get; set; }
		[StringLength(3000)]
		public string Benefits { get; set; }
		[StringLength(100)]
		public string Comments { get; set; }
		[StringLength(200)]
		public string TravelRequirements { get; set; }
		public decimal? Salary { get; set; }
		public decimal? SalaryTo { get; set; }
		[StringLength(3)]
		public string SalaryCurrCD { get; set; }
		public short SalaryPayCycle { get; set; } //Y|M|W|D>short
		public bool IsShowSalary { get; set; }		
		public int? JobIndustry { get; set; }
		public int? JobSpecialty { get; set; }
		public double? JobHoursPerWeek { get; set; }
		public int NumOfAvilJobs { get; set; }
		public short? EmploymentType { get; set; }  //Full-time, parttime
		//public decimal? MinYearsExpRequired { get; set; }
		//public short? MinCareerLevel { get; set; } //Not applicable, Internship, Entry Level, Associate, Mid-Senior level, executive, director
		//public short? MinEducationLevel { get; set; } //Not applicable, Degree, Deploma, Certificate, 
		public decimal? Latitude { get; set; } //GPS Latitude
		public decimal? Longitude { get; set; } //GPS Longitude
		[StringLength(100)]
		public string FileAttachments { get; set; }
		public int CorporateID { get; set; } //Company ID
		[StringLength(100)]
		public string CorporateName { get; set; } //Company Name
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
		//public bool? Active { get; set; }
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

		[StringLength(50)]
		public string UserAdded{ get; set; }
		[StringLength(50)]
		public string UserModified { get; set; }
		[StringLength(20)]
		public string Status { get; set; }
		[StringLength(50)]
		public string ReasonClosed { get; set; }
		[StringLength(100)]
		public string JobPostSource { get; set; }
		/// <summary>
		/// Job Application method.
		/// E - Email, W - Web Address, P - Phone
		/// </summary>
		[StringLength(1)]
		public string ApplyMethod { get; set; } = "E";
		/// <summary>
		/// Value of the job Application method.
		/// [Email address], [web address] or [phone number]
		/// </summary>
		[StringLength(600)]
		public string ApplyMethodValue { get; set; }
		public bool IsReqAutoRejectEmail { get; set; }
		[StringLength(800)]
		public string AutoRejectEmailTemplate { get; set; }
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
