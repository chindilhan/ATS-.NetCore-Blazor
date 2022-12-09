using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using Stx.Shared.Extensions.Blazor;
using Stx.Shared.Extensions.Common;
using Stx.Shared.Common;
using Stx.Shared.Interfaces;
using Stx.Shared.Interfaces.HRM;
using Stx.Shared.Models.HRM;
using Stx.Shared.Status;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Stx.HRM.Pages.Jobs
{
    public class PreviewBase : ComponentBase
    {
        [Inject] public NavigationManager NavManager { get; set; }
        [Inject] ILogger<PreviewBase> Logger { get; set; }
        [Inject] ICandidateDataService PageDataService { get; set; }
        [CascadingParameter(Name = "AlertService")] protected IAlertMsgService AlertMsgService { get; set; }

        public PageBaseInfo PageInfo { get; set; } = PageBaseInfo.GetPageInfo(0, PageType.Jobs, "Job Preview");

        public HrCandidate BaseEntity { get; set; } = new HrCandidate();

        public List<SelectListItem> DocStatusList { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> MatterTypeList { get; set; }
        public List<SelectListItem> NiceClassIDList { get; set; }
        public IEnumerable<string> ClassIDs { get; set; } = new string[] { };

        private string Actn;
        private int Id;
        protected override async Task OnInitializedAsync()
        {
            try
            {
                AlertMsgService.ReportPageLoading(true);

                BaseEntity = new HrCandidate();
                NavManager.TryGetQueryString<string>("Actn", out Actn);
                NavManager.TryGetQueryString<int>("Id", out Id);
                //await InitializePageData();

                if (Actn.InIgnoreCase("e", EntryState.Update.ToString()) && Id > 0)
                {
                    BaseEntity = await PageDataService.GetRecordByID(Id);
                    if (BaseEntity == null)
                    {
                        AlertMsgService.ReportMessage("The trademark may not exists in the system.", MsgType.Success, MsgRole.Toast);
                    }
                    PageInfo.PageTitle = $"Candidate Preview : {BaseEntity.FirstName} {BaseEntity.LastName}";
                }
                else
                {
                    BaseEntity = new HrCandidate();
                }

                await InitializePageData();
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
