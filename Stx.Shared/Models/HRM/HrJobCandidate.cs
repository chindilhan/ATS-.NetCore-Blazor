using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stx.Shared.Models.HRM
{
	[Table("HrJobCandidate")]
	public class HrJobCandidate : CandidateBase
	{
		public HrJobCandidate()
		{
			Educations = new List<HrJobCandidateEducation>();
			Experiences = new List<HrJobCandidateExperience>();
			Certificates = new List<HrJobCandidateCertificate>();
		}

		public int JobCandidateID { get; set; } //key
		
		[StringLength(50)]
		public string CandidateSource { get; set; }
		public int JobOrderID { get; set; }
		public int CorporateID { get; set; }
		public int? CandidateID { get; set; }
		[StringLength(15)]
		public string Stage { get; set; }
		public List<HrJobCandidateEducation> Educations { get; set; } 
		public List<HrJobCandidateExperience> Experiences { get; set; }
		public List<HrJobCandidateCertificate> Certificates { get; set; }
		public List<HrJobCandidateSkill> Skills { get; set; }

		public string ProfileImgKey { get; set; }

		/// <summary>
		/// Non Mapped Dynamic Image Url field which uses to generated profile image Url. 
		/// </summary>
		[NotMapped]
		public string DynmcImageUrl { get; set; }


		/*
		public string Category { get; set; }
		public string Categories { get; set; }
		public string Certifications { get; set; }
		*/

	}
}
