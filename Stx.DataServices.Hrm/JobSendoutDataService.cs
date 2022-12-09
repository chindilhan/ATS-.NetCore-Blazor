using Stx.Shared.Common;
using Stx.Shared.Extensions.Http;
using Stx.Shared.Interfaces;
using Stx.Shared.Interfaces.HRM;
using Stx.Shared.Models.DTO.HRM;
using Stx.Shared.Models.HRM;
using Stx.Shared.Services;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Stx.DataServices.Hrm
{
    public class JobSendoutDataService : IJobSendoutDataService
    {
        private readonly IApiHelperDataService _apiHelperDataService;

        public JobSendoutDataService(IApiHelperDataService apiHelperDataService)
        {
            _apiHelperDataService = apiHelperDataService;
        }
        //public JobSendoutDataService(string apiAddr)
        //{
        //    HttpClient httpClient = new HttpClient() { BaseAddress = new System.Uri(apiAddr) };
        //    _apiHelperDataService = new ApiHelperDataService(httpClient);
        //}

        public async Task<HrJobSendoutDTO> GetData(int jobOrderId, int candidateId)
        {
            using var response = await _apiHelperDataService.GetData($"JobSendout/{jobOrderId}/{candidateId}");
            {
                await response.EnsureSuccessStatusCode2();
                using var stream = await response.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync<HrJobSendoutDTO> (stream, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            }
        }

        public async Task<bool> Submit(HrJobSendout jobSendout)
        {
            var serializeJson = new StringContent(JsonSerializer.Serialize(jobSendout), Encoding.UTF8, "application/json");
            var response = await _apiHelperDataService.PostData("JobSendout", serializeJson);

            await response.EnsureSuccessStatusCode2();
            using var stream = await response.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<bool>(stream, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        //public async Task<ReturnObj> Submit(int jobOrderId, int candidateID)
        //{
        //    string endpointWithParm = @$"JobSendout/{jobOrderId}/{candidateID}/";
        //    var response = await _apiHelperDataService.PostData(endpointWithParm, null);

        //    await response.EnsureSuccessStatusCode2();
        //    using var stream = await response.Content.ReadAsStreamAsync();
        //    return await JsonSerializer.DeserializeAsync<ReturnObj>(stream, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        //}
    }
}
