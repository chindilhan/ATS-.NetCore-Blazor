using Stx.Shared.Models.CRM;
using Stx.Shared.Models.Parm;
using Stx.Shared.Status;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Stx.Shared.Interfaces.CRM
{
    public interface ICorporatePublicDataService
    {
        public Task<CorporatePublicDTO> GetRecordByID(int id, int candidateID);
        //public Task<List<CorporatePublicDTO>> Search(string keyword, string location, int candidateID);
        public Task<List<CorporatePublicDTO>> Search(HrJobSearchParmDTO searchParm);

        //public CorporatePublicDTO UpdateRecord(CorporatePublicDTO entry, EntryState entryState, string userId); //Submit Job 

    }
}
