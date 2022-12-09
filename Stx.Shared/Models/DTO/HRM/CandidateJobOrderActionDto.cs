using Stx.Shared.Models.HRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stx.Shared.Models.DTO.HRM
{
    public class CandidateJobOrderActionDto
    {

        public string ActionName { get; set; }
        public string ActionValue { get; set; }
        public int JobOrderID { get; set; }
        public int CandidateID { get; set; }
    }
}
