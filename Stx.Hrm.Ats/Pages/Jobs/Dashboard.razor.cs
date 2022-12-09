using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using Stx.Shared.Extensions.Common;
using Stx.Shared.Common;
using Stx.Shared.Interfaces;
using Stx.Shared.Interfaces.HRM;
using Stx.Shared.Models.HRM;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Stx.HRM.Pages.Jobs
{
    public class DashboardBase : ComponentBase
    {
        [Inject] public NavigationManager NavManager { get; set; }
        [Inject] ILogger<DashboardBase> Logger { get; set; }
        [Inject] IJobOrderDataService PageDataService { get; set; }
        [CascadingParameter(Name = "AlertService")] protected IAlertMsgService AlertMsgService { get; set; }

        public PageBaseInfo PageInfo { get; set; } = PageBaseInfo.GetPageInfo(0, PageType.Jobs, "Jobs");

        public HrJobOrder BaseEntity { get; set; } = new HrJobOrder();
        public List<HrJobSummaryDTO> MainEntityList { get; set; } = new List<HrJobSummaryDTO>();

        public List<SelectListItem> DocStatusList { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> MatterTypeList { get; set; }
        public List<SelectListItem> NiceClassIDList { get; set; }
        public IEnumerable<string> ClassIDs { get; set; } = new string[] { };

        protected override async Task OnInitializedAsync()
        {
            try
            {
                AlertMsgService.ReportPageLoading(true);
                BaseEntity = new HrJobOrder();

                await InitializePageData();
            }
            catch (Exception ex)
            {
                AlertMsgService.ReportMessage(ex.GetInnerExcpMsg(), MsgType.Error, MsgRole.Alert);
            }

            AlertMsgService.ReportPageLoading(false);
        }

        private async Task InitializePageData()
        {
            MainEntityList = await PageDataService.GetCorporateJobList(1);
        }

#pragma warning disable CS1998 // This async method lacks 'await' operators and will run synchronously. Consider using the 'await' operator to await non-blocking API calls, or 'await Task.Run(...)' to do CPU-bound work on a background thread.
        protected async Task HandleValidSubmitAsync()
#pragma warning restore CS1998 // This async method lacks 'await' operators and will run synchronously. Consider using the 'await' operator to await non-blocking API calls, or 'await Task.Run(...)' to do CPU-bound work on a background thread.
        {
            //await SubmitEntry(false);
        }

    }
}
