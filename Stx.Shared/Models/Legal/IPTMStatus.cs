namespace Stx.Shared
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class IPTMStatus
    {
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short StatusID { get; set; }

        [StringLength(50)]
        public string StatusDesc { get; set; }

        [StringLength(30)]
        public string Ref1Title { get; set; }

        [StringLength(30)]
        public string Ref2Title { get; set; }

        [StringLength(30)]
        public string Ref3Title { get; set; }
        
        public short? Seq{ get; set; }

        public bool? Active { get; set; }

        [StringLength(50)]
        public string SessionID { get; set; }

        [StringLength(30)]
        public string ModifiedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        [StringLength(10)]
        public string StatusColor { get; set; }
    }
}
