using Stx.Shared.Models.DTO.HRM;
using Stx.Shared.Models.HRM;
using Stx.Shared.Status;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Stx.Shared.Interfaces.HRM
{
    public interface ICandidateSignupDataService
    {
        public Task<bool> Signup(UserSignupDTO entry);
    }
}
