using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Stx.Shared.Models.Parm
{
    [NotMapped]
    public class ParmEntryStr
    {
        public ParmEntryStr()
        {

        }

        public ParmEntryStr(string parmID, string parmName)
        {
            ParmID = parmID;
            ParmName = parmName;
        }

        public string ParmID { get; set; }
        public string ParmName { get; set; }
    }
}
