using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using Stx.Shared.Extensions.Blazor;
using Stx.Shared.Extensions.Common;
using Stx.Shared.Common;
using Stx.Shared.Interfaces;
using Stx.Shared.Interfaces.HRM;
using Stx.Shared.Models.HRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stx.HRM.Pages.Screening
{
    public class JobBase : ComponentBase
    {
        [Inject] public NavigationManager NavManager { get; set; }
        [Inject] ILogger<EvaluateBase> Logger { get; set; }
        [Inject] ICandidateEvaluateDataService PageDataService { get; set; }
        [Inject] IJobCandidateDataService JobCandDataService { get; set; }
        [Inject] IJobOrderDataService JobOrderDataService { get; set; }

        //[Inject] ICandidateDataService CandidateDataService { get; set; }
        [Inject] IJobCandidateDataService JobCandidateDataService { get; set; }
        [CascadingParameter(Name = "AlertService")] protected IAlertMsgService AlertMsgService { get; set; }

        public PageBaseInfo PageInfo { get; set; } = PageBaseInfo.GetPageInfo(0, PageType.Screening, "Evaluate Candidate");

        public List<HrJobCandidateListDTO> CandidateList { get; set; } = new List<HrJobCandidateListDTO>();
        public HrJobCandidate BaseEntity { get; set; } = new HrJobCandidate();
        public HrJobSummaryDTO JobSummary { get; set; } = new HrJobSummaryDTO();
        public string CurrentPartialView { get; set; }

        public string UserComment { get; set; }


        public PageActionCss PageActionCSS { get; set; } = new PageActionCss();
        public class PageActionCss
        {
            public string CandidateBulkActionCss { get; set; } = "d-none";
            public bool SelectAllCandidates { get; set; } = false;
        }


        public string ApplicantStage { get; set; }
        private int JobId;
        protected override async Task OnInitializedAsync()
        {
            try
            {
                AlertMsgService.ReportPageLoading(true);

                //BaseEntity = new HrCandidate();
                string stage;
                NavManager.TryGetQueryString<string>("stage", out stage);
                ApplicantStage = stage;
                NavManager.TryGetQueryString<int>("job", out JobId);

                if (JobId <= 0)
                {
                    BaseEntity = new HrJobCandidate();
                    AlertMsgService.ReportMessage("Requested job entry is invalid.", MsgType.Error, MsgRole.Toast);
                }
                
                await InitializePageData();

                if (CandidateList == null)
                {
                    AlertMsgService.ReportMessage("The candidate details may not accessible.", MsgType.Error, MsgRole.Toast);
                }
                PageInfo.PageTitle = $"Candidates";
            }
            catch (Exception ex)
            {
                AlertMsgService.ReportMessage(ex.Message, MsgType.Error, MsgRole.Alert);
            }

            AlertMsgService.ReportPageLoading(false);
        }

        private async Task InitializePageData()
        {
            JobSummary = await JobOrderDataService.GetJobSummaryByID(JobId);
            await GetApplicationStageData();
        }

        private async Task GetApplicationStageData()
        {
            CandidateList = await JobCandDataService.GetRecordListByStage(ApplicantStage, JobId);
            if (CandidateList.Count > 0)
                BaseEntity = await JobCandDataService.GetRecordByID(CandidateList[0].JobCandidateID);
            else
                BaseEntity = new HrJobCandidate();

            CurrentPartialView = null;

        }

#pragma warning disable CS1998 // This async method lacks 'await' operators and will run synchronously. Consider using the 'await' operator to await non-blocking API calls, or 'await Task.Run(...)' to do CPU-bound work on a background thread.
        protected async Task HandleValidSubmitAsync()
#pragma warning restore CS1998 // This async method lacks 'await' operators and will run synchronously. Consider using the 'await' operator to await non-blocking API calls, or 'await Task.Run(...)' to do CPU-bound work on a background thread.
        {
            //await SubmitEntry(false);
        }

        protected async Task CandidateEntryClicked(int candidateId) //MouseEventArgs args)
        {
            try
            {
                BaseEntity = await JobCandDataService.GetRecordByID(candidateId);
                CurrentPartialView = null;
            }
            catch (Exception ex)
            {
                AlertMsgService.ReportMessage(ex.Message, MsgType.Error, MsgRole.Alert);
            }
        }
        protected async Task ApplicationStageClicked(string appStage) //MouseEventArgs args)
        {
            try
            {
                ApplicantStage = appStage;
                await GetApplicationStageData();
            }
            catch (Exception ex)
            {
                AlertMsgService.ReportMessage(ex.Message, MsgType.Error, MsgRole.Alert);
            }
        }
        
#pragma warning disable CS1998 // This async method lacks 'await' operators and will run synchronously. Consider using the 'await' operator to await non-blocking API calls, or 'await Task.Run(...)' to do CPU-bound work on a background thread.
        protected async Task CandidateListCheckedChange(int jobCandId, bool isSelected)
#pragma warning restore CS1998 // This async method lacks 'await' operators and will run synchronously. Consider using the 'await' operator to await non-blocking API calls, or 'await Task.Run(...)' to do CPU-bound work on a background thread.
        {
            try
            {
                if (!isSelected) PageActionCSS.SelectAllCandidates = false;
                CandidateList.Where(x => x.JobCandidateID == jobCandId).FirstOrDefault().Selected = isSelected;
                if (CandidateList.Any(x => x.Selected)) { PageActionCSS.CandidateBulkActionCss = ""; }
                else { PageActionCSS.CandidateBulkActionCss = "d-none"; }
                StateHasChanged();
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {

            }
        }
#pragma warning disable CS1998 // This async method lacks 'await' operators and will run synchronously. Consider using the 'await' operator to await non-blocking API calls, or 'await Task.Run(...)' to do CPU-bound work on a background thread.
        protected async Task CandidateListSelectAllChecked(bool isSelected)
#pragma warning restore CS1998 // This async method lacks 'await' operators and will run synchronously. Consider using the 'await' operator to await non-blocking API calls, or 'await Task.Run(...)' to do CPU-bound work on a background thread.
        {
            try
            {
                CandidateList.ForEach(x => x.Selected = isSelected);
                if (CandidateList.Any(x => x.Selected)) { PageActionCSS.CandidateBulkActionCss = ""; }
                else { PageActionCSS.CandidateBulkActionCss = "d-none"; }
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {

            }
        }

        #region Tool Bar Events & Controlls

#pragma warning disable CS1998 // This async method lacks 'await' operators and will run synchronously. Consider using the 'await' operator to await non-blocking API calls, or 'await Task.Run(...)' to do CPU-bound work on a background thread.
        protected async Task MoveButtonClicked(string buttonName)
#pragma warning restore CS1998 // This async method lacks 'await' operators and will run synchronously. Consider using the 'await' operator to await non-blocking API calls, or 'await Task.Run(...)' to do CPU-bound work on a background thread.
        {

        }
#pragma warning disable CS1998 // This async method lacks 'await' operators and will run synchronously. Consider using the 'await' operator to await non-blocking API calls, or 'await Task.Run(...)' to do CPU-bound work on a background thread.
        protected async Task ToolButtonClicked(string toolActionName)
#pragma warning restore CS1998 // This async method lacks 'await' operators and will run synchronously. Consider using the 'await' operator to await non-blocking API calls, or 'await Task.Run(...)' to do CPU-bound work on a background thread.
        {
            CurrentPartialView = toolActionName;
        }
#pragma warning disable CS1998 // This async method lacks 'await' operators and will run synchronously. Consider using the 'await' operator to await non-blocking API calls, or 'await Task.Run(...)' to do CPU-bound work on a background thread.
        protected async Task ToolMenuClicked(string toolActionName)
#pragma warning restore CS1998 // This async method lacks 'await' operators and will run synchronously. Consider using the 'await' operator to await non-blocking API calls, or 'await Task.Run(...)' to do CPU-bound work on a background thread.
        {
            if (toolActionName.Contains("edit"))
            {
                NavManager.NavigateTo($"/Candidate/Preview/?{BaseEntity.JobCandidateID}");
            }
            else if (toolActionName.Contains("copy"))
            {
                CurrentPartialView = "copy-candidate";
            }
            else if (toolActionName.Contains("delete"))
            {
                NavManager.NavigateTo($"/Candidate/Preview/?actn=delete&jobcid={BaseEntity.JobCandidateID}");
            }
        }

#pragma warning disable CS1998 // This async method lacks 'await' operators and will run synchronously. Consider using the 'await' operator to await non-blocking API calls, or 'await Task.Run(...)' to do CPU-bound work on a background thread.
        protected async Task CommentActionButtonClicked(string value)
#pragma warning restore CS1998 // This async method lacks 'await' operators and will run synchronously. Consider using the 'await' operator to await non-blocking API calls, or 'await Task.Run(...)' to do CPU-bound work on a background thread.
        {
            UserComment = value;
            CurrentPartialView = null;
            StateHasChanged();
        }

#pragma warning disable CS1998 // This async method lacks 'await' operators and will run synchronously. Consider using the 'await' operator to await non-blocking API calls, or 'await Task.Run(...)' to do CPU-bound work on a background thread.
        protected async Task ComponentActionCallback(ReturnObj ret)
#pragma warning restore CS1998 // This async method lacks 'await' operators and will run synchronously. Consider using the 'await' operator to await non-blocking API calls, or 'await Task.Run(...)' to do CPU-bound work on a background thread.
        {
            try
            {
                if (!ret.IsSuccess)
                {
                    CurrentPartialView = null;
                    StateHasChanged();
                }
                else if (ret.MsgCode.Compare("comment"))
                {
                    UserComment = (string)ret.RetResult;
                    CurrentPartialView = null;
                    StateHasChanged();
                }
                else if (ret.MsgCode.Compare("email"))
                {
                    //UserComment = (EmailMsg)ret.RetResult;
                    CurrentPartialView = null;
                    StateHasChanged();
                }
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {

            }
        }
        #endregion

    }
}
