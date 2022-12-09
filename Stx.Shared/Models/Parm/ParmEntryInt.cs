using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Stx.Shared.Models.Parm
{
    [NotMapped]
    public class ParmEntryInt
    {
        public ParmEntryInt()
        {

        }

        public ParmEntryInt(int parmID, string parmName)
        {
            ParmID = parmID;
            ParmName = parmName;
        }

        public int ParmID { get; set; }
        public string ParmName { get; set; }
    }
}
