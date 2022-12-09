using System.Collections.Generic;
using System.Threading.Tasks;
using Stx.Shared;
using Stx.Shared.Common;
using Stx.Shared.Models.HRM;

namespace Stx.Shared.Interfaces.HRM
{
    public interface IHrmGeneralDataService
    {
        Task<List<ComboShort>> GetCountryList();
        Task<List<ComboInt>> GetCountryCitiesList(int countryId);
        Task<List<ComboStr>> GetCurrencyList();
        
        //Task<IEnumerable<HrJobCategory>> GetAllJobCategories();
        //Task<HrJobCategory> GetJobCategoryById(int jobCategoryId);

        Task<List<ComboInt>> GetJobIndustryList();
        Task<List<ComboInt>> GetJobCategoryList();

        Task<List<ComboShort>> GetPayCycleList();
        Task<List<ComboShort>> GetEmploymentTypeList(bool isIncludeRemote = false);
        Task<List<ComboShort>> GetCareerLevelList();
        Task<List<ComboShort>> GetEducationLevelList();

        List<ComboStr> GetRecruitmentStages();
        List<ComboStr> GetRecruitmentStageCategories();
    }
}
