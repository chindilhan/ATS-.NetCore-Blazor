using Stx.Shared.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Stx.Shared.Interfaces
{
    public interface IDocumentDataService
    {
		[ObsoleteAttribute("This method is not implemented yet or discarded. Please use GetNextDocNumberInt instead.", true)]
        Task<DocNumber> GetNextDocNumber(short pageUid);
        Task<int> GetNextDocNumberInt(short pageUid);
    }
}
