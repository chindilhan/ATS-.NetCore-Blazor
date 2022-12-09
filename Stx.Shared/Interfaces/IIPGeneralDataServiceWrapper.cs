using System;
using System.Collections.Generic;
using System.Text;

namespace Stx.Shared.Interfaces
{
    public interface IIPGeneralDataServiceWrapper
    {
        IIPCommonDataService CommonDataRepo { get; }
        
        IIPCommonDataService IPCommonRepo { get; }

    }
}
