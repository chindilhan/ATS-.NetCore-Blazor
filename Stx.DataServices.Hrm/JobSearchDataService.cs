using Stx.Shared.Extensions.Http;
using Stx.Shared.Interfaces;
using Stx.Shared.Interfaces.HRM;
using Stx.Shared.Models.HRM;
using Stx.Shared.Models.Parm;
using Stx.Shared.Services;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Stx.DataServices.Hrm
{
    public class JobSearchDataService : IJobSearchDataService
    {
        private readonly IApiHelperDataService _apiHelperDataService;
        public JobSearchDataService(IApiHelperDataService apiHelperDataService)
        {
            _apiHelperDataService = apiHelperDataService;
        }

        //public JobSearchDataService(string apiAddr)
        //{
        //    HttpClient httpClient = new HttpClient() { BaseAddress = new System.Uri(apiAddr) };
        //    //_apiHelperDataService = new ApiHelperDataService(httpClient);
        //    _apiHelperDataService = apiHelperDataService;
        //}

        public async Task<List<HrJobOrderSearch>> Search(HrJobSearchParmDTO parms)
        {
            var serializeJson = new StringContent(JsonSerializer.Serialize(parms), Encoding.UTF8, "application/json");

            using var response = await _apiHelperDataService.PostData("JobSearch", serializeJson);
            {
                await response.EnsureSuccessStatusCode2();
                using var stream = await response.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync<List<HrJobOrderSearch>>(stream, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            }
        }

        //public async Task<List<HrJobOrderSearch>> Search(string keyword, string location, string jobindustry, int candidateid)
        //{
        //    HrJobSearchParmDTO record = new HrJobSearchParmDTO(keyword, location, new List<string>() { jobindustry }, candidateid);
        //    var serializeJson = new StringContent(JsonSerializer.Serialize(record), Encoding.UTF8, "application/json");
        //    string endpointWithParm = @$"JobSearch/Resume/{candidateId}/{recId}/Skills";

        //    using var response = await _apiHelperDataService.GetData("JobSearch", serializeJson);
        //    {
        //        await response.EnsureSuccessStatusCode2();
        //        using var stream = await response.Content.ReadAsStreamAsync();
        //        return await JsonSerializer.DeserializeAsync<List<HrJobOrderSearch>>(stream, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        //    }
        //}

    }
}
