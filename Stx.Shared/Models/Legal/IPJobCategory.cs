namespace Stx.Shared
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("IPJobCategory")]
    public partial class IPJobCategory
    {
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short JobCatgID { get; set; }

        [StringLength(50)]
        public string JobCatgDesc { get; set; }

        public bool Active { get; set; }

        public short? Seq{ get; set; }

        [StringLength(50)]
        public string SessionID { get; set; }

        [StringLength(30)]
        public string ModifiedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }
        
        [StringLength(10)]
        public string StatusColor { get; set; }
    }
}
