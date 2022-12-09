using Stx.Shared.Bps;
using Stx.Shared.Common;
using Stx.Shared.Status;
using System.Collections.Generic;
using System.Threading.Tasks;
using Stx.Shared.Models.HRM;
using Stx.Shared.Models.Parm;

namespace Stx.Shared.Interfaces.HRM
{
    public interface ICandidatePublicDataService
    {
        /// <summary>
        /// Get Candidate public data based on candidate id
        /// </summary>
        /// <param name="candidateId">Candidate id</param>
        /// <returns></returns>
        Task<HrCandidatePublicDTO> GetRecordByID(int candidateId);
        /// <summary>
        /// Get Candidate public data based on the candidate-Source-type & candidate id
        /// </summary>
        /// <param name="candidateSource">Candidate source type (A-Applied, I-imported) </param>
        /// <param name="candidateId">Candidate id</param>
        /// <returns></returns>
        Task<HrCandidatePublicDTO> GetRecordByID(string candidateSource, int candidateId);
        /// <summary>
        /// Get Candidate public data based on the candidate-Source-type, candidate id & Job order id
        /// </summary>
        /// <param name="candidateSource">Candidate source type (A-Applied, I-imported) </param>
        /// <param name="candidateId">Candidate id</param>
        /// <param name="jobOrderId">Job oder id</param>
        /// <returns></returns>
        Task<HrCandidatePublicDTO> GetRecordByID(string candidateSource, int candidateId, int? jobOrderId);

        ///// <summary>
        ///// Get Candidate public data based on the candidate-stage & Job order id
        ///// </summary>
        ///// <param name="candidateStage">Candidate stage (sourced, applied, interview) </param>
        ///// <param name="jobOrderId">Job oder id</param>
        ///// <returns></returns>
        //Task<List<HrJobCandidateListDTO>> GetRecordsByJobAndStage(string candidateStage, int jobOrderId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        Task<HrCandidatePublicDTO> GetRecordByCD(string code);
        /// <summary>
        /// Search candidates
        /// </summary>
        /// <param name="searchParms">Search parameters</param>
        /// <returns></returns>
        Task<List<HrCandidatePublicDTO>> Search(HrCandidateParmDTO searchParms);

        ///// <summary>
        ///// Add or import a (company spesific) candidate.
        ///// </summary>
        ///// <param name="record">Candidate record</param>
        ///// <param name="userId">current user's id</param>
        ///// <returns></returns>
        //Task<HrCandidatePublicDTO> Import(HrCandidatePublicDTO record, string userId);

    }
}
