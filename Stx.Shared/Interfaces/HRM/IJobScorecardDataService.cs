using Stx.Shared.Bps;
using Stx.Shared.Common;
using Stx.Shared.Status;
using System.Collections.Generic;
using System.Threading.Tasks;
using Stx.Shared.Models.HRM;
using Stx.Shared.Models.Common;

namespace Stx.Shared.Interfaces.HRM
{
    public interface IJobScorecardDataService
    {
        public Task<HrJobCandidateScorecardDTO> GetRecordByID(int scorecardId);
        public Task<List<HrJobCandidateScorecardDTO>> GetRecords(int jobOrderId, int candidateId, int evaluatorId, string stage);

        public Task<List<HrJobCandidateScorecardDTO>> UpdateRecord(List<HrJobCandidateScorecardDTO> entry, EntryState entryState, string userId);

        public Task<ReturnObj> DeleteRecord(int scorecardId, string userId);
    }
}
