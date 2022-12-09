using Stx.Shared.Extensions.Http;
using Stx.Shared.Interfaces;
using Stx.Shared.Interfaces.HRM;
using Stx.Shared.Models.DTO.HRM;
using Stx.Shared.Models.HRM;
using Stx.Shared.Services;
using Stx.Shared.Status;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Stx.DataServices.Hrm
{
    public class JobOrderPreviewDataService : IJobOrderPreviewDataService
    {
        private readonly IApiHelperDataService _apiHelperDataService;
        public JobOrderPreviewDataService(IApiHelperDataService apiHelperDataService)
        {
            _apiHelperDataService = apiHelperDataService;
        }

 
        //public JobOrderPreviewDataService(string apiAddr)
        //{
        //    HttpClient httpClient = new HttpClient() { BaseAddress = new System.Uri(apiAddr) };
        //    _apiHelperDataService = new ApiHelperDataService(httpClient);
        //}


        public async Task<HrJobOrderPreviewDTO> GetRecordByID(int id, int candidateID)
        {
            //Error Reason: (not supplied all the parms to api; [/JobOrderPreview/{id}/{candidateid}]
            string endpointWithParm = @$"JobOrderPreview/{id}/{candidateID}/";
            var response = await _apiHelperDataService.GetData(endpointWithParm);
            {
                await response.EnsureSuccessStatusCode2();
                using var stream = await response.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync<HrJobOrderPreviewDTO>(stream, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            }
        }

        //public async Task<HrJobOrderPreviewDTO> UpdateRecord(HrJobOrderPreviewDTO record, EntryState st, string userId)
        //{
        //    var serializeJson = new StringContent(JsonSerializer.Serialize(record), Encoding.UTF8, "application/json");
        //    var response = await _apiHelperDataService.UpdateData(serializeJson, st, "JobOrderPreview", "");
        //    {
        //        await response.EnsureSuccessStatusCode2();
        //        using var stream = await response.Content.ReadAsStreamAsync();
        //        return await JsonSerializer.DeserializeAsync<HrJobOrderPreviewDTO>(stream, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        //    }
        //}

        public async Task<string> Action(CandidateJobOrderActionDto candidateJobOrderActionDto)
        {
            var payload = new StringContent(JsonSerializer.Serialize(candidateJobOrderActionDto), Encoding.UTF8, "application/json");
            var response = await _apiHelperDataService.PostData("JobOrderPreview/Action", payload);
            {
                await response.EnsureSuccessStatusCode2();
                using var stream = await response.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync<string>(stream, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            }
        }



    }
}
