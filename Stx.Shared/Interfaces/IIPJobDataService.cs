using Stx.Shared.Common;
using Stx.Shared.Ips;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Stx.Shared.Interfaces
{
    public interface IIPJobDataService
    {
        Task<List<IPJob>> GetAllRecords();

        Task<IPJob> GetRecordByID(int docNum);
        
        Task<IPJob> UpdateRecord(IPJob record, string userId);

        Task<bool> DeleteRecord(int docnum, string userId, bool isValidateBefSubmit);

        ReturnObj ValidateBeforeSave(IPJob baseEntry);
        
       
    }
}
