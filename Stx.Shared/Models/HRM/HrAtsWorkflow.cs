using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stx.Shared.Models.HRM
{
	[Table("HrAtsWorkflow")]
	public class HrAtsWorkflow
	{
		public int ID { get; set; }
		public int CorporateID { get; set; }
		[StringLength(30)]
		[Required(ErrorMessage = "The Name field is required.")]
		public string Name { get; set; }
		[StringLength(15)]
		[Required(ErrorMessage = "The Category field is required.")]
		public string StageCategory { get; set; }
		public bool IsConfidential { get; set; } = false;
		public bool IsLocked { get; set; } = false;
		public short SeqNum { get; set; }
		[StringLength(100)]
		public string UserAdded { get; set; }
		[StringLength(100)]
		public string UserModified { get; set; }
		public DateTime? DateAdded { get; set; }
		public DateTime? DateLastModified { get; set; }

	}
}
