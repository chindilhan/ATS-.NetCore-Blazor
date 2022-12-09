using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stx.Shared.Models.HRM
{
	[Table("HrJobIndustry")]
	public class HrJobIndustry
	{
		public int ID { get; set; }
		[StringLength(80)]
		public string Name { get; set; }
		public bool? Active { get; set; }
		public DateTime CreatedOn { get; set; }
	}
}
