using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Stx.Shared.Models.HRM
{
    public class HrCorporateType
    {
        public HrCorporateType()
        {

        }

        public HrCorporateType(short id, string employmentType)
        {
            ID = id;
            CorporateType = employmentType;
        }

        [NotMapped]
        public bool IsSelected { get; set; }
        public short ID { get; set; }
        public string CorporateType { get; set; }

    }
}
