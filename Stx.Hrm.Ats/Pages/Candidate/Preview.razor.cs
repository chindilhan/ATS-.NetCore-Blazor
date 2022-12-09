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

namespace Stx.HRM.Pages.Candidate
{
    public class PreviewBase : ComponentBase
    {
        [Inject] public NavigationManager NavManager { get; set; }
        [Inject] ILogger<PreviewBase> Logger { get; set; }
        [Inject] ICandidatePublicDataService CandidateDataService { get; set; }
        [CascadingParameter(Name = "AlertService")] protected IAlertMsgService AlertMsgService { get; set; }

        public PageBaseInfo PageInfo { get; set; } = PageBaseInfo.GetPageInfo(0, PageType.Candidate, "Candidate Preview");

        public HrCandidatePublicDTO BaseEntity { get; set; } = new HrCandidatePublicDTO();

        public List<SelectListItem> DocStatusList { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> MatterTypeList { get; set; }
        public List<SelectListItem> NiceClassIDList { get; set; }
        public IEnumerable<string> ClassIDs { get; set; } = new string[] { };

        private int CandId;
        protected override async Task OnInitializedAsync()
        {
            try
            {
                AlertMsgService.Reset();
                AlertMsgService.ReportPageLoading(true);

                NavManager.TryGetQueryString<int>("id", out CandId);

                await InitializePageData();

                if (CandId <= 0)
                {
                    BaseEntity = new HrCandidatePublicDTO();
                    AlertMsgService.ReportMessage("The requested id is incorrect.", MsgType.Warning, MsgRole.Toast);
                }
                else
                {
                    BaseEntity = await CandidateDataService.GetRecordByID(CandId);
                    if (BaseEntity == null)
                    {
                        BaseEntity = new HrCandidatePublicDTO();
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
