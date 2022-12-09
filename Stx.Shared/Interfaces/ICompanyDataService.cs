using Stx.Shared.Models;
using Stx.Shared.Models.CRM;
using Stx.Shared.Status;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Stx.Shared.Interfaces
{
    public interface ICompanyDataService
    {
        Task<List<Corporate>> GetAllRecords();

        Task<Corporate> GetRecordByID(int docNum);

        Task<Corporate> UpdateRecord(Corporate record,  string userId);
               
    }
}
