using Stx.Shared.Bps;
using Stx.Shared.Common;
using Stx.Shared.Status;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Stx.Shared.Interfaces
{
    public interface IClientDataService
    {
        Task<List<Contact>> GetAllRecords();

        Task<Contact> GetRecordByID(int docNum);

        Task<Contact> UpdateRecord(Contact record, string userId);

        Task<ReturnObj> DeleteRecord(int docnum, string userId);
       
    }
}
