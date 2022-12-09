using Microsoft.AspNetCore.Components.Forms;
using Stx.Shared.Common;
using Stx.Shared.Models.CRM;
using Stx.Shared.Models.HRM;
using Stx.Shared.Status;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Stx.Shared.Interfaces.CRM
{
    public interface ICorporateSettingsDataService
    {

        public Task<Corporate> GetProfile(int id);
        public Task<Corporate> UpdateProfile(Corporate entry, string userId);
        public Task<bool> UpdateProfileImage(IBrowserFile file, int candidateId);

        public Task<List<HrAtsDepartment>> GetDepartments(int id);
        public Task<HrAtsDepartment> UpdateDepartments(HrAtsDepartment entry, string userId);

        public Task<List<HrAtsTeamDTO>> GetTeams(int id);
        public Task<HrAtsTeamDTO> UpdateTeams(HrAtsTeamDTO entry, List<HrAtsTeamJob> teamJobs, string userId);

        //public Task<List<HrAtsPreferenceDTO>> GetPreferences(int id);
        //public Task<List<HrAtsPreferenceDTO>> UpdatePreferences(List<HrAtsPreferenceDTO> entry, string userId);

        public Task<List<HrAtsMailTemplate>> GetEmailTemplates(int id);
        public Task<HrAtsMailTemplate> UpdateEmailTemplates(HrAtsMailTemplate entry, string userId);

        public Task<List<HrAtsWorkflow>> GetWorkflows(int id);
        public Task<List<HrAtsWorkflow>> UpdateWorkflows(List<HrAtsWorkflow> entry, string userId);

        public Task<List<CorporateBenchmark>> GetInterviewTools(int id);
        public Task<List<CorporateBenchmark>> UpdateInterviewTools(List<CorporateBenchmark> entries, string userId);

        /// <summary>
        /// Corporate Preference & Settings
        /// </summary>
        /// <param name="id">Corporate id</param>
        /// <returns></returns>
        public Task<List<CorporatePreference>> GetCorporatePreference(int id);
        public Task<List<CorporatePreference>> UpdateCorporatePreference(List<CorporatePreference> entries, string userId);



    }
}
