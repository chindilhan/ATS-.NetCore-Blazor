using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Stx.Shared.Models.HRM
{
    /// <summary>
    /// HrJobBenchmark is used to setup a job's interview-Scorecard
    /// User may create new job-specific entries here or may copy the entries from the base table <see cref="Stx.Shared.Models.CRM.CorporateBenchmark"/>
    /// </summary>
    [Table("HrJobBenchmark")]
    public class HrJobBenchmark
    {
        public int JobBmkID { get; set; }
        public int JobOrderID { get; set; }
        [StringLength(15)]
        public string Stage { get; set; }
		[StringLength(10)]
        public string BmkCategory{ get; set; }
		[StringLength(20)]
        public string BmkAttribute { get; set; }
		[StringLength(20)]
        public string BmkType { get; set; }
		[StringLength(100)]
        public int? SeqNum { get; set; }
    }
}