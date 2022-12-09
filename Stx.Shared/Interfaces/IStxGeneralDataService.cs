using System.Collections.Generic;
using System.Threading.Tasks;
using Stx.Shared.Models;

namespace Stx.Shared.Interfaces
{
    public interface IStxGeneralDataService
    {
        Task<List<Country>> GetAllCountries();
        Task<Country> GetCountryById(int countryId);
    }
}
