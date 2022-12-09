using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using Stx.Shared.Common;
using Stx.Shared.Interfaces.Common;
using Stx.Shared.Models.Common;
using Stx.Shared.Models.HRM;
using Stx.Shared.Models.CRM;
using System;
using System.Threading.Tasks;
using Stx.Shared.Interfaces.CRM;
using System.Collections.Generic;
using Microsoft.AspNetCore.Components.Forms;
using Stx.Shared.Interfaces;
using Microsoft.AspNetCore.Http;
using Stx.Shared.Extensions.Common;

namespace Stx.HRM.Components.CorporateComp
{
    public class CorpProfilePanelBase : ComponentBase
    {
        [Inject] ILogger<CorpProfilePanelBase> Logger { get; set; }
        [Inject] ICorporateSettingsDataService PageDataService { get; set; }
        [Parameter] public EventCallback<ReturnObj> ComponentActionCallback { get; set; }
        [CascadingParameter(Name = "AlertService")] protected IAlertMsgService AlertMsgService { get; set; }
        [Parameter] public int CorporateID{ get; set; }

        public Corporate BaseEntry { get; set; } = new Corporate();
        public int ModuleID { get; set; } = 100;

        protected override async Task OnInitializedAsync()
        {
            try
            {
                BaseEntry = await PageDataService.GetProfile(CorporateID);
            }
            catch (Exception ex)
            {
                AlertMsgService.ReportMessage(ex.GetInnerExcpMsg(), MsgType.Error, MsgRole.Alert);
            }
        }

        protected async Task SubmitButtonClicked()
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(BaseEntry.Name))
                {
                    BaseEntry = await PageDataService.UpdateProfile(BaseEntry, "");
                    AlertMsgService.ReportMessage("The profile has been updated.", MsgType.Success, MsgRole.Toast);
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
