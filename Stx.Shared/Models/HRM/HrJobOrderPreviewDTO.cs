using Stx.Shared.Core;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stx.Shared.Models.HRM
{
	/// <summary>
	/// This is used to show the detail of a single job. 
	/// This includes the current CandidateId to be used to submit the job, if the user opt to submit.
	/// </summary>
	[NotMapped]
	public class HrJobOrderPreviewDTO : BaseViewModel
	{
		private bool? _IsBookmarked = false;


		public int JobOrderID { get; set; }
		public int? CandidateID { get; set; }
		public string JobCode { get; set; }
		public string Title { get; set; }
		public short? Country { get; set; }
		public string Location { get; set; }
		public string Description { get; set; }
		public string Requirements { get; set; }
		public string Benefits { get; set; }
		public bool? IsShowSalary { get; set; } = false;
		public decimal? Salary { get; set; }
		public decimal? SalaryTo { get; set; }
		public string SalaryCurrCD { get; set; }
		public short? SalaryPayCycle { get; set; }
		public short? EmploymentType { get; set; }
		public int? JobIndustry { get; set; }
		public int? JobSpecialty { get; set; }
		public decimal? JobHoursPerWeek { get; set; }
		public int? NumOfAvilJobs { get; set; }
		public string FileAttachments { get; set; }
		//public decimal? MinYearsExpRequired { get; set; } = 0;
		//public short? MinCareerLevel { get; set; } = 0;
		//public short? MinEducationLevel { get; set; } = 0;
		public string Comments { get; set; }
		public string TravelRequirements { get; set; }
		public string CorporateContact { get; set; }
		public int? CorporateID { get; set; }
		public string CorporateAddress { get; set; }
		public string CorporateOperationHours { get; set; }
		public string ApplyByMobileNum { get; set; } //Mobile num to apply via sms or call 
		public string ApplyByEmail { get; set; } //Email addr to send applications 
		public short? JobPostPrivacy { get; set; }
		public DateTime? DateStart { get; set; }
		public DateTime? DateEnd { get; set; }
		public DateTime? DateClosed { get; set; }
		public DateTime? DateLastPublished { get; set; }
		public DateTime? DateAdded { get; set; }
		public string Status { get; set; }
		//public string ReportToName { get; set; }
		//public string ReportToClientContact { get; set; }
		public string CorporateName { get; set; }
		public string Address { get; set; }
		public string Address2 { get; set; }
		public string PostalCode { get; set; }
		public string City { get; set; }
		public string State { get; set; }
		public string Website { get; set; }
		public string Phone { get; set; }
		public short? Privacy { get; set; }
		public string CountryName { get; set; }
		public int? PrevSendoutID { get; set; }

		public bool? IsBookmarked
		{
			get { return this._IsBookmarked; }
			set
			{
				this._IsBookmarked = value;
				NotifyPropertyChanged();
			}
		}
		/// <summary>
		/// Get the company logo image's name. 
		/// </summary>
		public string LogoImgKey { get; set; }
		/// <summary>
		/// Non Mapped Dynamic Image Url field which uses to generated profile image Url. 
		/// </summary>
		[NotMapped]
		public string DynmcImageUrl { get; set; }

	}
}
