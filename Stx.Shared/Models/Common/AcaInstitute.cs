using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stx.Shared.Models.Common
{
	[Table("AcaInstitute")]
	public class AcaInstitute
	{
		public int RecID { get; set; }
		public short AcaInstID { get; set; }
		[StringLength(100)]
		public string Name { get; set; }
		public short CountryID { get; set; }
		public DateTime CreatedOn { get; set; }
		public bool Active { get; set; }

	}
}
