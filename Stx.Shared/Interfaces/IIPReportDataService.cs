using Stx.Shared.Common;
using Stx.Shared.Reports;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Stx.Shared.Interfaces
{
    public interface IIPReportDataService
    {
        //public List<Job> GetAllRecords();

        Task<List<IPDoc>> GetRecordByID(short basePageuid, int docNum);

    }
}
