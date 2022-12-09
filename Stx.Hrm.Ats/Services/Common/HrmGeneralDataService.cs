using Stx.Shared.Common;
using Stx.Shared.Interfaces;
using Stx.Shared.Interfaces.HRM;
using Stx.Shared.Models;
using Stx.Shared.Models.HRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Stx.HRM.Services.Common
{
    public class HrmGeneralDataService : IHrmGeneralDataService
    {
        private readonly IApiHelperDataService _apiHelperDataService;
        public HrmGeneralDataService(IApiHelperDataService apiHelperDataService)
        {
            _apiHelperDataService = apiHelperDataService;
        }


        #region TO BE REMOVED LATER
        public Task<IEnumerable<HrJobCategory>> GetAllJobCategories()
        {
            throw new NotImplementedException();
        }

        public Task<HrJobCategory> GetJobCategoryById(int jobCategoryId)
        {
            throw new NotImplementedException();
        }
        #endregion

        public async Task<List<ComboShort>> GetCountryList()
        {
            using var response = await _apiHelperDataService.GetAllRecords("StxGeneral/Countries");
            {
                response.EnsureSuccessStatusCode();
                using var stream = await response.Content.ReadAsStreamAsync();
                var data = await JsonSerializer.DeserializeAsync<List<Country>>(stream, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
                return data.Select(x => new ComboShort(x.CountryID, x.Name)).ToList();
            }

            //if (response != null)
            //{
            //    List<ComboShort> ret = new List<ComboShort>();
            //return await JsonSerializer.DeserializeAsync<List<Country>>(response.Content, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            //    data.ForEach(x => ret.Add(new ComboShort(x.CountryID, x.Name)));
            //    return ret;
            //}
            //else
            //{
            //    return null;
            //}
        }

        public async Task<List<ComboInt>> GetCountryCitiesList(int countryId)
        {
            using var response = await _apiHelperDataService.GetAllRecords($"StxGeneral/Cities/{countryId}");
            {
                response.EnsureSuccessStatusCode();
                using var stream = await response.Content.ReadAsStreamAsync();
                var data = await JsonSerializer.DeserializeAsync<List<City>>(stream, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
                return data.Select(x => new ComboInt(x.CityID, x.Name)).ToList();
            }
            //if (response != null)
            //{
            //    var data = await JsonSerializer.DeserializeAsync<List<City>>(response, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            //    List<ComboInt> ret = new List<ComboInt>();
            //    data.ForEach(x => ret.Add(new ComboInt(x.CityID, x.Name)));
            //    return ret;
            //}
            //else
            //{
            //    return null;
            //}
        }

        public async Task<List<ComboStr>> GetCurrencyList()
        {
            using var response = await _apiHelperDataService.GetAllRecords("StxGeneral/Currencies");
            {
                response.EnsureSuccessStatusCode();
                using var stream = await response.Content.ReadAsStreamAsync();
                var data = await JsonSerializer.DeserializeAsync<List<Currency>>(stream, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
                return data.Select(x => new ComboStr(x.CurrCD, x.Name)).ToList();
            }

            //if (response != null)
            //{
            //    var data = await JsonSerializer.DeserializeAsync<List<Currency>>(response, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            //    List<ComboStr> ret = new List<ComboStr>();
            //    data.ForEach(x => ret.Add(new ComboStr(x.CurrCD, x.Name)));
            //    return ret;
            //}
            //else
            //{
            //    return null;
            //}
        }


        public async Task<List<ComboInt>> GetJobIndustryList()
        {
            using var response = await _apiHelperDataService.GetAllRecords("Hrm/JobIndustries");
            {
                response.EnsureSuccessStatusCode();
                using var stream = await response.Content.ReadAsStreamAsync();
                var data = await JsonSerializer.DeserializeAsync<List<HrJobIndustry>>(stream, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
                return data.Select(x => new ComboInt(x.ID, x.Name)).ToList();
            }

            //if (response != null)
            //{
            //    var data = await JsonSerializer.DeserializeAsync<List<HrJobIndustry>>(response, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            //    List<ComboInt> ret = new List<ComboInt>();
            //    data.ForEach(x => ret.Add(new ComboInt(x.ID, x.Name)));
            //    return ret;
            //}
            //else
            //{
            //    return null;
            //}
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
            //if (response != null)
            //{
            //    var data = await JsonSerializer.DeserializeAsync<List<HrJobCategory>>(response, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            //    List<ComboInt> ret = new List<ComboInt>();
            //    data.ForEach(x => ret.Add(new ComboInt(x.ID, x.Name)));
            //    return ret;
            //}
            //else
            //{
            //    return null;
            //}
        }


        public async Task<List<ComboShort>> GetPayCycleList() //Model: SalaryUnit
        {
            return new List<ComboShort>(new ComboShort[] {
                new ComboShort( 1, "Monthly" ),
                new ComboShort( 2, "Yearly"),
                new ComboShort( 3, "Weekly" ),
                new ComboShort( 4, "Daily" ),
                new ComboShort( 9, "Variable")
            });
        }
        public async Task<List<ComboShort>> GetEmploymentTypeList(bool isIncludeRemote = false)
        {
           
            var list =  new List<ComboShort>(new ComboShort[] {
                new ComboShort( 0, "Unspecified"),
                new ComboShort( 1, "Full-time" ),
                new ComboShort( 2, "Part-time"),
                new ComboShort( 3, "Contract" ),
                new ComboShort( 4, "Internship/Trainee" ),
                new ComboShort( 6, "Freelancer"),
                new ComboShort( 7, "Temporary"),
                new ComboShort( 8, "Volunteer"),
            });
            if (isIncludeRemote) list.Add(new ComboShort(9, "Work Remotely"));
            return list;
        }

        public async Task<List<ComboShort>> GetCareerLevelList()
        {
            return new List<ComboShort>(new ComboShort[] {
                new ComboShort(0, "Unspecified"),
                new ComboShort(1, "Internship/Student" ),
                new ComboShort(2, "Fresh Graduate" ),
                new ComboShort(3, "Entry Level" ),
                new ComboShort(4, "Associate Level"),
                new ComboShort(5, "Mid-Senior Level" ),
                new ComboShort(6, "Executive Level" ),
                new ComboShort(7, "Director/Head" ),
                new ComboShort(8, "Senior Executive" ),
                new ComboShort(9, "Not Applicable" ),
            });
        }

        public async Task<List<ComboShort>> GetEducationLevelList()
        {
            return new List<ComboShort>(new ComboShort[] {
                new ComboShort( 0, "Unspecified" ),
                new ComboShort( 1, "High school or equivalent"),
                new ComboShort( 2, "Certification / Diploma" ),
                new ComboShort( 3, "Associate Degree" ),
                new ComboShort( 4, "Bachelor's degree / Higher diploma" ),
                new ComboShort( 5, "Master's degree"),
                new ComboShort( 6, "Doctorate"),
                new ComboShort( 7, "Professional"),
            });
        }

        public List<ComboStr> GetRecruitmentStages()
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

        public List<ComboStr> GetRecruitmentStageCategories()
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
