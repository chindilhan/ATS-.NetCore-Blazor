using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Stx.Shared.Models.Parm
{
    [NotMapped]
    public class HrJobCandidateParmDTO
    {
        public HrJobCandidateParmDTO()
        {

        }
        public HrJobCandidateParmDTO(int corporateID, List<int> jobOrderIds, List<string> stages, string applDateFrom)
        {
            this.CorporateID = corporateID;
            this.JobOrderIds = jobOrderIds;
            this.Stages = stages;
            this.ApplDateFrom = applDateFrom;
            this.ApplDateTo = null;
            this.CandidateSource = null;
            this.Keyword = null;
            this.Tags = null;
            this.JobIndustry = null;
            this.IsActive = null;
        }

        public HrJobCandidateParmDTO(int corporateID, List<int> jobOrderIds, List<string> stages, string applDateFrom,
            string applDateTo, string candidateSource, string keyword, List<string> tags, List<string> jobIndustry, bool? isActive)
        {
            this.CorporateID = corporateID;
            this.JobOrderIds = jobOrderIds;
            this.Stages = stages;
            this.ApplDateFrom = applDateFrom;
            this.ApplDateTo = applDateTo;
            this.CandidateSource = candidateSource;
            this.Keyword = keyword;
            this.Tags = tags;
            this.JobIndustry = jobIndustry;
            this.IsActive = isActive;
        }

        public int CorporateID { get; set; }
        public List<int> JobOrderIds { get; set; }
        public List<string> Stages { get; set; }
        public string ApplDateFrom { get; set; }
        public string ApplDateTo { get; set; }
        public string CandidateSource { get; set; } = "A";
        public string Keyword { get; set; }
        public List<string> Tags { get; set; }
        public List<string> JobIndustry { get; set; }
        public bool? IsActive { get; set; }

    }
}
