using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using Stx.Shared.Extensions.Common;
using Stx.Shared.Common;
using Stx.Shared.Interfaces;
using Stx.Shared.Interfaces.Common;
using Stx.Shared.Interfaces.CRM;
using Stx.Shared.Models.HRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stx.HRM.Components.CorporateComp
{
    public class TemplatePanelBase : ComponentBase
    {
        [Inject] ILogger<TemplatePanelBase> Logger { get; set; }
        [Inject] ICorporateSettingsDataService PageDataService { get; set; }
        [Parameter] public EventCallback<ReturnObj> ComponentActionCallback { get; set; }
        [Parameter] public int CorporateID { get; set; }
        [CascadingParameter(Name = "AlertService")] protected IAlertMsgService AlertMsgService { get; set; }

        public bool IsShowEmailAddPanel { get; set; } = false;

        public HrAtsMailTemplate BaseEntry { get; set; } = new HrAtsMailTemplate();
        public List<HrAtsMailTemplate> BaseEntryList { get; set; } = new List<HrAtsMailTemplate>();

        protected override async Task OnInitializedAsync()
        {
            try
            {
                BaseEntryList = await PageDataService.GetEmailTemplates(CorporateID);
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
                    var ret = await PageDataService.UpdateEmailTemplates(BaseEntry, "");
                    BaseEntryList.Remove(BaseEntry);
                    BaseEntryList.Add(ret);
                    await PrepareNewEntryPanel("hide");
                    AlertMsgService.ReportMessage("The template has been updated.", MsgType.Success, MsgRole.Toast);
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
        protected async Task AddNewButtonClicked()
        {
            BaseEntry = new HrAtsMailTemplate() { CorporateID = CorporateID };
            await PrepareNewEntryPanel("show");
        }

        protected async Task PrepareNewEntryPanel(string action)
        {
            if (action.Compare("show"))
                IsShowEmailAddPanel = true;
            else
                IsShowEmailAddPanel = false;

            StateHasChanged();
        }

        protected async Task EntryActionButtonClicked(string action, int id)
        {
            if (id > 0 && action.Compare("edit"))
            {
                BaseEntry = BaseEntryList.Where(x => x.ID == id).FirstOrDefault();
                await PrepareNewEntryPanel("show");
            }
            else if (id > 0 && action.Compare("delete"))
            {

            }
        }

    }
}
