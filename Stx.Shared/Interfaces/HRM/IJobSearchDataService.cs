using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Stx.Shared;
using Stx.Shared.Common;
using Stx.Shared.Models.HRM;
using Stx.Shared.Models.Parm;
using Stx.Shared.Status;

namespace Stx.Shared.Interfaces.HRM
{
    public interface IJobSearchDataService
    {
        public Task<List<HrJobOrderSearch>> Search(HrJobSearchParmDTO parms);
        //public Task<List<HrJobOrderSearch>> Search(string keyword, string location, string jobindustry, int candidateid);
    }
}
