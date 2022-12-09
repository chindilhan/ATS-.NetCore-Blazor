using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stx.Shared.Models.HRM
{
	[Table("HrJobSkill")]
	public class HrJobSkill
	{
		public int RecID { get; set; }
		[StringLength(50)]
		public string Name { get; set; }
		//public string CategoryID { get; set; }
		public bool? Active { get; set; }
		public DateTime CreatedOn { get; set; }
	}
}
