using Stx.Shared.Common;
using Stx.Shared.Interfaces;
using Stx.Shared.Interfaces.HRM;
using Stx.Shared.Models.HRM;
using Stx.Shared.Status;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;


namespace Stx.HRM.Services.HRM
{
    public class JobScorecardDataService : IJobScorecardDataService
    {
        private readonly IApiHelperDataService _apiHelperDataService;
        public JobScorecardDataService(IApiHelperDataService apiHelperDataService)
        {
            _apiHelperDataService = apiHelperDataService;
        }

        public async Task<HrJobCandidateScorecardDTO> GetRecordByID(int scorecardId)
        {
            using var response = await _apiHelperDataService.GetDataByID(scorecardId, "JobScorecard");
            {
                response.EnsureSuccessStatusCode();
                using var stream = await response.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync<HrJobCandidateScorecardDTO>(stream, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            }
        }

        public async Task<List<HrJobCandidateScorecardDTO>> GetRecords(int jobOrderId, int candidateId, int evaluatorId, string stage)
        {
            string api = $"JobScorecard/{jobOrderId}/{candidateId}/{evaluatorId}/{stage}";
            using var response = await _apiHelperDataService.GetData(api);
            response.EnsureSuccessStatusCode();
            if (response.IsSuccessStatusCode)
            {
                using var stream = await response.Content.ReadAsStreamAsync();
                var data = await JsonSerializer.DeserializeAsync<List<HrJobCandidateScorecardDTO>>(stream, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
                return data;
            }
            else
            {
                return null;
            }
        }

        public async Task<List<HrJobCandidateScorecardDTO>> UpdateRecord(List<HrJobCandidateScorecardDTO> entry, EntryState entryState, string userId)
        {
            var serializeJson = new StringContent(JsonSerializer.Serialize(entry), Encoding.UTF8, "application/json");
            var response = await _apiHelperDataService.PostData("JobScorecard", serializeJson);
            response.EnsureSuccessStatusCode();
            return await JsonSerializer.DeserializeAsync<List<HrJobCandidateScorecardDTO>>(await response.Content.ReadAsStreamAsync());
        }

        public async Task<ReturnObj> DeleteRecord(int scorecardId, string userId)
        {
            var response = await _apiHelperDataService.DeleteRecord("JobScorecard", scorecardId, "");
            {
                response.EnsureSuccessStatusCode();
                using var stream = await response.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync<ReturnObj>(stream, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            }
        }

    }
}
