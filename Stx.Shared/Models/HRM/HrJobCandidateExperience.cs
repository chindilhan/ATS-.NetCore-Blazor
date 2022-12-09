using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stx.Shared.Models.HRM
{
	[Table("HrJobCandidateExperience")]
	public class HrJobCandidateExperience
	{
		public int ID { get; set; }
		public int JobCandidateID { get; set; }
		[StringLength(100)]
		public string Title { get; set; }
		[StringLength(100)]
		public string CompanyName { get; set; }
		public int? CorporateID { get; set; }
		[StringLength(50)]
		public string Country { get; set; }
		public DateTime? DateStart { get; set; }
		public DateTime? DateEnd { get; set; }
		public DateTime DateAdded { get; set; }
		public bool IsCurrentJob { get; set; }
		public bool? Active { get; set; }
		[StringLength(3000)]
		public string Description { get; set; }
		[StringLength(3000)]
		public string Comments { get; set; }
		public decimal? Salary { get; set; }
		[StringLength(6)]
		public string SalaryCycle { get; set; }
		public decimal? Bonus { get; set; }
		public decimal? Commission { get; set; }
		public int? JobOrderID { get; set; }
		public int? PlacementID { get; set; }
		[StringLength(50)]
		public string TerminationReason { get; set; }
		//public HrCandidate Candidate { get; set; }

	}
}
