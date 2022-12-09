using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stx.Shared.Models.Common
{
	[Table("AcaInstituteDept")]
	public class AcaInstituteDept
	{
		public int RecID { get; set; }
		public short ID { get; set; }
		public short AcaInstID { get; set; }
		[StringLength(100)]
		public string Name { get; set; }
		public DateTime CreatedOn { get; set; }
		public bool Active { get; set; }

	}
}
