using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Stx.Shared.Models.HRM
{
    public class HrCandidateMultiData
    {
        public HrCandidateMultiData()
        {
        }


        public int ID { get; set; }
        public int CandidateID { get; set; }
        public string RecordType { get; set; }
        public string EntityValue { get; set; }
        public string EntityDesc { get; set; }
        public DateTime DateUpdated { get; set; }

        [NotMapped]
        public bool IsSelected { get; set; }
        [NotMapped]
        public string DynmcFileUrl { get; set; }
    }
}
