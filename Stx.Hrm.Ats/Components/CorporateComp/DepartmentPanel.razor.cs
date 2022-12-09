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
    public class DepartmentPanelBase : ComponentBase
    {
        [Inject] ILogger<DepartmentPanelBase> Logger { get; set; }
        [Inject] ICorporateSettingsDataService PageDataService { get; set; }
        [Parameter] public EventCallback<ReturnObj> ComponentActionCallback { get; set; }
        [Parameter] public int CorporateID { get; set; }
        [CascadingParameter(Name = "AlertService")] protected IAlertMsgService AlertMsgService { get; set; }

        public HrAtsDepartment BaseEntry { get; set; } = new HrAtsDepartment();
        public List<HrAtsDepartment> BaseEntryList { get; set; } = new List<HrAtsDepartment>();
        public bool IsAddNewRecord { get; set; } = false;

        protected override async Task OnInitializedAsync()
        {
            try
            {
                BaseEntryList = await PageDataService.GetDepartments(CorporateID);
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
                    var ret = await PageDataService.UpdateDepartments(BaseEntry, "");
                    BaseEntryList.Remove(BaseEntry);
                    BaseEntryList.Add(ret);
                    await PrepareNewEntryPanel("hide");
                    AlertMsgService.ReportMessage("The department has been updated.", MsgType.Success, MsgRole.Toast);
                }
            }
            catch (Exception ex)
            {
                AlertMsgService.ReportMessage(ex.GetInnerExcpMsg(), MsgType.Error, MsgRole.Alert);
            }
        }
        
        protected async Task PrepareNewEntryPanel(string action)
        {
            if (action.Compare("show"))
                IsAddNewRecord = true;
            else 
                IsAddNewRecord = false;

            StateHasChanged();
        }

        protected async Task CloseButtonClicked()
        {
            await ComponentActionCallback.InvokeAsync(new ReturnObj(false));
        }
        protected async Task AddNewButtonClicked()
        {
            BaseEntry = new HrAtsDepartment() { CorporateID = CorporateID };
            await PrepareNewEntryPanel("show");
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
