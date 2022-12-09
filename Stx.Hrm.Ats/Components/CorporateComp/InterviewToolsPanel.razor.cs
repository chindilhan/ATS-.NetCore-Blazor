using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using Stx.Shared.Extensions.Common;
using Stx.Shared.Common;
using Stx.Shared.Interfaces;
using Stx.Shared.Interfaces.Common;
using Stx.Shared.Interfaces.CRM;
using Stx.Shared.Models.Common;
using Stx.Shared.Models.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Stx.HRM.Components;
using Stx.HRM.Core;

namespace Stx.HRM.Components.CorporateComp
{
    public class InterviewToolsPanelBase : ComponentBase
    {
        [Inject] ILogger<TemplatePanelBase> Logger { get; set; }
        [Inject] ICorporateSettingsDataService PageDataService { get; set; }
        [CascadingParameter(Name = "AlertService")] protected IAlertMsgService AlertMsgService { get; set; }
        [Parameter] public EventCallback<ReturnObj> ComponentActionCallback { get; set; }
        [Parameter] public int CorporateID { get; set; }

        public CustomValidator customValidator { get; set; }
        public bool IsShowInterviewPanel { get; set; } = false;
        public BenchmarkGroup BaseEntry { get; set; } = new BenchmarkGroup();
        public List<CorporateBenchmark> BaseEntryList { get; set; } = new List<CorporateBenchmark>();

        protected override async Task OnInitializedAsync()
        {
            try
            {
                BaseEntryList = (await PageDataService.GetInterviewTools(CorporateID)).OrderBy(x=> x.BmkCategory).ToList();
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
                customValidator.ClearErrors();

                if (BaseEntry != null && !string.IsNullOrWhiteSpace(BaseEntry.BmkCategory) && BaseEntry.BmkAttributes?.Count > 0)
                {
                    if (BaseEntry.BmkAttributes.GroupBy(x => x.BmkAttribute).Any(g => g.Count() > 1))
                    {
                        var errors = new Dictionary<string, List<string>>();
                        errors.Add(nameof(BaseEntry.BmkAttributes), new List<string>() { "No duplicate attributes allowed." });
                        customValidator.DisplayErrors(errors);
                    }
                    else
                    {
                        List<CorporateBenchmark> entryToSave = new List<CorporateBenchmark>();
                        BaseEntry.BmkAttributes.ForEach(x =>
                            entryToSave.Add(new CorporateBenchmark
                            {
                                ID = x.ID,
                                BmkCategory = BaseEntry.BmkCategory,
                                BmkType = BaseEntry.BmkType,
                                CorporateID = CorporateID,
                                Stage = BaseEntry.Stage,
                                SeqNum = x.SeqNum,
                                BmkAttribute = x.BmkAttribute,
                                ModuelID = 101
                            }));
                        var retlist = await PageDataService.UpdateInterviewTools(entryToSave, "");
                        BaseEntryList.RemoveAll(x => x.BmkCategory == BaseEntry.BmkCategory);
                        BaseEntryList.AddRange(retlist);
                        await PrepareNewEntryPanel("hide");
                        AlertMsgService.ReportMessage("The interview tools have been updated.", MsgType.Success, MsgRole.Toast);
                    }
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
            BaseEntry = new BenchmarkGroup() { BmkAttributes = new List<BenchmarkGroupAttr> { new BenchmarkGroupAttr() } };
            await PrepareNewEntryPanel("show");
        }   
        
        protected async Task PrepareNewEntryPanel(string action)
        {
            if (action.Compare("show"))
                IsShowInterviewPanel= true;
            else
                IsShowInterviewPanel = false;

            StateHasChanged();
        }

        protected async Task EntryActionButtonClicked(string action, string categ)
        {
            if(!string.IsNullOrWhiteSpace(categ) && action.Compare("edit"))
            {
                var entry = BaseEntryList.Where(x => x.BmkCategory == categ);
                if (entry != null)
                {
                    BaseEntry = new BenchmarkGroup()
                    {
                        BmkCategory = entry.FirstOrDefault().BmkCategory, 
                        BmkType = entry.FirstOrDefault().BmkType, 
                        Stage = entry.FirstOrDefault().Stage, 
                        BmkAttributes = entry.Select(x=> new BenchmarkGroupAttr { ID = x.ID, BmkAttribute = x.BmkAttribute, SeqNum = x.SeqNum }).ToList()
                    };
                }
                await PrepareNewEntryPanel("show");
            }
            else if (!string.IsNullOrWhiteSpace(categ) && action.Compare("delete"))
            {

            }
        }

        protected void AddNewAttribute()
        {
            BaseEntry?.BmkAttributes?.Add(new BenchmarkGroupAttr() { ID = 0 });
            StateHasChanged();
        }

        protected void RemoveAttribute(BenchmarkGroupAttr attr)
        {
            BaseEntry?.BmkAttributes?.Remove(attr);
            StateHasChanged();
        }

    }
}
