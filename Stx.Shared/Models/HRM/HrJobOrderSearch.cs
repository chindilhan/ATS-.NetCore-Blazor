using Stx.Shared.Core;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stx.Shared.Models.HRM
{
	[NotMapped]
	public class HrJobOrderSearch : BaseViewModel
	{
		private bool? _IsBookmarked = false;
		private bool? _IsShowSalary = false;

		public int JobOrderID { get; set; }
		public string JobCode { get; set; }
		public string Title { get; set; }
		public string Country { get; set; }
		public string Location { get; set; }
		public string Description { get; set; }
		public string Requirements { get; set; }
		public string Benefits { get; set; }
		public bool? IsShowSalary
		{
			get { return this._IsShowSalary; }
			set
			{
				this._IsShowSalary = value;
				NotifyPropertyChanged();
			}
		}
		public decimal? Salary { get; set; }
		public decimal? SalaryTo { get; set; }
		public string SalaryCurrCD { get; set; }
		public string SalaryPayCycle { get; set; }
		public string EmploymentType { get; set; }
		public string JobIndustry { get; set; }
		public string JobSpecialty { get; set; }
		public decimal? JobHoursPerWeek { get; set; }
		public int? NumOfAvilJobs { get; set; }
		public string FileAttachments { get; set; }
		//public decimal? MinYearsExpRequired { get; set; }
		//public short? MinCareerLevel { get; set; }
		//public short? MinEducationLevel { get; set; }
		public string Comments { get; set; }
		public string TravelRequirements { get; set; }
		public int? CorporateID { get; set; }
		public string CorporateContact { get; set; }
		public string CorporateAddress { get; set; }
		public DateTime? DateStart { get; set; }
		public DateTime? DateEnd { get; set; }
		public string ApplyByEmail { get; set; }
		public string ApplyByMobileNum { get; set; }
		public string CorporateName { get; set; }
		public string Address { get; set; }
		public string Address2 { get; set; }
		public string PostalCode { get; set; }
		public string City { get; set; }
		public string State { get; set; }
		public string Website { get; set; }
		public string Phone { get; set; }
		public short? Privacy { get; set; }
		public string CorporateCountryName { get; set; }
		public int? ResumeSubmitCount { get; set; }
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
