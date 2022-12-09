namespace Stx.Shared
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class IPMatterType
    {
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ModuleID { get; set; }

        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short MatterTypeID { get; set; }

        [StringLength(50)]
        public string MatterTypeDesc { get; set; }
                       
        public short? Seq{ get; set; }
        public bool? Active { get; set; }

        [StringLength(50)]
        public string SessionID { get; set; }

        [StringLength(30)]
        public string ModifiedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
