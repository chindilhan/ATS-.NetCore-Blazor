using Stx.Shared.Common;
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
    public class JobOrderDataService : IJobOrderDataService
    {
        private readonly IApiHelperDataService _apiHelperDataService;
        public JobOrderDataService(IApiHelperDataService apiHelperDataService)
        {
            _apiHelperDataService = apiHelperDataService;
        }

        public async Task<HrJobOrder> GetRecordByID(int id)
        {
            var response = await _apiHelperDataService.GetDataByID(id, "JobOrder");
            {
                response.EnsureSuccessStatusCode();
                using var stream = await response.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync<HrJobOrder>(stream, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            }
        }

        public async Task<List<HrJobSummaryDTO>> GetCorporateJobList(int id)
        {
            HrmParmDTO hrmParmDTO = new HrmParmDTO(FilterType.CorpJobList, new ParmEntryInt(id, "CorpID"));
            var serializeJson = new StringContent(JsonSerializer.Serialize(hrmParmDTO), Encoding.UTF8, "application/json");

            using var response = await _apiHelperDataService.PostData("JobOrder/CorporateFilter", serializeJson);
            response.EnsureSuccessStatusCode();
            using var stream = await response.Content.ReadAsStreamAsync();
            var data = await JsonSerializer.DeserializeAsync<List<HrJobSummaryDTO>>(stream, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            return data;

        }

        public async Task<List<HrJobSummaryMinDTO>> GetCorporateJobListMin(int corpId)
        {
            HrmParmDTO hrmParmDTO = new HrmParmDTO(FilterType.CorpJobList, new ParmEntryInt(corpId, "CorpID"));
            var serializeJson = new StringContent(JsonSerializer.Serialize(hrmParmDTO), Encoding.UTF8, "application/json");

            using var response = await _apiHelperDataService.PostData("JobOrder/CorporateFilter/Min", serializeJson);
            response.EnsureSuccessStatusCode();
            using var stream = await response.Content.ReadAsStreamAsync();
            var data = await JsonSerializer.DeserializeAsync<List<HrJobSummaryMinDTO>>(stream, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            return data;
        }

        public async Task<HrJobSummaryDTO> GetJobSummaryByID(int jobOrderId)
        {
            var response = await _apiHelperDataService.GetDataByID(jobOrderId, "JobOrder/Summary");
            {
                response.EnsureSuccessStatusCode();
                using var stream = await response.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync<HrJobSummaryDTO>(stream, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            }
        }

        public async Task<HrJobOrder> UpdateRecord(HrJobOrder record)
        {
            var serializeJson = new StringContent(JsonSerializer.Serialize(record), Encoding.UTF8, "application/json");
            using var response = await _apiHelperDataService.PostData("JobOrder", serializeJson);
            {
                response.EnsureSuccessStatusCode();
                return await JsonSerializer.DeserializeAsync<HrJobOrder>(await response.Content.ReadAsStreamAsync());
            }
        }
        public async Task<bool?> UpdateQuery(int id, List<ParmStr> records)
        {
            var serializeJson = new StringContent(JsonSerializer.Serialize(records), Encoding.UTF8, "application/json");
            using var response = await _apiHelperDataService.PatchData($"JobOrder/{id}", serializeJson);
            {
                response.EnsureSuccessStatusCode();
                return true;
            }
        }
        public async Task<ReturnObj> DeleteRecord(int docnum, string userId)
        {
            var response = await _apiHelperDataService.DeleteRecord("JobOrder", docnum, "");
            {
                response.EnsureSuccessStatusCode();
                using var stream = await response.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync<ReturnObj>(stream, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            }
        }

        #region Review Questions
        public async Task<List<HrReviewQuestion>> GetReviewQuestions(int jobOrderId)
        {
            var response = await _apiHelperDataService.GetDataByID(jobOrderId, "JobOrder/ReviewQuestions");
            {
                response.EnsureSuccessStatusCode();
                using var stream = await response.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync<List<HrReviewQuestion>>(stream, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            }
        }

        public async Task<List<HrReviewQuestion>> UpdateReviewQuestions(List<HrReviewQuestion> records)
        {
            var serializeJson = new StringContent(JsonSerializer.Serialize(records), Encoding.UTF8, "application/json");
            using var response = await _apiHelperDataService.PostData("JobOrder/ReviewQuestions", serializeJson);
            {
                response.EnsureSuccessStatusCode();
                return await JsonSerializer.DeserializeAsync<List<HrReviewQuestion>>(await response.Content.ReadAsStreamAsync());
            }
        }

        public async Task<bool> DeleteReviewQuestion(int jobOrderId, int Id)
        {
            string urlparm = $"JobOrder/ReviewQuestions/{jobOrderId}/{Id}";
            var response = await _apiHelperDataService.DeleteData(urlparm);
            {
                response.EnsureSuccessStatusCode();
                return true;
            }
        } 
        #endregion
    }
}
