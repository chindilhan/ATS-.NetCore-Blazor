using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Stx.Shared.Models.Parm
{
    [NotMapped]
    public class HrCandidateParmDTO
    {
        public HrCandidateParmDTO()
        {

        }
        public HrCandidateParmDTO(string keyword, string title)
        {
            this.Keyword = Keyword;
            this.Title = title;
        }
        public HrCandidateParmDTO(string Keyword, string title, string country)
        {
            this.Keyword = Keyword;
            this.Title = title;
            this.Country = country;
        }
        public HrCandidateParmDTO(string Keyword, string title, string country, string location, string corporateName, string eduInstitute,
            string candidateSource = "A", int? candidateID=null, int? jobIndustry=null, int? jobOrderID=null)
        {
            this.Keyword = Keyword;
            this.Title = title;
            this.Country = country;
            this.Location= location;
            this.CorporateName = corporateName;
            this.EduInstitute = eduInstitute;
            this.CandidateID = candidateID;
            this.CandidateSource = candidateSource;
            this.JobIndustry = jobIndustry;
            this.JobOrderID = jobOrderID;
        }

        public string Keyword { get; set; } = "";
        public string Title { get; set; } = "";
        public string Country { get; set; } = "";
        public string Location { get; set; } = "";
        public string CorporateName { get; set; } = "";
        public string EduInstitute { get; set; } = "";
        public int? CandidateID { get; set; }
        public string CandidateSource { get; set; } = "A";
        public int? JobIndustry { get; set; }
        public int? JobOrderID { get; set; }
    }
}
