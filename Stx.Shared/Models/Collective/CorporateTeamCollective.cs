using Stx.Shared.Models.HRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stx.Shared.Models.Collective
{
    public class CorporateTeamCollective
    {
        public HrAtsTeamDTO AtsTeam { get; set; }
        public List<HrAtsTeamJob> AtsTeamAssignJobs { get; set; }
    }
}
