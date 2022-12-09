using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stx.Shared.Models.HRM
{
	[Table("HrCandidateJobActivity")]
	public class HrCandidateJobActivity
	{
		public int ID { get; set; }
		public string ActivityType { get; set; }
		public int CandidateID { get; set; }
		public int JobOrderID { get; set; }
		public string Value { get; set; }
		public DateTime? DateAdded{ get; set; }
		public DateTime? DateUpdated { get; set; }

	}
}
