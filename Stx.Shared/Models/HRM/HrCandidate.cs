using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stx.Shared.Models.HRM
{
	[Table("HrCandidate")]
	public class HrCandidate : CandidateBase
	{
		public HrCandidate()
		{
			Educations = new List<HrCandidateEducation>();
			Experiences = new List<HrCandidateExperience>();
			Certificates = new List<HrCandidateCertificate>();
			Skills = new List<HrCandidateSkill>();
			Languages = new List<HrCandidateLanguage>();
		}

		public int CandidateID { get; set; } //key
		[StringLength(256)]
		public string UserName { get; set; }


		public List<HrCandidateEducation> Educations { get; set; } 
		public List<HrCandidateExperience> Experiences { get; set; }
		public List<HrCandidateCertificate> Certificates { get; set; }
		public List<HrCandidateSkill> Skills { get; set; }
		public List<HrCandidateLanguage> Languages { get; set; }

	}
}
