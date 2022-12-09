using Stx.Shared.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Stx.Shared.Interfaces
{
    public interface IIPGeneralDataService //: IDocumentDataService
    {
        Task<List<ComboInt>> GetJobStatusList();

        Task<List<ComboInt>> GetJobCategoryList();

        Task<List<ComboInt>> GetMatterTypeList(int moduleId);

        Task<List<ComboInt>> GetTMStatusList();

        Task<List<ComboInt>> GetNiceClassIDList();
    }
}
