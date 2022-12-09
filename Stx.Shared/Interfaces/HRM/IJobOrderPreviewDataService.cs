using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Stx.Shared;
using Stx.Shared.Models.DTO.HRM;
using Stx.Shared.Models.HRM;
using Stx.Shared.Status;

namespace Stx.Shared.Interfaces.HRM
{
    public interface IJobOrderPreviewDataService
    {
        Task<HrJobOrderPreviewDTO> GetRecordByID(int id, int candidateID);
        Task<string> Action(CandidateJobOrderActionDto candidateJobOrderActionDto);

        //Use JobSendout Instead of this
        //public Task<HrJobOrderPreview> UpdateRecord(HrJobOrderPreview entry, EntryState entryState, string userId); //Submit Job 

    }
}
