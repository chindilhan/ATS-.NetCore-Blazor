using Stx.Shared.Bps;
using Stx.Shared.Common;
using Stx.Shared.Status;
using System.Collections.Generic;
using System.Threading.Tasks;
using Stx.Shared.Models.HRM;
using Stx.Shared.Models.Parm;

namespace Stx.Shared.Interfaces.HRM
{
    public interface IJobCandidateDataService
    {
        //Task<List<HrCandidate>> GetAllRecords();
        Task<HrJobCandidate> GetRecordByID(int jobCandidateId);
        Task<HrJobCandidate> GetRecordByCD(string code);
        /// <summary>
        /// Get Candidate public data based on the candidate-stage & Job order id
        /// </summary>
        /// <param name="candidateStage">Candidate stage (sourced, applied, interview) </param>
        /// <param name="jobOrderId">Job oder id</param>
        /// <returns></returns>
        Task<List<HrJobCandidateListDTO>> GetRecordListByStage(string candidateStage, int jobOrderId);

        /// <summary>
        /// Search candidates
        /// </summary>
        /// <param name="searchParms">Search parameters</param>
        /// <returns></returns>
        Task<List<HrJobCandidateListDTO>> Search(HrJobCandidateParmDTO searchParms);

        Task<HrJobCandidate> UpdateRecord(HrJobCandidate record, EntryState st, string userId);
        Task<ReturnObj> DeleteRecord(int docnum, string userId);

    }
}
