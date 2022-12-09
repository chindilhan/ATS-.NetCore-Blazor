using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stx.Shared.Models.HRM
{
	[Table("HrJobSendout")]
	public class HrJobSendout
	{
		public int ID { get; set; }
		public int CandidateID { get; set; }
		public int JobOrderID { get; set; }
		public int CorporateID { get; set; }
		[StringLength(100)]
		public string CorporateContact { get; set; }
		[StringLength(100)]
		public string CorporateEmail { get; set; }
		public bool IsEmailSent { get; set; }
		public bool IsRead { get; set; }
		[StringLength(100)]
		public string Sender { get; set; }
		public DateTime DateAdded { get; set; }
		public DateTime CreatedOn { get; set; }
		public bool? Active { get; set; }
		public short Status { get; set; }
		


	}
}
