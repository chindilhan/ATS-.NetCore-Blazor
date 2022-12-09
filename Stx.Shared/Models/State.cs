using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stx.Shared.Models
{
	[Table("State")]
	public class State
	{
		public short StateID { get; set; }
		public short CountryID { get; set; }
		[StringLength(50)]
		public string Name { get; set; }
		public bool? Active { get; set; }

	}
}
