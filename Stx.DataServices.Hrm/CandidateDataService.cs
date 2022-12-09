using Microsoft.AspNetCore.Http;
using Stx.Shared;
using Stx.Shared.Common;
using Stx.Shared.Extensions.Http;
using Stx.Shared.Interfaces;
using Stx.Shared.Interfaces.HRM;
using Stx.Shared.Models.DTO.HRM;
using Stx.Shared.Models.HRM;
using Stx.Shared.Services;
using Stx.Shared.Status;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Stx.DataServices.Hrm
{
    public class CandidateDataService : ICandidateDataService
	{
        private readonly IApiHelperDataService _apiHelperDataService;
        public CandidateDataService(IApiHelperDataService apiHelperDataService)
        {
            _apiHelperDataService = apiHelperDataService;
        }
        //public CandidateDataService(string apiAddr)
        //{
        //    HttpClient httpClient = new HttpClient() { BaseAddress = new System.Uri(apiAddr) };
        //    _apiHelperDataService = new ApiHelperDataService(httpClient);
        //}

        public async Task<List<HrCandidate>> GetAllRecords()
        {
            throw new NotImplementedException();
        }

        public async Task<HrCandidate> GetRecordByID(int id)
        {
            using var response = await _apiHelperDataService.GetDataByID(id, "Candidate");
            {
                await response.EnsureSuccessStatusCode2();
                using var stream = await response.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync<HrCandidate>(stream, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            }
        }

        public async Task<HrCandidate> GetRecordByCD(string code)
        {           
            using var response = await _apiHelperDataService.GetDataByCD(code, "Candidate");
            {
                await response.EnsureSuccessStatusCode2();
                using var stream = await response.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync<HrCandidate>(stream, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            }
        }

        #region Candidate-MultiData
        public async Task<List<HrCandidateMultiData>> GetCandidateMultiData(int candidateId, string recordType)
        {
            string endpointWithParm = @$"Candidate/MultiData/{candidateId}/{recordType}";
            using var response = await _apiHelperDataService.GetData(endpointWithParm);
            {
                await response.EnsureSuccessStatusCode2();
                using var stream = await response.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync<List<HrCandidateMultiData>>(stream, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            }
        }

        public async Task<List<HrCandidateMultiData>> UpdateCandidateMultiData(List<HrCandidateMultiData> candidateMultiDatas, bool isDropAndCreate)
        {
            string endpointWithParm = @$"Candidate/MultiData/{isDropAndCreate}";
            var serializeJson = new StringContent(JsonSerializer.Serialize(candidateMultiDatas), Encoding.UTF8, "application/json");
            using var response = await _apiHelperDataService.PostData(endpointWithParm, serializeJson);
            {
                await response.EnsureSuccessStatusCode2();
                using var stream = await response.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync<List<HrCandidateMultiData>>(stream, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            }
        }

        public async Task<bool> UploadCandidateResumes(IFormFile attchmnt1, HrCandidateMultiData candidateMultiData) 
        {
            return await this.UploadCandidateFiles(new List<IFormFile> { attchmnt1}, new List<HrCandidateMultiData> { candidateMultiData });            
        }
        public async Task<bool> UploadCandidateResumes(IFormFile attchmnt1, IFormFile attchmnt2, List<HrCandidateMultiData> candidateMultiDatas)
        {
            return await this.UploadCandidateFiles(new List<IFormFile> { attchmnt1, attchmnt2 }, candidateMultiDatas);
        }
        private async Task<bool> UploadCandidateFiles(List<IFormFile> attchmnts, List<HrCandidateMultiData> candidateMultiDatas)
        {
            var candidateMultiDataJsn = new StringContent(JsonSerializer.Serialize(candidateMultiDatas), Encoding.UTF8, "application/json");

            var multiContent = new MultipartFormDataContent();
            multiContent.Add(candidateMultiDataJsn, "candidateMultiDatas");

            foreach (var file in attchmnts)
            {
                HttpContent fileStreamContent = new StreamContent(file.OpenReadStream());
                multiContent.Add(fileStreamContent, "data", file.FileName);
            }

            //HttpContent file1StreamContent = new StreamContent(attchmnt1.OpenReadStream());
            //HttpContent file2StreamContent = new StreamContent(attchmnt2.OpenReadStream());
            //var multiContent = new MultipartFormDataContent
            //{
            //    { file1StreamContent, "attachments", attchmnt1.FileName},
            //    { file2StreamContent, "attachments", attchmnt2.FileName },
            //};

            string endpointWithParm = @$"Candidate/ResumeFile/Upload";
            using var response = await _apiHelperDataService.PostData(endpointWithParm, multiContent);
            {
                await response.EnsureSuccessStatusCode2();
                using var stream = await response.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync<bool>(stream, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            }
        }
        public async Task<bool> DeleteCandidateFile(int candidateId, string filenName)
        {
            string endpointWithParm = @$"Candidate/ResumeFile/Delete/{candidateId}/{filenName}";

            using var response = await _apiHelperDataService.DeleteData(endpointWithParm);
            {
                await response.EnsureSuccessStatusCode2();
                using var stream = await response.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync<bool>(stream, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            }
        }
        #endregion

        #region GET Resume data -----------------------------------
        public async Task<List<HrCandidateExperience>> GetExperiences(int candidateId, int recId=0)
        {
            string endpointWithParm = @$"Candidate/Resume/{candidateId}/{recId}/Experiences";
            using var response = await _apiHelperDataService.GetData(endpointWithParm);
            {
                await response.EnsureSuccessStatusCode2();
                using var stream = await response.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync<List<HrCandidateExperience>>(stream, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            }
        }
        public async Task<List<HrCandidateEducation>> GetEducations(int candidateId, int recId = 0)
        {
            string endpointWithParm = @$"Candidate/Resume/{candidateId}/{recId}/Educations";
            using var response = await _apiHelperDataService.GetData(endpointWithParm);
            {
                await response.EnsureSuccessStatusCode2();
                using var stream = await response.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync<List<HrCandidateEducation>>(stream, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            }
        }
        public async Task<List<HrCandidateCertificate>> GetCertificates(int candidateId, int recId = 0)
        {
            string endpointWithParm = @$"Candidate/Resume/{candidateId}/{recId}/Certificates";
            using var response = await _apiHelperDataService.GetData(endpointWithParm);
            {
                await response.EnsureSuccessStatusCode2();
                using var stream = await response.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync<List<HrCandidateCertificate>>(stream, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            }
        }
        public async Task<List<HrCandidateSkill>> GetSkills(int candidateId, int recId = 0)
        {
            string endpointWithParm = @$"Candidate/Resume/{candidateId}/{recId}/Skills";
            using var response = await _apiHelperDataService.GetData(endpointWithParm);
            {
                await response.EnsureSuccessStatusCode2();
                using var stream = await response.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync<List<HrCandidateSkill>>(stream, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            }
        }
        public async Task<List<HrCandidateLanguage>> GetLanguages(int candidateId, int recId = 0)
        {
            string endpointWithParm = @$"Candidate/Resume/{candidateId}/{recId}/Languages";
            using var response = await _apiHelperDataService.GetData(endpointWithParm);
            {
                await response.EnsureSuccessStatusCode2();
                using var stream = await response.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync<List<HrCandidateLanguage>>(stream, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            }
        } 
        #endregion

        public async Task<HrCandidate> UpdateRecord(HrCandidate record, EntryState st, string userId)
        {
            var serializeJson = new StringContent(JsonSerializer.Serialize(record), Encoding.UTF8, "application/json");
            using var response = await _apiHelperDataService.PostData("Candidate", serializeJson);
            {
                await response.EnsureSuccessStatusCode2();
                using var stream = await response.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync<HrCandidate>(stream, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            }
        }
        public async Task<HrCandidate> PartialUpdate(HrCandidate record, string updateDivCode)
        {
            var serializeJson = new StringContent(JsonSerializer.Serialize(record), Encoding.UTF8, "application/json");
            using var response = await _apiHelperDataService.PatchData($"Candidate/{updateDivCode}", serializeJson);
            {
                await response.EnsureSuccessStatusCode2();
                using var stream = await response.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync<HrCandidate>(stream, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            }
        }

        public async Task<ReturnObj> DeleteRecord(int docnum, string userId)
        {
            using var response = await _apiHelperDataService.DeleteRecord("Candidate", docnum, "");
            {
                await response.EnsureSuccessStatusCode2();
                using var stream = await response.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync<ReturnObj>(stream, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            }
        }

        public async Task<HrCandidate> GetRecordPublicByID(int id)
        {
            using var response = await _apiHelperDataService.GetDataByID(id, "Candidate/Public");
            {
                await response.EnsureSuccessStatusCode2();
                using var stream = await response.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync<HrCandidate>(stream, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            }
        }

        public async Task<HrCandidateExperience> UpdateExperiences(HrCandidateExperience entry)
        {
            var serializeJson = new StringContent(JsonSerializer.Serialize(entry), Encoding.UTF8, "application/json");
            using var response = await _apiHelperDataService.PostData("Candidate/Experiences", serializeJson);
            {
                await response.EnsureSuccessStatusCode2();
                using var stream = await response.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync<HrCandidateExperience>(stream, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            }
        }

        public async Task<HrCandidateEducation> UpdateEducations(HrCandidateEducation entry)
        {
            var serializeJson = new StringContent(JsonSerializer.Serialize(entry), Encoding.UTF8, "application/json");
            using var response = await _apiHelperDataService.PostData("Candidate/Educations", serializeJson);
            {
                await response.EnsureSuccessStatusCode2();
                using var stream = await response.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync<HrCandidateEducation>(stream, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            }
        }

        public async Task<HrCandidateCertificate> UpdateCertificates(HrCandidateCertificate entry)
        {
            var serializeJson = new StringContent(JsonSerializer.Serialize(entry), Encoding.UTF8, "application/json");
            using var response = await _apiHelperDataService.PostData("Candidate/Certificates", serializeJson);
            {
                await response.EnsureSuccessStatusCode2();
                using var stream = await response.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync<HrCandidateCertificate>(stream, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            }
        }

        public async Task<List<HrCandidateSkill>> UpdateSkills(List<HrCandidateSkill> entry)
        {
            var serializeJson = new StringContent(JsonSerializer.Serialize(entry), Encoding.UTF8, "application/json");
            using var response = await _apiHelperDataService.PostData("Candidate/Skills", serializeJson);
            {
                await response.EnsureSuccessStatusCode2();
                using var stream = await response.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync<List<HrCandidateSkill>>(stream, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            }
        }

        public async Task<List<HrCandidateLanguage>> UpdateLanguages(List<HrCandidateLanguage> entry)
        {
            var serializeJson = new StringContent(JsonSerializer.Serialize(entry), Encoding.UTF8, "application/json");
            using var response = await _apiHelperDataService.PostData("Candidate/Languages", serializeJson);
            {
                await response.EnsureSuccessStatusCode2();
                using var stream = await response.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync<List<HrCandidateLanguage>>(stream, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            }
        }

        public async Task<List<HrCandidateJobStatDTO>> GetSavedJobs(int id)
        {
            string endpointWithParm = @$"Candidate/Lists/{id}/Saved";
            using var response = await _apiHelperDataService.GetData(endpointWithParm);
            {
                await response.EnsureSuccessStatusCode2();
                using var stream = await response.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync<List<HrCandidateJobStatDTO>>(stream, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            }
        }

        public async Task<List<HrCandidateJobStatDTO>> GetAppliedJobs(int id)
        {
            string endpointWithParm = @$"Candidate/Lists/{id}/Applied";
            using var response = await _apiHelperDataService.GetData(endpointWithParm);
            {
                await response.EnsureSuccessStatusCode2();
                using var stream = await response.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync<List<HrCandidateJobStatDTO>>(stream, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            }
        }  
        
        public async Task<bool> UpdateBookmark(int id, int jobOrderId, string bookmarkedStatus)
        {
            string endpointWithParm = @$"Candidate/Stat/{id}/{jobOrderId}/Bookmark/{bookmarkedStatus}";
            using var response = await _apiHelperDataService.PostData(endpointWithParm, null);
            {
                await response.EnsureSuccessStatusCode2();
                using var stream = await response.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync<bool>(stream, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            }
        }

        /// <summary>
        /// Delete a CERT, EDUC or EXPE resume component.
        /// </summary>
		/// <param name="docType">Doc Type (values: CERT, EDUC, EXPE) </param>
		/// <param name="candidateId"> Candidate Id</param>
		/// <param name="recId"> Record id </param>
        /// <returns></returns>
        public async Task<bool> DeleteResumeComponent(string docType, int candidateId, int recId)
        {
            string endpointWithParm = @$"Candidate/Resume/{docType}/Delete/{candidateId}/{recId}";
            using var response = await _apiHelperDataService.DeleteData(endpointWithParm);
            {
                await response.EnsureSuccessStatusCode2();
                using var stream = await response.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync<bool>(stream, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            }
        }

       
    }
}
