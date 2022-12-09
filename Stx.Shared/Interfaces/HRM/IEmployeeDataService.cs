using System.Collections.Generic;
using System.Threading.Tasks;
using Stx.Shared;
using Stx.Shared.Models.HRM;

namespace Stx.Shared.Interfaces.HRM
{
    public interface IEmployeeDataService
    {
        Task<List<HrEmployee>> GetAllEmployees();
        Task<HrEmployee> GetEmployeeDetails(int employeeId);
        Task<HrEmployee> UpdateRecord(HrEmployee employee);
        Task<bool> DeleteEmployee(int employeeId);
    }
}
