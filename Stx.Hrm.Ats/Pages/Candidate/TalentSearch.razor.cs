using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using Stx.Shared.Extensions.Blazor;
using Stx.Shared.Extensions.Common;
using Stx.Shared.Common;
using Stx.Shared.Interfaces;
using Stx.Shared.Interfaces.HRM;
using Stx.Shared.Models.HRM;
using Stx.Shared.Models.Parm;
using Stx.Shared.Status;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Stx.HRM.Pages.Candidate
{
    public class TalentSearchBase : ComponentBase
    {
        [Inject] public NavigationManager NavManager { get; set; }
        [Inject] ILogger<TalentSearchBase> Logger { get; set; }
        [Inject] ICandidatePublicDataService PageDataService { get; set; }

        [CascadingParameter(Name = "AlertService")] protected IAlertMsgService AlertMsgService { get; set; }

        public PageBaseInfo PageInfo { get; set; } = PageBaseInfo.GetPageInfo(0, PageType.Candidate, "Candidate Search");

        public HrCandidateParmDTO BaseEntity { get; set; } = new HrCandidateParmDTO();

        public List<HrCandidatePublicDTO> MainEntityList { get; set; } = new List<HrCandidatePublicDTO>();

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
                AlertMsgService.Reset();
                AlertMsgService.ReportPageLoading(true);

                BaseEntity = new HrCandidateParmDTO();
                NavManager.TryGetQueryString<string>("Actn", out Actn);
                NavManager.TryGetQueryString<int>("Id", out Id);
                //await InitializePageData();

                if (Actn.InIgnoreCase("e", EntryState.Update.ToString()) && Id > 0)
                {
                    var entity = await PageDataService.GetRecordByID(Id);
                    if (entity == null)
                    {
                        AlertMsgService.ReportMessage("The entity may not exists in the system.", MsgType.Success, MsgRole.Toast);
                        return;
                    }
                    PageInfo.PageTitle = $"Talent Search : {entity.FirstName} {entity.LastName}";
                }
                else
                {
                    BaseEntity = new HrCandidateParmDTO();
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

        protected async Task HandleValidSubmitAsync()
        {
            try
            {
                AlertMsgService.Reset();
                MainEntityList = await PageDataService.Search(BaseEntity);
            }
            catch (Exception ex)
            {
                AlertMsgService.ReportMessage(ex.Message, MsgType.Error, MsgRole.Alert);
            }
        }

#pragma warning disable CS1998 // This async method lacks 'await' operators and will run synchronously. Consider using the 'await' operator to await non-blocking API calls, or 'await Task.Run(...)' to do CPU-bound work on a background thread.
        protected async Task HandleInvalidSubmitAsync()
#pragma warning restore CS1998 // This async method lacks 'await' operators and will run synchronously. Consider using the 'await' operator to await non-blocking API calls, or 'await Task.Run(...)' to do CPU-bound work on a background thread.
        {
            //await SubmitEntry(false);
        }

    }
}
