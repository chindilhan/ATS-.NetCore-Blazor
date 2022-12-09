using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stx.Shared.Models.HRM
{
	[NotMapped]
	public class HrJobSummaryMinDTO
	{
		public bool Selected { get; set; }
		public int CorporateID { get; set; }
		public int JobOrderID { get; set; }
		public string Title { get; set; }
		public short Country { get; set; }
		public string Location { get; set; }
		public string Description { get; set; }
		public short? EmploymentType { get; set; }
		public int? JobIndustry { get; set; }
		public int? JobSpecialty { get; set; }
		public DateTime? DateStart { get; set; }
		public DateTime? DateEnd { get; set; }
		public string Status { get; set; }
		//public string Stage { get; set; }
	}
}
