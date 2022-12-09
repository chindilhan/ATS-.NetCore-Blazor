using Stx.Shared.Common;
using Stx.Shared.Models.CRM;
using Stx.Shared.Status;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Stx.Shared.Interfaces.CRM
{
    public interface ICorporateDataService
    {
        public Task<List<Corporate>> GetAllRecords();

        public Task<Corporate> GetRecordByID(int id);

        public Task<Corporate> UpdateRecord(Corporate entry, EntryState entryState, string userId);

    }
}
