using Stx.Shared.Models.HRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stx.Shared.Models.DTO.HRM
{
    public class HrJobSendoutDTO
    {

        public int JobOrderID { get; set; }
        public string JobTitle { get; set; }
        public string CorporateName { get; set; }
        public string CandidateName { get; set; }
        public string CandidateEmail { get; set; }
        public string CandidateMobile { get; set; }
        public string ResumeName { get; set; }
        public string CoverLetter { get; set; }
        public List<Resume> Resumes { get; set; } = new List<Resume>();
        public List<CoverLetter> CoverLetters { get; set; } = new List<CoverLetter>();

        List<HrReviewQuestion> _ReviewQuestions = new List<HrReviewQuestion>();
        public List<HrReviewQuestion> ReviewQuestions
        {
            get { return _ReviewQuestions; }
            set { _ReviewQuestions = value; }
        }

        public void ArrangeReviewQuestionDisplayKeys()
        {
            int k = 0;
            this.ReviewQuestions.OrderBy(x => x.ID).ToList().ForEach(x => x.DisplayKey = k++);
        }

        public void CopyReviewQuestionUserAnswers(List<HrReviewQuestion> listWithAnswers)
        {
            foreach (var item in this.ReviewQuestions)
            {
                if (listWithAnswers.Any(a => a.ID == item.ID))
                    item.UserAnswer = listWithAnswers.FirstOrDefault(a => a.ID == item.ID)?.UserAnswer ?? "";
            }
        }

    }
    public class Resume
    {
        public string Name { get; set; }
        public string Url { get; set; }
    }

    public class CoverLetter
    {
        public string Name { get; set; }
        public string Text { get; set; }
    }
}
