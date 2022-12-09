using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Stx.Shared;
using Stx.Shared.Common;
using Stx.Shared.Models.DTO.HRM;
using Stx.Shared.Models.HRM;
using Stx.Shared.Status;

namespace Stx.Shared.Interfaces.HRM
{
    public interface IJobSendoutDataService
    {
        public Task<HrJobSendoutDTO> GetData(int jobOrderId, int candidateId);
        public Task<bool> Submit(HrJobSendout jobSendout);
        //public Task<ReturnObj> Submit(int jobOrderId, int candidateID);

    }
}
