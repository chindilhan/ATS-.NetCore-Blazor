using Stx.Shared.Bps;
using Stx.Shared.Common;
using Stx.Shared.Status;
using System.Collections.Generic;
using System.Threading.Tasks;
using Stx.Shared.Models.HRM;
using Microsoft.AspNetCore.Http;

namespace Stx.Shared.Interfaces.HRM
{
    public interface ICandidateProfileDataService
    {
        Task<HrCandidateProfile> GetRecordByID(int id);
        Task<HrCandidateProfile> GetRecordByCD(string code);
        Task<HrCandidateProfile> UpdateRecord(HrCandidateProfile record, EntryState st, string userId);
        Task<bool> UpdateProfileImage(IFormFile file, int candidateId);
    }
}
