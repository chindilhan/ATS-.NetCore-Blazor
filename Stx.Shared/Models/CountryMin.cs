using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stx.Shared.Models
{
	[NotMapped]
	public class CountryMin
	{
        public CountryMin()
        {

        }
        public CountryMin(short countryId, string name)
        {
			this.CountryID = countryId;
			this.Name = name;
        }
		public short CountryID { get; set; }
		[StringLength(50)]
		public string Name { get; set; }
	}
}
