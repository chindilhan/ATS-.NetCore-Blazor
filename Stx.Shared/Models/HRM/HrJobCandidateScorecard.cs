using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Stx.Shared.Models.HRM
{
    /// <summary>
    /// HrJobCandidateScorecard is used to measure & record candidate's rank for a specific job.
    /// The measuring criteria / scorecard is based on the <see cref="Stx.Shared.Models.CRM.CorporateBenchmark"/> setup
    /// </summary>  
    [Table("HrJobCandidateScorecard")]
    public class HrJobCandidateScorecard
    {
        public int ID { get; set; }
        public int JobBmkID { get; set; }
        public int CandidateID { get; set; }
        public int EvaluatorID { get; set; }
        [StringLength(500)]
        public string Value { get; set; }
        [StringLength(1000)]
        public string Note { get; set; }
    }
}