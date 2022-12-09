using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Stx.Shared.Models.CRM
{
    /// <summary>
    /// Used for measure things like Interview-Scorecards etc
    /// CorporateBenchmark is used as a template for a module of a company (JobPortal of ABC caompany)
    /// User may create new entries here or may copy the entries from the base table <see cref="Stx.Shared.Models.Common.Benchmark"/>
    /// </summary>
    [Table("CorporateBenchmark")]
    public class CorporateBenchmark
    {
        public int ID { get; set; }
        public int CorporateID { get; set; }
        public short ModuelID { get; set; }
		//[StringLength(100)]
  //      public string Name { get; set; }
		[StringLength(20)]
        public string BmkCategory{ get; set; }
        [StringLength(500)]
        public string BmkAttribute { get; set; }
        [StringLength(10)]
        public string BmkType { get; set; }
        [StringLength(15)]
        public string Stage { get; set; }
        public int? SeqNum { get; set; }
        [StringLength(100)]
        public string UserAdded { get; set; }
        [StringLength(100)]
        public string UserModified { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateLastModified { get; set; }
    }
}