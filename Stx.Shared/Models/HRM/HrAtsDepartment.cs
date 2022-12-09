using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stx.Shared.Models.HRM
{
	[Table("HrAtsDepartment")]
	public class HrAtsDepartment
	{
		public int CorporateID { get; set; }
		[StringLength(30)]
		public string Name { get; set; }
		public int ID { get; set; }
		[StringLength(100)]
		public string Desc { get; set; }
		public short? DepartmentID { get; set; }
		public bool? Active { get; set; } = true;
		[StringLength(100)]
		public string UserAdded { get; set; }
		[StringLength(100)]
		public string UserModified { get; set; }
		public DateTime? DateAdded { get; set; }
		public DateTime? DateLastModified { get; set; }

	}
}
