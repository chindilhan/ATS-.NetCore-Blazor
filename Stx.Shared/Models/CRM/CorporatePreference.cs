using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Stx.Shared.Models.CRM
{
    /// <summary>
    /// Used to record company settings & preferences 
    /// </summary>
    [Table("CorporatePreference")]
    public class CorporatePreference
    {
        public int ID { get; set; }
        public int CorporateID { get; set; }
        public short ModuelID { get; set; }
        [StringLength(10)]
        public string PrefType { get; set; }
		[StringLength(50)]
        public string PrefKey { get; set; }
        [StringLength(200)]
        public string PrefValue { get; set; }
        public int? SeqNum { get; set; }
        [StringLength(100)]
        public string UserAdded { get; set; }
        [StringLength(100)]
        public string UserModified { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateLastModified { get; set; }
    }
}