using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Stx.Shared.Models.Parm
{
    public enum FilterType
    {
        CorpJobList
    }

    [NotMapped]
    public class HrmParmDTO
    {
        public HrmParmDTO()
        {

        }
        public HrmParmDTO(FilterType filterType, ParmEntryInt entryID1)
        {
            FilterType = filterType.ToString();
            EntryID1 = entryID1;
        }
        //public HrmParmDTO(ParmReturnType returnType, ParmEntryInt parm1, ParmEntryInt parm2)
        //{
        //    ReturnType = returnType.ToString();
        //    Parm1Int = parm1;
        //    Parm2Int = parm2;
        //}
        public HrmParmDTO(FilterType filterType, ParmEntryStr entryCD1)
        {
            FilterType = filterType.ToString();
            EntryCD1 = entryCD1;
        }
        //public HrmParmDTO(ParmReturnType returnType, ParmEntryStr parm1string, ParmEntryStr parm2string)
        //{
        //    ReturnType = returnType.ToString();
        //    Parm1Str = parm1string;
        //    Parm2Str = parm2string;
        //}

        public string FilterType { get; set; } = "";
        public ParmEntryInt EntryID1 { get; set; }
        //public ParmEntryInt Parm2Int { get; set; }
        public ParmEntryStr EntryCD1 { get; set; }
        //public ParmEntryStr Parm2Str { get; set; }
    }
}
