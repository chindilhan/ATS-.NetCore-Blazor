using Stx.Shared.Interfaces;
using Stx.Shared.Interfaces.HRM;
using Stx.Shared.Models.HRM;
using Stx.Shared.Models.Parm;
using Stx.Shared.Status;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Stx.HRM.Services.HRM
{
    public class CandidateEvaluateDataService : ICandidateEvaluateDataService
    {
        private readonly IApiHelperDataService _apiHelperDataService;
        public CandidateEvaluateDataService(IApiHelperDataService apiHelperDataService)
        {
            _apiHelperDataService = apiHelperDataService;
        }

        public async Task<HrCandidatePublicDTO> GetRecordByID(int id)
        {
            using var response = await _apiHelperDataService.GetDataByID(id, "CandidateProfile");
            {
                response.EnsureSuccessStatusCode();
                using var stream = await response.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync<HrCandidatePublicDTO>(stream, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            }
        }

        public async Task<HrCandidatePublicDTO> GetRecordByCD(string code)
        {
            using var response = await _apiHelperDataService.GetDataByCD(code, "CandidateProfile");
            {
                response.EnsureSuccessStatusCode();
                using var stream = await response.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync<HrCandidatePublicDTO> (stream, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            }
        }

        public async Task<HrCandidatePublicDTO> Import(HrCandidatePublicDTO record, string userId)
        {
            var serializeJson = new StringContent(JsonSerializer.Serialize(record), Encoding.UTF8, "application/json");
            var response = await _apiHelperDataService.PostData( "CorporateCandidate", serializeJson);

            if (response.IsSuccessStatusCode)
            {
                return await JsonSerializer.DeserializeAsync<HrCandidatePublicDTO>(await response.Content.ReadAsStreamAsync());
            }
            else if (response.Content != null)
            {
                throw new System.Exception("");
            }

            return null;
        }

        public async Task<List<HrCandidatePublicDTO>> Search(HrCandidateParmDTO searchParms)
        {
            var serializeJson = new StringContent(JsonSerializer.Serialize(searchParms), Encoding.UTF8, "application/json");
            var response = await _apiHelperDataService.PostData("CandidatePublic", serializeJson);
            response.EnsureSuccessStatusCode();
            using var stream = await response.Content.ReadAsStreamAsync();
            var data = await JsonSerializer.DeserializeAsync<List<HrCandidatePublicDTO>>(stream, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            return data;

            //return null;
        }

    }
}
