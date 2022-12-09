using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Stx.Shared.Models.Common
{
    [Table("Benchmark")]
    public class Benchmark
    {
        public short ModuelID { get; set; }
        public int BmkID { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(20)]
        public string BmkCategory { get; set; }
        [StringLength(10)]
        public string BmkType { get; set; }
        [StringLength(15)]
        public string Stage { get; set; }
        public int? SeqNum { get; set; }
    }
}