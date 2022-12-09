using Stx.Shared.Common;
using Stx.Shared.Status;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Stx.Shared.Interfaces
{
    public interface IMatterDataService
    {

        Task<List<IPMatter>> GetAllRecords();

        Task<IPMatter> GetRecordByID(int docNum);

        Task<IPMatter> UpdateRecord(IPMatter record, string userId);

        Task<bool> DeleteRecord(int docnum, string userId, bool isValidateBefSubmit);

        ReturnObj ValidateBeforeSave(IPMatter baseEntry);
    }
}
