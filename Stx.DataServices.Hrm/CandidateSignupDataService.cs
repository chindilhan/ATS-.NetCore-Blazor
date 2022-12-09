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
    public class CandidateSignupDataService : ICandidateSignupDataService
    {
        private readonly IApiHelperDataService _apiHelperDataService;
        public CandidateSignupDataService(IApiHelperDataService apiHelperDataService)
        {
            _apiHelperDataService = apiHelperDataService;
        }
        //public CandidateSignupDataService(string apiAddr)
        //{
        //    HttpClient httpClient = new HttpClient() { BaseAddress = new System.Uri(apiAddr) };
        //    _apiHelperDataService = new ApiHelperDataService(httpClient);
        //}


        public async Task<bool> Signup(UserSignupDTO entry)
        {
            var serializeJson = new StringContent(JsonSerializer.Serialize(entry), Encoding.UTF8, "application/json");
            using var response = await _apiHelperDataService.PostData("CandidateSignup", serializeJson);
            {
                await response.EnsureSuccessStatusCode2();
                using var stream = await response.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync<bool>(stream, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            }
        }

    }
}
