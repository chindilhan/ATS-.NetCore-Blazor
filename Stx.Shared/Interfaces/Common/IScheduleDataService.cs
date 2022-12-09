using Stx.Shared.Bps;
using Stx.Shared.Common;
using Stx.Shared.Status;
using System.Collections.Generic;
using System.Threading.Tasks;
using Stx.Shared.Models.HRM;
using Stx.Shared.Models.Common;

namespace Stx.Shared.Interfaces.Common
{
    public interface IScheduleDataService
    {
        Task<Schedule> GetRecordID(int jobOrderId);
        Task<bool> UpdateRecord(Schedule record, EntryState entryState, string userId);
    }
}
