using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using Stx.Shared.Extensions.Common;
using Stx.Shared.Common;
using Stx.Shared.Interfaces;
using Stx.Shared.Interfaces.Common;
using Stx.Shared.Interfaces.CRM;
using Stx.Shared.Models.Common;
using Stx.Shared.Models.CRM;
using Stx.Shared.Models.HRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stx.HRM.Components.CorporateComp
{
    public class PreferencePanelBase: ComponentBase
    {
        [Inject] ILogger<PreferencePanelBase> Logger { get; set; }
        [Inject] ICorporateSettingsDataService PageDataService { get; set; }
        [CascadingParameter(Name = "AlertService")] protected IAlertMsgService AlertMsgService { get; set; }
        [Parameter] public EventCallback<ReturnObj> ComponentActionCallback { get; set; }
        [Parameter] public int CorporateID { get; set; }
        
        public CorporatePreference BaseEntry { get; set; } = new CorporatePreference();
        public List<CorporatePreference> BaseEntryList { get; set; } = new List<CorporatePreference>();
        public List<PreferenceFldUI> PreferenceFldUIList { get; set; } = new List<PreferenceFldUI>();
        public string CurrentCatg{ get; set; }
        private bool isLoadingError = false;

        protected override async Task OnInitializedAsync()
        {
            try
            {
                isLoadingError = false;
                BaseEntryList = await PageDataService.GetCorporatePreference(CorporateID);
                //Fill this after BaseEntryList
                List<PreferenceValueOption> emailMsgOptions = new List<PreferenceValueOption>()
                {
                    new PreferenceValueOption() { Name="Email", Value="e"},
                    new PreferenceValueOption() { Name="Message", Value="m"}
                };
                List<PreferenceValueOption> yesno = new List<PreferenceValueOption>()
                {
                    new PreferenceValueOption() { Name="Yes", Value="y"},
                    new PreferenceValueOption() { Name="No", Value="n"}
                };

                PreferenceFldUIList.AddRange(new PreferenceFldUI[] {
                    new PreferenceFldUI("Notif", "radio", "new_candidate", "New Candidate", "A new candidate applies.", "e", 1, emailMsgOptions ),
                    new PreferenceFldUI("Notif", "radio", "new_talent_match", "New Talent Match", "A new talent match found.", "m", 2, emailMsgOptions ),
                    new PreferenceFldUI("Notif", "radio", "intrvw_reminder", "Interview Reminder", "Reminder for upcoming interview or meeting.", "m", 3, emailMsgOptions ),

                    new PreferenceFldUI("Pref", "radio", "allow_direct_msg", "Allow Direct Contact", "Allow to contact us directly.", "m", 1, yesno ),
                });

                foreach (var uiItem in PreferenceFldUIList.Where(x=> BaseEntryList.Select(y=> y.PrefKey).ToList().Contains(x.PrefKey)))
                {
                    uiItem.UserValue = BaseEntryList.FirstOrDefault(x => x.PrefKey == uiItem.PrefKey).PrefValue;
                }
            }
            catch (Exception ex)
            {
                isLoadingError = true;
                AlertMsgService.ReportMessage(ex.GetInnerExcpMsg(), MsgType.Error, MsgRole.Alert);
            }
        }

        protected async Task SubmitButtonClicked()
        {
            try
            {
                if(isLoadingError && BaseEntryList.Count == 0)
                {
                    //show warning. "Some settings may have not been loaded properly. Do you still want to save your changes?"
                }
                foreach (var sett in PreferenceFldUIList)
                {
                    if(!BaseEntryList.Any(x => x.PrefKey == sett.PrefKey))
                    {
                        BaseEntryList.Add(new CorporatePreference()
                        {
                            ID = 0,
                            CorporateID = CorporateID,
                            PrefKey = sett.PrefKey,
                            PrefType = sett.PrefUIType,
                            PrefValue = sett.UserValue,
                            SeqNum = sett.SeqNum
                        });
                    }
                    else
                    {
                        BaseEntryList.FirstOrDefault(x => x.PrefKey == sett.PrefKey).PrefValue = sett.UserValue;
                    }
                }

                if (!BaseEntryList.Any(x=> string.IsNullOrWhiteSpace(x.PrefValue)))
                {
                    var ret = await PageDataService.UpdateCorporatePreference(BaseEntryList, "");
                    BaseEntryList = ret;
                    AlertMsgService.ReportMessage("The preferences have been updated.", MsgType.Success, MsgRole.Toast);
                }
            }
            catch (Exception ex)
            {
                AlertMsgService.ReportMessage(ex.GetInnerExcpMsg(), MsgType.Error, MsgRole.Alert);
            }
        }

        protected async Task CloseButtonClicked()
        {
            await ComponentActionCallback.InvokeAsync(new ReturnObj(false));
        }
    }
}
