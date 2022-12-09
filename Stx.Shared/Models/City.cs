using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stx.Shared.Models
{
	[Table("City")]
	public class City
	{
		public int CityID { get; set; }
		//[StringLength(50)]
		//public string CityCD { get; set; }
		public short CountryID { get; set; }
		[StringLength(50)]
		public string Name { get; set; }
		public bool? Active { get; set; }

	}
}
