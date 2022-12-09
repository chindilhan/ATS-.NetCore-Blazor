using Stx.Shared.Interfaces;
using Stx.Shared.Interfaces.CRM;
using Stx.Shared.Models.CRM;
using Stx.Shared.Status;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Stx.HRM.Services.CRM
{
    public class CorporateDataService : ICorporateDataService
    {
        private readonly IApiHelperDataService _apiHelperDataService;
        public CorporateDataService(IApiHelperDataService apiHelperDataService)
        {
            _apiHelperDataService = apiHelperDataService;
        }

        public async Task<List<Corporate>> GetAllRecords()
        {
            var response = await _apiHelperDataService.GetAllRecords("Corporate");
            {
                response.EnsureSuccessStatusCode();
                using var stream = await response.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync<List<Corporate>>(stream, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            }
        }

        public async Task<Corporate> GetRecordByID(int id)
        {
            var response = await _apiHelperDataService.GetDataByID(id, "Corporate");
            {
                response.EnsureSuccessStatusCode();
                using var stream = await response.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync<Corporate>(stream, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            }
        }

        public async Task<Corporate> GetRecordByCD(string code)
        {
            using var response = await _apiHelperDataService.GetDataByCD(code, "Corporate");
            {
                response.EnsureSuccessStatusCode();
                using var stream = await response.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync<Corporate>(stream, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            }
        }

        public async Task<Corporate> UpdateRecord(Corporate record, EntryState st, string userId)
        {
            var serializeJson = new StringContent(JsonSerializer.Serialize(record), Encoding.UTF8, "application/json");
            var response = await _apiHelperDataService.PostData("Corporate", serializeJson);
                       
            if (response.IsSuccessStatusCode)
            {
                return await JsonSerializer.DeserializeAsync<Corporate>(await response.Content.ReadAsStreamAsync());
            }
            else if (response.Content != null)
            {
                throw new System.Exception("");
            }

            return null;
        }

    }
}
