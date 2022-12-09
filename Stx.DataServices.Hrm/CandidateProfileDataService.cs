using Microsoft.AspNetCore.Http;
using Stx.Shared;
using Stx.Shared.Extensions.Http;
using Stx.Shared.Interfaces;
using Stx.Shared.Interfaces.HRM;
using Stx.Shared.Models.HRM;
using Stx.Shared.Services;
using Stx.Shared.Status;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Stx.DataServices.Hrm
{
    public class CandidateProfileDataService : ICandidateProfileDataService
    {
        private readonly IApiHelperDataService _apiHelperDataService;
        public CandidateProfileDataService(IApiHelperDataService apiHelperDataService)
        {
            _apiHelperDataService = apiHelperDataService;
        }
        //public CandidateProfileDataService(string apiAddr)
        //{
        //    HttpClient httpClient = new HttpClient() { BaseAddress = new System.Uri(apiAddr) };
        //    _apiHelperDataService = new ApiHelperDataService(httpClient);
        //}


        public async Task<HrCandidateProfile> GetRecordByID(int id)
        {
            using var response = await _apiHelperDataService.GetDataByID(id, "CandidateProfile");
            {
                await response.EnsureSuccessStatusCode2();
                using var stream = await response.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync<HrCandidateProfile>(stream, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            }
        }

        public async Task<HrCandidateProfile> GetRecordByCD(string code)
        {           
            using var response = await _apiHelperDataService.GetDataByCD(code, "CandidateProfile");
            {
                await response.EnsureSuccessStatusCode2();
                using var stream = await response.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync<HrCandidateProfile>(stream, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            }
        }

        public async Task<HrCandidateProfile> UpdateRecord(HrCandidateProfile record, EntryState st, string userId)
        {
            if (st == EntryState.Update)
            {
                var serializeJson = new StringContent(JsonSerializer.Serialize(record), Encoding.UTF8, "application/json");
                using var response = await _apiHelperDataService.PostData("CandidateProfile", serializeJson);
                {
                    await response.EnsureSuccessStatusCode2();
                    using var stream = await response.Content.ReadAsStreamAsync();
                    return await JsonSerializer.DeserializeAsync<HrCandidateProfile>(stream, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
                }
            }
            else
            {
                return null;
            }
        }

        public async Task<bool> UpdateProfileImage(IFormFile file, int candidateId)
        {
            var candidateIdData= new StringContent(candidateId.ToString(), Encoding.UTF8, "application/text");

            var multiContent = new MultipartFormDataContent();
            multiContent.Add(candidateIdData, "candidateId");

            HttpContent fileStreamContent = new StreamContent(file.OpenReadStream());
            multiContent.Add(fileStreamContent, "data", file.FileName);

            string endpointWithParm = @$"CandidateProfile/ProfileImage";
            using var response = await _apiHelperDataService.PostData(endpointWithParm, multiContent);
            {
                await response.EnsureSuccessStatusCode2();
                using var stream = await response.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync<bool>(stream, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            }
        }

    }
}
