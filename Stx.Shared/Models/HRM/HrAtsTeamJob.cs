using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stx.Shared.Models.HRM
{
	[Table("HrAtsTeamJob")]
	public class HrAtsTeamJob
	{
		public int CorporateID { get; set; }
		public int CorpUserID { get; set; }
		public int JobOrderID { get; set; }
		public bool? Active { get; set; }
	}
}
