using Stx.Shared.Common;
using Stx.Shared.Interfaces;
using Stx.Shared.Interfaces.HRM;
using Stx.Shared.Models.HRM;
using Stx.Shared.Models.Parm;
using Stx.Shared.Status;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Stx.HRM.Services.HRM
{
    public class JobCandidateDataService : IJobCandidateDataService
    {
        private readonly IApiHelperDataService _apiHelperDataService;
        public JobCandidateDataService(IApiHelperDataService apiHelperDataService)
        {
            _apiHelperDataService = apiHelperDataService;
        }

        /// <summary>
        /// Get Job-candidate detail
        /// </summary>
        /// <param name="jobCandidateId">Job candidate Id</param>
        /// <returns></returns>
        public async Task<HrJobCandidate> GetRecordByID(int jobCandidateId)
        {
            using var response = await _apiHelperDataService.GetDataByID(jobCandidateId, "JobCandidate");
            {
                response.EnsureSuccessStatusCode();
                using var stream = await response.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync<HrJobCandidate>(stream, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            }
        }

        public async Task<HrJobCandidate> GetRecordByCD(string code)
        {
            using var response = await _apiHelperDataService.GetDataByCD(code, "JobCandidate");
            {
                response.EnsureSuccessStatusCode();
                using var stream = await response.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync<HrJobCandidate>(stream, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            }
        }

        public async Task<List<HrJobCandidateListDTO>> GetRecordListByStage(string candidateStage, int jobOrderId)
        {
            string api = $"JobCandidate/Stage/{candidateStage}/{jobOrderId}";
            using var response = await _apiHelperDataService.GetData(api);

            response.EnsureSuccessStatusCode();
            using var stream = await response.Content.ReadAsStreamAsync();
            var data = await JsonSerializer.DeserializeAsync<List<HrJobCandidateListDTO>>(stream, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            return data;
        }

        public async Task<HrJobCandidate> UpdateRecord(HrJobCandidate record, EntryState st, string userId)
        {
            var serializeJson = new StringContent(JsonSerializer.Serialize(record), Encoding.UTF8, "application/json");
            var response = await _apiHelperDataService.PostData("JobCandidate", serializeJson);
            response.EnsureSuccessStatusCode();

            return await JsonSerializer.DeserializeAsync<HrJobCandidate>(await response.Content.ReadAsStreamAsync());
        }

#pragma warning disable CS1998 // This async method lacks 'await' operators and will run synchronously. Consider using the 'await' operator to await non-blocking API calls, or 'await Task.Run(...)' to do CPU-bound work on a background thread.
        public async Task<ReturnObj> DeleteRecord(int docnum, string userId)
#pragma warning restore CS1998 // This async method lacks 'await' operators and will run synchronously. Consider using the 'await' operator to await non-blocking API calls, or 'await Task.Run(...)' to do CPU-bound work on a background thread.
        {
            throw new NotImplementedException();
        }

        public async Task<List<HrJobCandidateListDTO>> Search(HrJobCandidateParmDTO searchParms)
        {
            var serializeJson = new StringContent(JsonSerializer.Serialize(searchParms), Encoding.UTF8, "application/json");
            var response = await _apiHelperDataService.PostData("JobCandidate/Search", serializeJson);
            response.EnsureSuccessStatusCode();
            using var stream = await response.Content.ReadAsStreamAsync();
            var data = await JsonSerializer.DeserializeAsync<List<HrJobCandidateListDTO>>(stream, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            return data;
        }

    }
}
