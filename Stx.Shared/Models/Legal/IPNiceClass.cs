namespace Stx.Shared
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class IPNiceClass
    {
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short ClassID { get; set; }

        public short? ClassSubID { get; set; }

        [StringLength(50)]
        public string ClassName { get; set; }

        [StringLength(4000)]
        public string ClassDesc { get; set; }

        [StringLength(50)]
        public string ClassEdition { get; set; }

        public int ModuleID { get; set; }

        [StringLength(30)]
        public string CreatedByScreen { get; set; }

        [StringLength(30)]
        public string CreatedBy { get; set; }

        public DateTime? CreatedOn { get; set; }

        [StringLength(30)]
        public string ModifiedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        [StringLength(20)]
        public string ImportRef { get; set; }

        public DateTime? ImportedOn { get; set; }

        public short? Seq{ get; set; }
        public bool? Active { get; set; }

        [StringLength(50)]
        public string SessionID { get; set; }
    }
}
