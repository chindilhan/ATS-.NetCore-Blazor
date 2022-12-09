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
using System.Threading.Tasks;

namespace Stx.HRM.Pages.Screening
{
    public class TalentPoolBase : ComponentBase
    {
        [Inject] public NavigationManager NavManager { get; set; }
        [Inject] ILogger<TalentPoolBase> Logger { get; set; }
        [Inject] ICandidateEvaluateDataService PageDataService { get; set; }
        [Inject] IJobCandidateDataService JobCandDataService { get; set; }
        [Inject] IJobCandidateDataService JobCandidateDataService { get; set; }
        [CascadingParameter(Name = "AlertService")] protected IAlertMsgService AlertMsgService { get; set; }

        public PageBaseInfo PageInfo { get; set; } = PageBaseInfo.GetPageInfo(0, PageType.Screening, "Evaluate Candidate");

        public List<HrJobCandidateListDTO> CandidateList { get; set; } = new List<HrJobCandidateListDTO>();
        public HrJobCandidate BaseEntity { get; set; } = new HrJobCandidate();

        public List<SelectListItem> DocStatusList { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> MatterTypeList { get; set; }
        public List<SelectListItem> NiceClassIDList { get; set; }
        public IEnumerable<string> ClassIDs { get; set; } = new string[] { };

        private string ApplicantStage;
        private int JobId;
        protected override async Task OnInitializedAsync()
        {
            try
            {
                AlertMsgService.ReportPageLoading(true);

                //BaseEntity = new HrCandidate();
                NavManager.TryGetQueryString<string>("stage", out ApplicantStage);
                NavManager.TryGetQueryString<int>("job", out JobId);

                await InitializePageData();

                if (JobId <= 0)
                {
                    BaseEntity = new HrJobCandidate();
                    AlertMsgService.ReportMessage("Requested job entry is invalid.", MsgType.Error, MsgRole.Toast);
                }
                else
                {
                    CandidateList = await JobCandDataService.GetRecordListByStage(ApplicantStage, JobId);
                    if (CandidateList == null)
                    {
                        AlertMsgService.ReportMessage("The candidate details may not accessible.", MsgType.Error, MsgRole.Toast);
                    }
                    PageInfo.PageTitle = $"Candidates";
                }
            }
            catch (Exception ex)
            {
                AlertMsgService.ReportMessage(ex.Message, MsgType.Error, MsgRole.Alert);
            }

            AlertMsgService.ReportPageLoading(false);
        }

#pragma warning disable CS1998 // This async method lacks 'await' operators and will run synchronously. Consider using the 'await' operator to await non-blocking API calls, or 'await Task.Run(...)' to do CPU-bound work on a background thread.
        private async Task InitializePageData()
#pragma warning restore CS1998 // This async method lacks 'await' operators and will run synchronously. Consider using the 'await' operator to await non-blocking API calls, or 'await Task.Run(...)' to do CPU-bound work on a background thread.
        {

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
            }
            catch (Exception ex)
            {
                AlertMsgService.ReportMessage(ex.Message, MsgType.Error, MsgRole.Alert);
            }
        }

    }
}
