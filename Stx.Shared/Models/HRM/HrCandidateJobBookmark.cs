using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stx.Shared.Models.HRM
{
	[Table("HrCandidateJobBookmark")]
	public class HrCandidateJobBookmark
	{
		public int ID { get; set; }
		public int CandidateID { get; set; }
		public int JobOrderID { get; set; }
		public DateTime? DateAdded{ get; set; }

	}
}
