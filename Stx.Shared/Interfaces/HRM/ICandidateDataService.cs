using Stx.Shared.Bps;
using Stx.Shared.Common;
using Stx.Shared.Status;
using System.Collections.Generic;
using System.Threading.Tasks;
using Stx.Shared.Models.HRM;
using Stx.Shared.Models.DTO.HRM;
using Microsoft.AspNetCore.Http;

namespace Stx.Shared.Interfaces.HRM
{
    public interface ICandidateDataService
    {
        //Task<List<HrCandidate>> GetAllRecords();
        Task<HrCandidate> GetRecordByID(int id);
        Task<HrCandidate> GetRecordPublicByID(int id);
        Task<HrCandidate> GetRecordByCD(string code);
        
        Task<List<HrCandidateJobStatDTO>> GetSavedJobs(int id);
        Task<List<HrCandidateJobStatDTO>> GetAppliedJobs(int id);

        Task<HrCandidate> UpdateRecord(HrCandidate record, EntryState st, string userId);
        Task<HrCandidate> PartialUpdate(HrCandidate record, string updateDivCode);

        Task<List<HrCandidateMultiData>> GetCandidateMultiData(int candidateId, string recordType);
        Task<List<HrCandidateMultiData>> UpdateCandidateMultiData(List<HrCandidateMultiData> candidateMultiDatas, bool isDropAndCreate);
        Task<bool> UploadCandidateResumes(IFormFile attchmnt1, IFormFile attchmnt2, List<HrCandidateMultiData> candidateMultiDatas);
        Task<bool> UploadCandidateResumes(IFormFile attchmnt1, HrCandidateMultiData candidateMultiData);
        Task<bool> DeleteCandidateFile(int candidateId, string filenName);


        Task<List<HrCandidateExperience>> GetExperiences(int candidateId, int recId = 0);
        Task<List<HrCandidateEducation>> GetEducations(int candidateId, int recId = 0);
        Task<List<HrCandidateCertificate>> GetCertificates(int candidateId, int recId=0);
        Task<List<HrCandidateSkill>> GetSkills(int candidateId, int recId = 0);
        Task<List<HrCandidateLanguage>> GetLanguages(int candidateId, int recId = 0);

        Task<HrCandidateExperience> UpdateExperiences(HrCandidateExperience entry);
        Task<HrCandidateEducation> UpdateEducations(HrCandidateEducation entry);
        Task<HrCandidateCertificate> UpdateCertificates(HrCandidateCertificate entry);
        Task<List<HrCandidateSkill>> UpdateSkills(List<HrCandidateSkill> entry);
        Task<List<HrCandidateLanguage>> UpdateLanguages(List<HrCandidateLanguage> entry);
        Task<bool> UpdateBookmark(int id, int jobOrderId, string bookmarkedStatus);


        Task<ReturnObj> DeleteRecord(int docnum, string userId);
        Task<bool> DeleteResumeComponent(string docType, int candidateId, int entryId);
    }
}
