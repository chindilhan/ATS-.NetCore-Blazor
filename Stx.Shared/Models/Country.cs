using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stx.Shared.Models
{
	[Table("Country")]
	public class Country
	{
		public short CountryID { get; set; }
		[StringLength(10)]
		public string CountryCD { get; set; }
		[StringLength(2)]
		public string CountryCDIso2 { get; set; }
		[StringLength(50)]
		public string Name { get; set; }
		[StringLength(3)]
		public string CurrCD { get; set; }

	}
}
