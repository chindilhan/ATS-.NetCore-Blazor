using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stx.HRM.Components
{
    [NotMapped]
    public class BenchmarkGroup
    {
        public bool IsNewGroup { get; set; }
        public short ModuelID { get; set; }
        public string BmkCategory { get; set; }
        public string Stage { get; set; }
        public string BmkType { get; set; }
        public List<BenchmarkGroupAttr> BmkAttributes { get; set; } = new List<BenchmarkGroupAttr>();
    }

    public class BenchmarkGroupAttr
    {
        public int ID { get; set; }
        public string BmkAttribute { get; set; }
        public int? SeqNum { get; set; }
    }
}
