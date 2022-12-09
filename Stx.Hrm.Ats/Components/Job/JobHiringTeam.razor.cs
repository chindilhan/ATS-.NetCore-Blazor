using Microsoft.AspNetCore.Components;
using Stx.Shared.Common;
using Stx.Shared.Extensions.Common;
using Stx.Shared.Interfaces;
using Stx.Shared.Interfaces.CRM;
using Stx.Shared.Interfaces.HRM;
using Stx.Shared.Models.HRM;

namespace Stx.Hrm.Ats.Components.Job;

public class JobHiringTeamBase : ComponentBase
{
    [Inject] ILogger<JobHiringTeamBase> Logger { get; set; }
    [Inject] ICorporateSettingsDataService PageDataService { get; set; }
    [Inject] IJobOrderDataService JobDataService { get; set; }
    [Parameter] public EventCallback<ReturnObj> ComponentActionCallback { get; set; }
    [Parameter] public int CorporateID { get; set; }
    [CascadingParameter(Name = "AlertService")] protected IAlertMsgService AlertMsgService { get; set; }

    public HrAtsTeamDTO BaseEntry { get; set; } = new HrAtsTeamDTO();
    public List<HrAtsTeamDTO> BaseEntryList { get; set; } = new List<HrAtsTeamDTO>();
    public List<HrJobSummaryMinDTO> AvailJobList { get; set; } = new List<HrJobSummaryMinDTO>();
    public bool IsAddNewRecord { get; set; } = false;

    protected override async Task OnInitializedAsync()
    {
        try
        {
            BaseEntryList = await PageDataService.GetTeams(CorporateID);
            AvailJobList = await JobDataService.GetCorporateJobListMin(CorporateID);
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
            if (!string.IsNullOrWhiteSpace(BaseEntry.Email))
            {
                List<HrAtsTeamJob> teamJobs = new List<HrAtsTeamJob>();
                AvailJobList.Where(x => x.Selected).ToList().ForEach(x => teamJobs.Add(new HrAtsTeamJob() { CorpUserID = BaseEntry.CorpUserID, JobOrderID = x.JobOrderID }));
                var ret = await PageDataService.UpdateTeams(BaseEntry, teamJobs, "");
                BaseEntryList.Remove(BaseEntry);
                BaseEntryList.Add(ret);
                await PrepareNewEntryPanel("hide");
                AlertMsgService.ReportMessage("The team has been updated.", MsgType.Success, MsgRole.Toast);
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
        BaseEntry = new HrAtsTeamDTO() { CorporateID = CorporateID };
        await PrepareNewEntryPanel("show");
    }

    protected async Task PrepareNewEntryPanel(string action)
    {
        if (action.Compare("show"))
            IsAddNewRecord = true;
        else
            IsAddNewRecord = false;

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
