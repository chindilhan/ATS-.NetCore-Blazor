using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stx.Shared.Models.HRM
{
	[Table("HrJobHiringTeam")]
	public class HrJobHiringTeam
	{
		public int ID { get; set; }
		public int CorporateID { get; set; }
		public int JobOrderID { get; set; }
		public int MemberEmail { get; set; }
		[StringLength(10)]
		public string UserLevel { get; set; }
		[StringLength(100)]
		public string UserAdded { get; set; }
		[StringLength(100)]
		public string UserModified { get; set; }
		public DateTime? DateAdded { get; set; }
		public DateTime? DateLastModified { get; set; }
		public bool? Active { get; set; }
	}
}
