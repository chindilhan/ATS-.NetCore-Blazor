using Stx.Shared.Interfaces;
using Stx.Shared.Interfaces.HRM;
using Stx.Shared.Models.HRM;
using Stx.Shared.Models.Parm;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Stx.HRM.Services.HRM
{
    public class CandidatePublicDataService : ICandidatePublicDataService
    {
        private readonly IApiHelperDataService _apiHelperDataService;
        public CandidatePublicDataService(IApiHelperDataService apiHelperDataService)
        {
            _apiHelperDataService = apiHelperDataService;
        }

        public async Task<HrCandidatePublicDTO> GetRecordByID(int id)
        {
            using var response = await _apiHelperDataService.GetDataByID(id, "CandidatePublic");
            {
                response.EnsureSuccessStatusCode();
                using var stream = await response.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync<HrCandidatePublicDTO>(stream, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            }
        }
        public async Task<HrCandidatePublicDTO> GetRecordByID(string candidateSource, int candidateId)
        {
            return await GetRecordByID(candidateSource, candidateId, null);
        }

        public async Task<HrCandidatePublicDTO> GetRecordByID(string candidateSource, int candidateId, int? jobOrderId)
        {
            string api = "";
            if(jobOrderId.HasValue)
            {
                api = $"CandidatePublic/{candidateSource}/{candidateId}/{jobOrderId.Value}";
            }
            else
            {
                api = $"CandidatePublic/{candidateSource}/{candidateId}";
            }
            using var response = await _apiHelperDataService.GetData(api);
            response.EnsureSuccessStatusCode();
            if (response.IsSuccessStatusCode)
            {
                using var stream = await response.Content.ReadAsStreamAsync();
                var data = await JsonSerializer.DeserializeAsync<HrCandidatePublicDTO>(stream, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
                return data;
            }
            else
            {
                return null;
            }
        }

        public async Task<HrCandidatePublicDTO> GetRecordByCD(string code)
        {
            using var response = await _apiHelperDataService.GetDataByCD(code, "CandidatePublic");
            {
                response.EnsureSuccessStatusCode();
                using var stream = await response.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync<HrCandidatePublicDTO>(stream, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            }

            //if (response != null)
            //{
            //    return await JsonSerializer.DeserializeAsync<HrCandidatePublicDTO>(response, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            //}
            //else
            //{
            //    return null;
            //}

        }

        public async Task<List<HrJobCandidateListDTO>> GetRecordsByJobAndStage(string candidateStage, int jobOrderId)
        {
            string api = $"CandidatePublic/Stage/{candidateStage}/{jobOrderId}";
            using var response = await _apiHelperDataService.GetData(api);

            response.EnsureSuccessStatusCode();
            using var stream = await response.Content.ReadAsStreamAsync();
            var data = await JsonSerializer.DeserializeAsync<List<HrJobCandidateListDTO>>(stream, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            return data;
        }

        public async Task<List<HrCandidatePublicDTO>> Search(HrCandidateParmDTO searchParms)
        {
            var serializeJson = new StringContent(JsonSerializer.Serialize(searchParms), Encoding.UTF8, "application/json");
            var response = await _apiHelperDataService.PostData("CandidatePublic/Search", serializeJson);
            response.EnsureSuccessStatusCode();
            using var stream = await response.Content.ReadAsStreamAsync();
            var data = await JsonSerializer.DeserializeAsync<List<HrCandidatePublicDTO>>(stream, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            return data;

            //return null;
        }

     
    }
}
