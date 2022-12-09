using Stx.Shared.Bps;
using Stx.Shared.Common;
using Stx.Shared.Status;
using System.Collections.Generic;
using System.Threading.Tasks;
using Stx.Shared.Models.HRM;
using Stx.Shared.Models.Parm;

namespace Stx.Shared.Interfaces.HRM
{
    public interface ICandidateEvaluateDataService
    {
        Task<HrCandidatePublicDTO> GetRecordByID(int id);
        
        Task<HrCandidatePublicDTO> GetRecordByCD(string code);
        /// <summary>
        /// Search candidates
        /// </summary>
        /// <param name="searchParms">Search parameters</param>
        /// <returns></returns>
        Task<List<HrCandidatePublicDTO>> Search(HrCandidateParmDTO searchParms);
        /// <summary>
        /// Add or import a (company spesific) candidate.
        /// </summary>
        /// <param name="record">Candidate record</param>
        /// <param name="userId">current user's id</param>
        /// <returns></returns>
        Task<HrCandidatePublicDTO> Import(HrCandidatePublicDTO record, string userId);

    }
}
