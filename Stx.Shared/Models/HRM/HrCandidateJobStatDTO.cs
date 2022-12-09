using Stx.Shared.Core;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stx.Shared.Models.HRM
{
	[NotMapped]
	public class HrCandidateJobStatDTO: BaseViewModel
	{
		private bool? _IsBookmarked;
		private bool? _IsShowSalary;

		public int CandidateID { get; set; }
		public int JobOrderID { get; set; }
		public string JobCode { get; set; }
		public string Title { get; set; }
		public string Country { get; set; }
		public string Location { get; set; }
		public string Description { get; set; }
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
		public DateTime? DateStart { get; set; }
		public DateTime? DateEnd { get; set; }
		public string CorporateName { get; set; }
		public string CorporateCountryName { get; set; }
		public bool? IsBookmarked
		{
			get { return this._IsBookmarked; }
			set
			{
				this._IsBookmarked = value;
				NotifyPropertyChanged();
			}
		}
		

	}
}
