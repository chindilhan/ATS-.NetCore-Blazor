using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Stx.Shared;
using Stx.Shared.Common;
using Stx.Shared.Models.HRM;
using Stx.Shared.Status;

namespace Stx.Shared.Interfaces.HRM
{
    public interface IJobOrderDataService
    {
        public Task<HrJobOrder> GetRecordByID(int id);

        public Task<HrJobSummaryDTO> GetJobSummaryByID(int jobOrderId);
        public Task<List<HrJobSummaryDTO>> GetCorporateJobList(int corpId);
        public Task<List<HrJobSummaryMinDTO>> GetCorporateJobListMin(int corpId);

        public Task<List<HrReviewQuestion>> GetReviewQuestions(int jobId);
        public Task<List<HrReviewQuestion>> UpdateReviewQuestions(List<HrReviewQuestion> reviewQuestions);
        public Task<bool> DeleteReviewQuestion(int jobOrderId, int Id);

        public Task<HrJobOrder> UpdateRecord(HrJobOrder entry);
        public Task<bool?> UpdateQuery(int id, List<ParmStr> values);

        public Task<ReturnObj> DeleteRecord(int id, string userId);
    }
}
