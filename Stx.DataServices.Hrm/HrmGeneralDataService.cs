using Stx.Shared.Common;
using Stx.Shared.Extensions.Http;
using Stx.Shared.Interfaces;
using Stx.Shared.Interfaces.HRM;
using Stx.Shared.Models;
using Stx.Shared.Models.HRM;
using Stx.Shared.Models.Parm;
using Stx.Shared.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Stx.DataServices.Hrm
{
    public class HrmGeneralDataService : IHrmGeneralDataService
    {
        private readonly IApiHelperDataService _apiHelperDataService;

        public HrmGeneralDataService(IApiHelperDataService apiHelperDataService)
        {
            _apiHelperDataService = apiHelperDataService;
        }
                
        public async Task<List<ComboInt>> GetJobIndustryList()
        {
            using var response = await _apiHelperDataService.GetData($"Hrm/JobIndustries");
            {
                await response.EnsureSuccessStatusCode2();
                using var stream = await response.Content.ReadAsStreamAsync();
                var list = await JsonSerializer.DeserializeAsync<List<HrJobIndustry>>(stream, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
                return list.Select(x => new ComboInt(x.ID, x.Name)).ToList();
            }
        }

        public async Task<List<ComboInt>> GetJobCategoryList()
        {
            using var response = await _apiHelperDataService.GetAllRecords("Hrm/JobCategories"); //JobRole model is To Add
            {
                response.EnsureSuccessStatusCode();
                using var stream = await response.Content.ReadAsStreamAsync();
                var data = await JsonSerializer.DeserializeAsync<List<ComboInt>>(stream, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
                return data.Select(x => new ComboInt(x.Value, x.Text)).ToList();
            }
        }

        //#region TO BE REMOVED LATER
        //public Task<IEnumerable<HrJobCategory>> GetAllJobCategories()
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<HrJobCategory> GetJobCategoryById(int jobCategoryId)
        //{
        //    throw new NotImplementedException();
        //}
        //#endregion

        #region GENERAL DATA 

        public async Task<List<ComboShort>> GetCountryList()
        {
            using var response = await _apiHelperDataService.GetAllRecords("stxgeneral/Countries");
            {
                response.EnsureSuccessStatusCode();
                using var stream = await response.Content.ReadAsStreamAsync();
                var data = await JsonSerializer.DeserializeAsync<List<Country>>(stream, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
                return data.Select(x => new ComboShort(x.CountryID, x.Name)).ToList();
            }
        }

        public async Task<List<ComboInt>> GetCountryCitiesList(int countryId)
        {
            using var response = await _apiHelperDataService.GetAllRecords($"stxgeneral/Cities/{countryId}");
            {
                response.EnsureSuccessStatusCode();
                using var stream = await response.Content.ReadAsStreamAsync();
                var data = await JsonSerializer.DeserializeAsync<List<City>>(stream, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
                return data.Select(x => new ComboInt(x.CityID, x.Name)).ToList();
            }
        }

        public async Task<List<ComboStr>> GetCurrencyList()
        {
            using var response = await _apiHelperDataService.GetAllRecords("stxgeneral/Currencies");
            {
                response.EnsureSuccessStatusCode();
                using var stream = await response.Content.ReadAsStreamAsync();
                var data = await JsonSerializer.DeserializeAsync<List<Currency>>(stream, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
                return data.Select(x => new ComboStr(x.CurrCD, x.Name)).ToList();
            }
        }
        #endregion

        public async Task<List<ComboShort>> GetPayCycleList() //Salary-Unit|Pay-Cycle
        {
            return new List<ComboShort>(new ComboShort[] {
                new ComboShort( 1, "Monthly" ),
                new ComboShort( 2, "Yearly"),
                new ComboShort( 3, "Weekly" ),
                new ComboShort( 4, "Daily" ),
                new ComboShort( 9, "Variable")
            });
        }
        public async Task<List<ComboShort>> GetEmploymentTypeList(bool isIncludeRemote = false) //Job-Type|Employment-Type
        {
            var list = new List<ComboShort>(new ComboShort[] {
                new ComboShort( 10, "Full-time" ),
                new ComboShort( 20, "Part-time"),
                new ComboShort( 30, "Contract" ),
                new ComboShort( 40, "Internship/Trainee" ),
                new ComboShort( 60, "Freelancer"),
                new ComboShort( 70, "Temporary"),
                new ComboShort( 80, "Volunteer"),
            });
            if (isIncludeRemote) list.Add(new ComboShort(90, "Work Remotely"));
            list.Add(new ComboShort(100, "Unspecified"));
            return list;
        }

        public async Task<List<ComboShort>> GetCareerLevelList() //Career-Level|Experience-Type
        {
            return new List<ComboShort>(new ComboShort[] {
                new ComboShort(10, "Student/Internship" ),
                new ComboShort(20, "Fresh Graduate" ),
                new ComboShort(30, "Entry Level" ),
                new ComboShort(40, "Associate Level"),
                new ComboShort(50, "Mid-Senior Level" ),
                new ComboShort(60, "Executive Level" ),
                new ComboShort(70, "Director/Head" ),
                new ComboShort(80, "Senior Executive" ),
                new ComboShort(90, "Not Applicable" ),
                new ComboShort(100, "Unspecified"),
            });
        }

        public async Task<List<ComboShort>> GetEducationLevelList() //Education-Level
        {
            return new List<ComboShort>(new ComboShort[] {
                new ComboShort( 10, "High school or equivalent"),
                new ComboShort( 20, "Certification / Diploma" ),
                new ComboShort( 30, "Associate Degree" ),
                new ComboShort( 40, "Bachelor's degree / Higher diploma" ),
                new ComboShort( 50, "Master's degree"),
                new ComboShort( 60, "Doctorate"),
                new ComboShort( 70, "Professional"),
                new ComboShort( 100, "Unspecified" ),
            });
        }

        public List<ComboStr> GetRecruitmentStages() //Recruitment-Stage
        {
            return new List<ComboStr>(new ComboStr[] {
                new ComboStr("sourced", "Sourced"),
                new ComboStr("applied", "Applied"),
                new ComboStr("shortlisted", "Shortlisted"),
                new ComboStr("assessment", "Assessment"),
                new ComboStr("phone-screen", "Phone-Screen"),
                new ComboStr("interview", "Interview"),
                new ComboStr("offer", "Offer"),
                new ComboStr("hired", "Hired"),
            });
        }

        public List<ComboStr> GetRecruitmentStageCategories() //Recruitment-Stage-Categories
        {
            return new List<ComboStr>(new ComboStr[] {
                new ComboStr("sourcing", "Sourcing"),
                new ComboStr("shortlist", "Shortlist"),
                new ComboStr("assessment", "Assessment"),
                new ComboStr("interview", "Interview"),
                new ComboStr("offer", "Offer"),
                new ComboStr("hire", "Hire"),
            });
        }


    }
}
