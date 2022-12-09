using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stx.HRM.Components.CorporateComp
{
    public class PreferenceFldUI
    {
        public PreferenceFldUI()
        {

        }

        public PreferenceFldUI(string category, string prefUIType, string prefKey, string name, string desc, string userValue, short seqNum, List<PreferenceValueOption> settOptions)
        {
            this.Category = category;
            this.PrefUIType = prefUIType;
            this.PrefKey = prefKey;
            this.Name = name;
            this.Desc = desc;
            this.UserValue = userValue;
            this.SeqNum = seqNum;
            this.SettOptions = settOptions;
        }
        public string Category { get; set; }
        public string PrefUIType { get; set; } = "radio"; //radio, checkbox, text
        public string PrefKey { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        public string UserValue { get; set; }
        public short SeqNum { get; set; } = 0;
        public List<PreferenceValueOption> SettOptions { get; set; }
    }

    public class PreferenceValueOption
    {
        public string Value { get; set; }
        public string Name { get; set; }
    }
}
