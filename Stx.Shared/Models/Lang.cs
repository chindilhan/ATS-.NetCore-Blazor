using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stx.Shared.Models
{
	[Table("Lang")]
	public class Lang
	{
		public short LangID { get; set; }
		[StringLength(30)]
		public string Name { get; set; }
		public bool? Active { get; set; }
		public bool? HasWrittenLang { get; set; }
	}
}
