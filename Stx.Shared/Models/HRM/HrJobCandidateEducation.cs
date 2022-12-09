using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stx.Shared.Models.HRM
{
	[Table("HrJobCandidateEducation")]
	public class HrJobCandidateEducation
	{
		public int ID { get; set; }
		public int JobCandidateID { get; set; }
		[StringLength(100)]
		public string Institute { get; set; }
		[StringLength(100)]
		public string InstituteUnit { get; set; }
		public short? Country { get; set; }
		public short? City { get; set; }
		[StringLength(100)]
		public string QualificationName { get; set; }
		[StringLength(30)]
		public string QualificationType { get; set; }
		[StringLength(50)]
		public string FieldOfStudy { get; set; }
		public DateTime DateGraduated { get; set; }
		public DateTime DateStarted { get; set; }
		public DateTime DateExpiration { get; set; }
		[StringLength(100)]
		public string Major { get; set; }
		[StringLength(30)]
		public string Grade { get; set; }
		public double Gpa { get; set; }
		[StringLength(3000)]
		public string Comments { get; set; }
		public bool? Active { get; set; }
		//public HrCandidate Candidate { get; set; }

	}
}
