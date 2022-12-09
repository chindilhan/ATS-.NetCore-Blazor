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
    public class EvaluateBase : ComponentBase
    {
        [Inject] public NavigationManager NavManager { get; set; }
        [Inject] ILogger<EvaluateBase> Logger { get; set; }
        [Inject] ICandidateEvaluateDataService PageDataService { get; set; }
        [Inject] IJobCandidateDataService JobCandidateDataService { get; set; }
        [CascadingParameter(Name = "AlertService")] protected IAlertMsgService AlertMsgService { get; set; }

        public PageBaseInfo PageInfo { get; set; } = PageBaseInfo.GetPageInfo(0, PageType.Screening, "Evaluate Candidate");

        public HrJobCandidate BaseEntity { get; set; } = new HrJobCandidate();

        public List<SelectListItem> DocStatusList { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> MatterTypeList { get; set; }
        public List<SelectListItem> NiceClassIDList { get; set; }
        public IEnumerable<string> ClassIDs { get; set; } = new string[] { };

        private int CandId;
        private int corpId;
        private int JobId;
        protected override async Task OnInitializedAsync()
        {
            try
            {
                AlertMsgService.Reset();
                AlertMsgService.ReportPageLoading(true);

                //NavManager.TryGetQueryString<string>("csrc", out CandSrc);
                NavManager.TryGetQueryString<int>("cand", out CandId);
                NavManager.TryGetQueryString<int>("job", out JobId);
                NavManager.TryGetQueryString<int>("corp", out corpId);

                await InitializePageData();

                if (CandId <= 0 || JobId <= 0)
                {
                    BaseEntity = new HrJobCandidate();
                    AlertMsgService.ReportMessage("The requested values are incorrect.", MsgType.Warning, MsgRole.Toast);
                }
                else
                {
                    BaseEntity = await JobCandidateDataService.GetRecordByID(CandId);
                    if (BaseEntity == null)
                    {
                        BaseEntity = new HrJobCandidate();
                        AlertMsgService.ReportMessage("The candidate details may not accessible.", MsgType.Error, MsgRole.Toast);
                    }
                    PageInfo.PageTitle = $"Candidate: {BaseEntity.FirstName} {BaseEntity.LastName}";
                }
            }
            catch (Exception ex)
            {
                AlertMsgService.ReportMessage(ex.GetInnerExcpMsg(), MsgType.Error, MsgRole.Alert);
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

    }
}
