using BlazorInputFile;
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
using System.IO;
using System.Linq;
using System.Threading.Tasks;


namespace Stx.HRM.Pages.Candidate
{
    public class ImportBase : ComponentBase
    {
        [Inject] public NavigationManager NavManager { get; set; }
        [Inject] ILogger<ImportBase> Logger { get; set; }
        [Inject] IJobCandidateDataService PageDataService { get; set; }
        [Inject] IJobOrderDataService JobOrderDataService { get; set; }

        [CascadingParameter(Name = "AlertService")] protected IAlertMsgService AlertMsgService { get; set; }

        public PageBaseInfo PageInfo { get; set; } = PageBaseInfo.GetPageInfo(0, PageType.Candidate, "Candidate Search");

        public HrJobCandidate BaseEntity { get; set; } = new HrJobCandidate();

        public List<SelectListItem> DocStatusList { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> MatterTypeList { get; set; }
        public List<SelectListItem> NiceClassIDList { get; set; }
        public IEnumerable<string> ClassIDs { get; set; } = new string[] { };
        public string JobTitle { get; set; } 

        private string Actn;
        private int Id;
        private int JobOrderId;
        protected override async Task OnInitializedAsync()
        {
            try
            {
                AlertMsgService.ReportPageLoading(true);

                BaseEntity = new HrJobCandidate();
                NavManager.TryGetQueryString<string>("Actn", out Actn);
                NavManager.TryGetQueryString<int>("Id", out Id);
                NavManager.TryGetQueryString<int>("job", out JobOrderId);
                //await InitializePageData();

                if (Actn.InIgnoreCase("e", EntryState.Update.ToString()) && Id > 0)
                {
                    BaseEntity = await PageDataService.GetRecordByID(Id);
                    if (BaseEntity == null)
                    {
                        AlertMsgService.ReportMessage("The record may not exists in the system.", MsgType.Success, MsgRole.Toast);
                    }
                    PageInfo.PageTitle = $"Import Candidate : {BaseEntity.FirstName} {BaseEntity.LastName}";
                }
                else
                {
                    BaseEntity = new HrJobCandidate();
                    if (JobOrderId > 0)
                    {
                        BaseEntity.JobOrderID = JobOrderId;
                        JobTitle = (await JobOrderDataService.GetRecordByID(JobOrderId)).Title;
                    }
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

#pragma warning disable CS1998 // This async method lacks 'await' operators and will run synchronously. Consider using the 'await' operator to await non-blocking API calls, or 'await Task.Run(...)' to do CPU-bound work on a background thread.
        protected async Task HandleInvalidSubmitAsync()
#pragma warning restore CS1998 // This async method lacks 'await' operators and will run synchronously. Consider using the 'await' operator to await non-blocking API calls, or 'await Task.Run(...)' to do CPU-bound work on a background thread.
        {
            //await SubmitEntry(false);
        }


        const int MaxFileSize = 5 * 1024 * 1024; // 5MB
        public string DefaultStatus = "Drop your file here or click to choose a file";
        public string fileName;
        public string fileTextContents;
        public string status = "";

        public async Task ViewFile(IFileListEntry[] files)
        {
            status = DefaultStatus;
            var file = files.FirstOrDefault();
            if (file == null)
            {
                return;
            }
            else if (file.Size > MaxFileSize)
            {
                status = $"That's too big. Max size: {MaxFileSize} bytes.";
            }
            else
            {
                status = "Loading...";

                using (var reader = new StreamReader(file.Data))
                {
                    fileTextContents = await reader.ReadToEndAsync();
                    fileName = file.Name;
                }

                status = DefaultStatus;
            }
        }
    }


}
