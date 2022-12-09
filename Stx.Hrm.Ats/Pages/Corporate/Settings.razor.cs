using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using Stx.Shared.Extensions.Blazor;
using Stx.Shared.Extensions.Common;
using Stx.Shared.Common;
using Stx.Shared.Interfaces;
using Stx.Shared.Interfaces.HRM;
using Stx.Shared.Models.CRM;
using Stx.Shared.Status;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Stx.HRM.Pages.Corporate
{
    public class SettingsBase : ComponentBase
    {
        [Inject] public NavigationManager NavManager { get; set; }
        [Inject] ILogger<SettingsBase> Logger { get; set; }
        [Inject] IJobCandidateDataService PageDataService { get; set; }

        [CascadingParameter(Name = "AlertService")] protected IAlertMsgService AlertMsgService { get; set; }

        public PageBaseInfo PageInfo { get; set; } = PageBaseInfo.GetPageInfo(0, PageType.Corporate, "Corporate Settings");

        public string CurrentPartialView { get; set; }
        public Stx.Shared.Models.CRM.Corporate BaseEntity { get; set; } = new Stx.Shared.Models.CRM.Corporate();

        public List<SelectListItem> DocStatusList { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> MatterTypeList { get; set; }
        public List<SelectListItem> NiceClassIDList { get; set; }
        public IEnumerable<string> ClassIDs { get; set; } = new string[] { };
        [Parameter]
        public string catg
        {
            get { return ""; }
            set
            {
                var ddd = value;
            }
        }

        private string Actn;
        private string category;
        private int Id;
        protected override async Task OnInitializedAsync()
        {
            try
            {
                AlertMsgService.Reset();
                AlertMsgService.ReportPageLoading(true);

                BaseEntity = new Stx.Shared.Models.CRM.Corporate() { CorporateID =1  }; //TODO: remove; 1 is for test only
                NavManager.TryGetQueryString<string>("actn", out Actn);
                NavManager.TryGetQueryString<string>("catg", out category);
                NavManager.TryGetQueryString<int>("Id", out Id);
                //await InitializePageData();

                if (Actn.InIgnoreCase("e", EntryState.Update.ToString()) && Id > 0)
                {
                    //BaseEntity = await PageDataService.GetRecordByID(Id);
                    //if (BaseEntity == null)
                    //{
                    //    AlertMsgService.ReportMessage("The trademark may not exists in the system.", MsgType.Success, MsgRole.Toast);
                    //}
                    //PageInfo.PageTitle = $"Candidate Preview : {BaseEntity.FirstName} {BaseEntity.LastName}";
                } 
                //else if (!string.IsNullOrWhiteSpace(category))
                //{
                //    BaseEntity = new HrCandidate();
                //    await SettingMenuButtonClicked(category);
                //}
                else if(string.IsNullOrWhiteSpace(category))
                {
                    BaseEntity = new Stx.Shared.Models.CRM.Corporate() { CorporateID = 1 }; //TODO: remove; 1 is for test only
                    CurrentPartialView = "profile";
                }

            }
            catch (Exception ex)
            {
                AlertMsgService.ReportMessage(ex.GetInnerExcpMsg(), MsgType.Error, MsgRole.Alert);
            }

            AlertMsgService.ReportPageLoading(false);
        }

        protected override async Task OnParametersSetAsync()
        {
            try
            {
                NavManager.TryGetQueryString<string>("catg", out category);
                if (!string.IsNullOrWhiteSpace(category) && !category.Compare(CurrentPartialView))
                {
                    await SettingMenuButtonClicked(category);
                }
            }
            catch (Exception ex)
            {
                AlertMsgService.ReportMessage(ex.GetInnerExcpMsg(), MsgType.Error, MsgRole.Alert);
            }
        }

        protected async Task HandleValidSubmitAsync()
        {
            try
            {
                //await PageDataService.upda(false);
            }
            catch (Exception ex)
            {
                AlertMsgService.ReportMessage(ex.GetInnerExcpMsg(), MsgType.Error, MsgRole.Alert);
            }
        }

        protected async Task SettingMenuButtonClicked(string action)
        {
            try
            {
                AlertMsgService.Reset();
                if (string.IsNullOrWhiteSpace(action))
                {
                    CurrentPartialView = null;
                    StateHasChanged();
                }
                else 
                {
                    CurrentPartialView = action;
                    StateHasChanged();
                }                
            }
            catch (Exception ex)
            {

            }
        }

        protected async Task ComponentActionCallback(ReturnObj ret)
        {

        }

    }
}
