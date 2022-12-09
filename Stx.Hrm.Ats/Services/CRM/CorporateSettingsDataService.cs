using Microsoft.AspNetCore.Components.Forms;
using Stx.Shared.Interfaces;
using Stx.Shared.Interfaces.CRM;
using Stx.Shared.Models.Collective;
using Stx.Shared.Models.CRM;
using Stx.Shared.Models.HRM;
using Stx.Shared.Models.Parm;
using Stx.Shared.Status;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Stx.HRM.Services.CRM
{
    public class CorporateSettingsDataService : ICorporateSettingsDataService
    {
        private readonly IApiHelperDataService _apiHelperDataService;
        string baseEndpoint = "CorporateSettings";

        public CorporateSettingsDataService(IApiHelperDataService apiHelperDataService)
        {
            _apiHelperDataService = apiHelperDataService;
        }


        #region PROFILE
        public async Task<Corporate> GetProfile(int id)
        {
            var response = await _apiHelperDataService.GetDataByID(id, $"{baseEndpoint}/Profile");
            {
                response.EnsureSuccessStatusCode();
                using var stream = await response.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync<Corporate>(stream, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            }
        }
        public async Task<Corporate> UpdateProfile(Corporate entry, string userId)
        {
            var serializeJson = new StringContent(JsonSerializer.Serialize(entry), Encoding.UTF8, "application/json");
            var response = await _apiHelperDataService.PostData($"{baseEndpoint}/Profile", serializeJson);
            response.EnsureSuccessStatusCode();

            using var stream = await response.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<Corporate>(stream, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

            //if (response.IsSuccessStatusCode)
            //{
            //    return await JsonSerializer.DeserializeAsync<Corporate>(await response.Content.ReadAsStreamAsync());
            //}
            //else if (response.Content != null)
            //{
            //    throw new System.Exception("");
            //}
            //return null;
        }
        public async Task<bool> UpdateProfileImage(IBrowserFile file, int candidateId)
        {
            var candidateIdData = new StringContent(candidateId.ToString(), Encoding.UTF8, "application/text");

            var multiContent = new MultipartFormDataContent();
            multiContent.Add(candidateIdData, "candidateId");

            HttpContent fileStreamContent = new StreamContent(file.OpenReadStream());
            multiContent.Add(fileStreamContent, "data", file.Name);

            string endpointWithParm = @$"CandidateProfile/ProfileImage";
            using var response = await _apiHelperDataService.PostData(endpointWithParm, multiContent);
            {
                response.EnsureSuccessStatusCode();
                using var stream = await response.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync<bool>(stream, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            }
        }
        #endregion


        #region DEPT, TEAMS, PREFERENCES
        public async Task<List<HrAtsDepartment>> GetDepartments(int id)
        {
            var response = await _apiHelperDataService.GetDataByID(id, $"{baseEndpoint}/Departments");
            {
                response.EnsureSuccessStatusCode();
                using var stream = await response.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync<List<HrAtsDepartment>>(stream, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            }
        }
        public async Task<HrAtsDepartment> UpdateDepartments(HrAtsDepartment entry, string userId)
        {
            var serializeJson = new StringContent(JsonSerializer.Serialize(entry), Encoding.UTF8, "application/json");
            var response = await _apiHelperDataService.PostData($"{baseEndpoint}/Departments", serializeJson);
            response.EnsureSuccessStatusCode();

            using var stream = await response.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<HrAtsDepartment>(stream, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<List<HrAtsTeamDTO>> GetTeams(int id)
        {
            var response = await _apiHelperDataService.GetDataByID(id, $"{baseEndpoint}/Teams");
            {
                response.EnsureSuccessStatusCode();
                using var stream = await response.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync<List<HrAtsTeamDTO>>(stream, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            }
        }
        public async Task<HrAtsTeamDTO> UpdateTeams(HrAtsTeamDTO entry, List<HrAtsTeamJob> teamJobs, string userId)
        {
            CorporateTeamCollective ctc = new CorporateTeamCollective() { AtsTeam = entry, AtsTeamAssignJobs = teamJobs };

            var serializeJson = new StringContent(JsonSerializer.Serialize(ctc), Encoding.UTF8, "application/json");
            var response = await _apiHelperDataService.PostData($"{baseEndpoint}/Teams", serializeJson);
            response.EnsureSuccessStatusCode();

            using var stream = await response.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<HrAtsTeamDTO>(stream, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }
        /// <summary>
        /// Corporate Preference & Settings
        /// </summary>
        /// <param name="id">Corporate id</param>
        /// <returns></returns>
        public async Task<List<CorporatePreference>> GetCorporatePreference(int id)
        {
            var response = await _apiHelperDataService.GetDataByID(id, $"{baseEndpoint}/CorporatePreference");
            {
                response.EnsureSuccessStatusCode();
                using var stream = await response.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync<List<CorporatePreference>>(stream, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            }
        }
        public async Task<List<CorporatePreference>> UpdateCorporatePreference(List<CorporatePreference> entries, string userId)
        {
            var serializeJson = new StringContent(JsonSerializer.Serialize(entries), Encoding.UTF8, "application/json");
            var response = await _apiHelperDataService.PostData($"{baseEndpoint}/CorporatePreference", serializeJson);
            response.EnsureSuccessStatusCode();

            using var stream = await response.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<List<CorporatePreference>>(stream, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }
        #endregion

        #region WORKFLOW
        public async Task<List<HrAtsWorkflow>> GetWorkflows(int id)
        {
            var response = await _apiHelperDataService.GetDataByID(id, $"{baseEndpoint}/Workflows");
            {
                response.EnsureSuccessStatusCode();
                using var stream = await response.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync<List<HrAtsWorkflow>>(stream, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            }
        }

        public async Task<List<HrAtsWorkflow>> UpdateWorkflows(List<HrAtsWorkflow> entry, string userId)
        {
            var serializeJson = new StringContent(JsonSerializer.Serialize(entry), Encoding.UTF8, "application/json");
            var response = await _apiHelperDataService.PostData($"{baseEndpoint}/Workflows", serializeJson);
            response.EnsureSuccessStatusCode();

            using var stream = await response.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<List<HrAtsWorkflow>>(stream, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }
        #endregion


        #region TEMPLATES
        public async Task<List<HrAtsMailTemplate>> GetEmailTemplates(int id)
        {
            var response = await _apiHelperDataService.GetDataByID(id, $"{baseEndpoint}/EmailTemplates");
            {
                response.EnsureSuccessStatusCode();
                using var stream = await response.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync<List<HrAtsMailTemplate>>(stream, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            }
        }
        public async Task<HrAtsMailTemplate> UpdateEmailTemplates(HrAtsMailTemplate entry, string userId)
        {
            var serializeJson = new StringContent(JsonSerializer.Serialize(entry), Encoding.UTF8, "application/json");
            var response = await _apiHelperDataService.PostData($"{baseEndpoint}/EmailTemplates", serializeJson);
            response.EnsureSuccessStatusCode();

            using var stream = await response.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<HrAtsMailTemplate>(stream, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<List<CorporateBenchmark>> GetInterviewTools(int id)
        {
            var response = await _apiHelperDataService.GetDataByID(id, $"{baseEndpoint}/CorporateBenchmark");
            {
                response.EnsureSuccessStatusCode();
                using var stream = await response.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync<List<CorporateBenchmark>>(stream, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            }
        }
        public async Task<List<CorporateBenchmark>> UpdateInterviewTools(List<CorporateBenchmark> entries, string userId)
        {
            {
                var serializeJson = new StringContent(JsonSerializer.Serialize(entries), Encoding.UTF8, "application/json");
                var response = await _apiHelperDataService.PostData($"{baseEndpoint}/CorporateBenchmark", serializeJson);
                response.EnsureSuccessStatusCode();

                using var stream = await response.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync<List<CorporateBenchmark>>(stream, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            }
        }

        #endregion

    }
}
