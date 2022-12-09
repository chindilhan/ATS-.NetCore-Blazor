using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Stx.Shared.Models.HRM
{
    /// <summary>
    /// DTO for Job-Candidate Scorecard. This is used to display, measure & transfer candidate's rank data of a specific job.
    /// The measuring criteria / scorecard data will be saved to <see cref="Stx.Shared.Models.HRM.HrJobCandidateScorecard"/> setup
    /// </summary>  
    [NotMapped]
    public class HrJobCandidateScorecardDTO
    {
        public int ID { get; set; }
        public int JobBmkID { get; set; }
        public int JobOrderID { get; set; }
        [StringLength(15)]
        public string Stage { get; set; }
        [StringLength(10)]
        public string BmkCategory { get; set; }
        [StringLength(20)]
        public string BmkAttribute { get; set; }
        [StringLength(20)]
        public string BmkType { get; set; }
        [StringLength(100)]
        public int? SeqNum { get; set; }
        public int CandidateID { get; set; }
        public int EvaluatorID { get; set; }
        [StringLength(500)]
        public string Value { get; set; }
        [StringLength(1000)]
        public string Note { get; set; }

    }
}