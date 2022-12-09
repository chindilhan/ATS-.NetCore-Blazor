using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stx.Shared.Models.HRM
{
	[Table("HrJobCandidateSkill")]
	public class HrJobCandidateSkill
	{
		public int ID { get; set; }
		public int JobCandidateID { get; set; }

		[StringLength(100)]
		public string SkillName { get; set; }
		[StringLength(1)]
		public string SkillType { get; set; } = "S";
		/// <summary>
		/// 0 None, 1 Beginner, 2 Intermediate, 3 Advanced, 4 Expert, 5 Master
		/// </summary>
		public short Proficiency { get; set; } 
		public string Comments { get; set; }
		public DateTime? DateLastModified { get; set; }
		public string UserModified { get; set; }


	}
}
