//using BlazorInputFile;
using Stx.Shared.Common;
using Stx.Shared.Ips;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Stx.Shared.Interfaces
{
    public interface ITrademarkDataService
    {
        Task<List<IPTrademark>> GetAllRecords();

        Task<IPTrademark> GetRecordByID(int docNum);

        Task<IPTrademark> UpdateRecord(IPTrademark record, string userId);

        //Task<string> UploadImage(IFileListEntry file, string userId);
        Task<string> UploadImage(object file, string userId);

        Task<bool> DeleteRecord(int docnum, string userId, bool isValidateBefSubmit);

        ReturnObj ValidateBeforeSave(IPTrademark baseEntry);

    }
}
