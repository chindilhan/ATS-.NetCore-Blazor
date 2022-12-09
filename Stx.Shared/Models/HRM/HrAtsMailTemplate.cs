using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stx.Shared.Models.HRM
{
	[Table("HrAtsMailTemplate")]
	public class HrAtsMailTemplate
	{
		public int ID { get; set; }
		public int CorporateID { get; set; }
		public int? JobOrderID { get; set; }
		[StringLength(30)]
		public string Name { get; set; }
		[StringLength(9000)]
		public string Message { get; set; }
		public bool? Active { get; set; } = true;
		[StringLength(100)]
		public string UserAdded { get; set; }
		[StringLength(100)]
		public string UserModified { get; set; }
		public DateTime? DateAdded { get; set; }
		public DateTime? DateLastModified { get; set; }

	}
}
