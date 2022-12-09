using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using Radzen;
using Stx.HRM.Core;
using Stx.Shared.Extensions.Common;
using Stx.Shared.Common;
using Stx.Shared.Interfaces;
using Stx.Shared.Interfaces.Common;
using Stx.Shared.Interfaces.CRM;
using Stx.Shared.Interfaces.HRM;
using Stx.Shared.Models.Common;
using Stx.Shared.Models.HRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stx.HRM.Components.CorporateComp
{
    public class WorkflowPanelBase : ComponentBase
    {
        [Inject] ILogger<TemplatePanelBase> Logger { get; set; }
        [Inject] ICorporateSettingsDataService PageDataService { get; set; }
        [Inject] IHrmGeneralDataService HrmGeneralDataService { get; set; }
        [Inject] NotificationService NotifService { get; set; }
        [Inject] DialogService DialogService { get; set; }
        [Parameter] public EventCallback<ReturnObj> ComponentActionCallback { get; set; }
        [Parameter] public int CorporateID { get; set; }
        [CascadingParameter(Name = "AlertService")] protected IAlertMsgService AlertMsgService { get; set; }

        public CustomValidator customValidator { get; set; }
        public HrAtsWorkflow BaseEntry { get; set; } = new HrAtsWorkflow();
        //[ValidateComplexType]
        public List<HrAtsWorkflow> BaseEntryList { get; set; } = new List<HrAtsWorkflow>();
        public List<ComboStr> StageCategoryList { get; set; } = new List<ComboStr>();

        protected override async Task OnInitializedAsync()
        {
            try
            {

                BaseEntryList.Add(new HrAtsWorkflow() { ID = 1, SeqNum = 1, Name = "Sourced", CorporateID = CorporateID, IsLocked=true, IsConfidential = false, StageCategory = "Workflow fsafsdfsdf" });
                //BaseEntryList.Add(new HrAtsWorkflow() { ID = 2, SeqNum = 2, Name = "Applied", CorporateID = CorporateID, IsLocked = true, IsConfidential = false, StageCategory = "Workflow sdfjuyjkyudfsd iuoio" });
                //BaseEntryList.Add(new HrAtsWorkflow() { ID = 3, SeqNum = 3, Name = "Workflow 1", CorporateID = CorporateID, IsConfidential = false, StageCategory = "Workflow fsadfds ouioiou" });
                //BaseEntryList.Add(new HrAtsWorkflow() { ID = 4, SeqNum = 4, Name = "Workflow 2", CorporateID = CorporateID, IsConfidential = false, StageCategory = "Workflow fsadfds ouioiou" });
                //BaseEntryList.Add(new HrAtsWorkflow() { ID = 5, SeqNum = 5, Name = "Workflow 3", CorporateID = CorporateID, IsConfidential = false, StageCategory = "Workflow fsadfds ouioiou" });

                BaseEntryList = await PageDataService.GetWorkflows(CorporateID);
                StageCategoryList = HrmGeneralDataService.GetRecruitmentStageCategories();
            }
            catch (Exception ex)
            {
                AlertMsgService.ReportMessage(ex.GetInnerExcpMsg(), MsgType.Error, MsgRole.Alert);
            }
        }

        protected async Task SubmitButtonClicked2() { }
        protected async Task SubmitButtonClicked3() { }
        protected async Task SubmitButtonClicked()
        {
            try
            {
                customValidator.ClearErrors();
                if (BaseEntryList.Any(x => string.IsNullOrWhiteSpace(x.Name) || string.IsNullOrWhiteSpace(x.StageCategory)))
                {
                    AlertMsgService.Notify("Incomplete", "Please fill all the name & category fileds.", MsgType.Warning, 3000);
                    var errors = new Dictionary<string, List<string>>();
                    errors.Add(nameof(BaseEntry.Name), new List<string>() { "Name & category fields are required." });
                    customValidator.DisplayErrors(errors);
                    return;
                }
                if (BaseEntryList.Count > 0)
                {
                    var ret = await PageDataService.UpdateWorkflows(BaseEntryList, "");
                    BaseEntryList = ret;
                    AlertMsgService.Notify("Success", "The workflows have been updated.", MsgType.Success);
                    StateHasChanged();
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
            try
            {
                if (BaseEntryList.Count >= 10)
                {
                    NotifService.Notify(NotificationSeverity.Warning, "Not Allowed", "Maximum allowed workflows are 10.", 3000);
                }
                var seq = (short)(BaseEntryList.Select(x => x.SeqNum).DefaultIfEmpty().Max() + 1);
                //var type = StageCategoryList.FirstOrDefault(x => x.Value == "interview");
                BaseEntryList.Add(new HrAtsWorkflow() { ID = 0, SeqNum = seq, Name = "", CorporateID = CorporateID, IsLocked = false, IsConfidential = false, StageCategory = "interview" });
                StateHasChanged();
            }
            catch { }
        }

        protected async Task MoveEntry(string action, int id, short seqNum)
        {
            try
            {
                if (BaseEntryList.Any(x => x.ID == id && x.IsLocked)) return;

                if (action == "delete")
                {
                    bool? isDel = false;
                    if (id > 0)
                        isDel = await DialogService.Confirm("Do you want to delete the workflow?", "Confirm", new ConfirmOptions() { OkButtonText = "Yes", CancelButtonText = "No" });

                    if (isDel == true || id <= 0)
                    {
                        BaseEntryList.Remove(BaseEntryList.Where(x => x.ID == id && x.SeqNum == seqNum).FirstOrDefault());
                        StateHasChanged();
                    }
                    return;
                }

                HrAtsWorkflow moveup = null;
                HrAtsWorkflow movedown = null;
                if (action == "up")
                {
                    moveup = BaseEntryList.Where(x => x.ID == id && x.SeqNum == seqNum).FirstOrDefault();
                    movedown = BaseEntryList.Where(x => x.SeqNum < moveup.SeqNum && !x.IsLocked).OrderByDescending(o=> o.SeqNum).FirstOrDefault();
                    
                }
                else if (action == "down")
                {
                    movedown = BaseEntryList.Where(x => x.ID == id && x.SeqNum == seqNum).FirstOrDefault();
                    moveup = BaseEntryList.Where(x => x.SeqNum > movedown.SeqNum && !x.IsLocked).OrderBy(o => o.SeqNum).FirstOrDefault();
                }

                if (moveup != null && movedown != null)
                {
                    moveup.SeqNum--;
                    movedown.SeqNum++;
                    StateHasChanged();
                }
            }
            catch (Exception ex)
            {
            }
        }

    }
}
