using Stx.Shared.Interfaces;
using Stx.Shared.Interfaces.Common;
using Stx.Shared.Models.Common;
using Stx.Shared.Status;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;


namespace Stx.HRM.Services.Common
{
    public class ScheduleDataService : IScheduleDataService
    {
        private readonly IApiHelperDataService _apiHelperDataService;
        public ScheduleDataService(IApiHelperDataService apiHelperDataService)
        {
            _apiHelperDataService = apiHelperDataService;
        }

        public async Task<Schedule> GetRecordID(int scheduleId)
        {
            using var response = await _apiHelperDataService.GetDataByID(scheduleId, "Schedule");
            {
                response.EnsureSuccessStatusCode();
                using var stream = await response.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync<Schedule>(stream, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            }
        }

        public async Task<bool> UpdateRecord(Schedule record, EntryState entryState, string userId)
        {
            var serializeJson = new StringContent(JsonSerializer.Serialize(record), Encoding.UTF8, "application/json");
            var response = await _apiHelperDataService.PostData("Schedule", serializeJson);
            response.EnsureSuccessStatusCode();
            return true;
        }

    }
}
