using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stx.Shared.Models
{
	[Table("Nationality")]
	public class Nationality
	{
		public short NationalityID { get; set; }
		[StringLength(30)]
		public string Name { get; set; }
		public short? CountryID { get; set; }
		public bool? Active { get; set; }

	}
}
