using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stx.Shared.Models.HRM
{
	[Table("HrJobCandidateCertificate")]
	public class HrJobCandidateCertificate
	{
		public int ID { get; set; }
		public int JobCandidateID { get; set; } 
		[StringLength(100)]
		public string CertificateName { get; set; }
		[StringLength(100)]
		public string LicenseNumber { get; set; }
		[StringLength(30)]
		public string LicenseType { get; set; }
		[StringLength(200)]
		public string Results { get; set; }
		[StringLength(30)]
		public string Status { get; set; }
		[StringLength(100)]
		public string IssuedBy { get; set; }
		[StringLength(30)]
		public string IssuerCountry { get; set; }
		[StringLength(3000)]
		public string Description { get; set; }
		[StringLength(3000)]
		public string Comments { get; set; }
		public bool? IsPending { get; set; }
		[StringLength(200)]
		public string FileAttachments { get; set; }
		public bool? Active { get; set; }
		public DateTime? DateCertified { get; set; }
		public DateTime? DateExpiration { get; set; }
		public DateTime DateAdded { get; set; }
		public DateTime? DateLastModified { get; set; }
		//public HrCandidate Candidate { get; set; }

	}
}
