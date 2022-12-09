using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using Stx.Shared.Extensions.Blazor;
using Stx.Shared.Extensions.Common;
using Stx.Shared.Common;
using Stx.Shared.Interfaces;
using Stx.Shared.Interfaces.HRM;
using Stx.Shared.Models.HRM;
using Stx.Shared.Models.Parm;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Stx.HRM.Pages.Candidate
{
    public class SearchBase : ComponentBase
    {
        [Inject] public NavigationManager NavManager { get; set; }
        [Inject] ILogger<SearchBase> Logger { get; set; }
        [Inject] IJobCandidateDataService PageDataService { get; set; }
        [Parameter] public string actn { get; set; }
        [Parameter] public string job { get; set; }
        [CascadingParameter(Name = "AlertService")] protected IAlertMsgService AlertMsgService { get; set; }

        public PageBaseInfo PageInfo { get; set; } = PageBaseInfo.GetPageInfo(0, PageType.Candidate, "Candidate Search");

        public HrJobCandidateParmDTO BaseEntity { get; set; } = new HrJobCandidateParmDTO();
        public List<HrJobCandidateListDTO> MainEntityList { get; set; } = new List<HrJobCandidateListDTO>();

        private string action;
        private int jobId;
        protected override async Task OnInitializedAsync()
        {
            try
            {
                AlertMsgService.Reset();
                AlertMsgService.ReportPageLoading(true);

                NavManager.TryGetQueryString<string>("mode", out action);
                NavManager.TryGetQueryString<int>("job", out jobId);

                await InitializePageData();

                if (action.Compare("jobcandidates") && jobId > 0) //Preview job-candidates for a specific job
                {
                    BaseEntity.JobOrderIds.Add(jobId);
                    var entity = await PageDataService.Search(BaseEntity);
                    if (entity == null)
                    {
                        MainEntityList = new List<HrJobCandidateListDTO>();
                        AlertMsgService.ReportMessage("The record is not available to edit.", MsgType.Warning, MsgRole.Alert);
                        return;
                    }

                    MainEntityList = entity;
                }
                else
                {
                    MainEntityList = await PageDataService.Search(BaseEntity);
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

        protected async Task HandleValidSubmitAsync()
        {
            try
            {
                MainEntityList = await PageDataService.Search(BaseEntity);
            }
            catch (Exception ex)
            {
                AlertMsgService.ReportMessage(ex.Message, MsgType.Error, MsgRole.Alert);
            }
        }

    }
}
