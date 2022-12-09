using Stx.Shared.Common;
using Stx.Shared.Ips;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Stx.Shared.Interfaces
{
    public interface IIPSearchDataService
    {

        Task<List<IPJobSearchResultDto>> SearchJobs(IPSearchParm iPSearchParm);
        Task<List<IPTrademarkSearchResultDto>> SearchTrademarks(IPSearchParm iPSearchParm);

    }
}
