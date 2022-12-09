using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Radzen;
using Stx.Shared.Common;
using Stx.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Stx.HRM.Core
{
    public abstract class StxLayoutComponentBase : LayoutComponentBase , IAlertMsgService
    {
        public StxLayoutComponentBase()
        {
        }


        [Inject] protected IJSRuntime JsRuntime { get; set; }
        [Inject] NotificationService _notifService { get; set; }
        [Inject] DialogService _dialogService { get; set; }

        protected override void OnAfterRender(bool firstRender)
        {
            if (firstRender)
                JsRuntime.InvokeVoidAsync("nav");
        }

        private bool collapseNavMenu = false;
        public string NavMenuCssClass => collapseNavMenu ? "toggled" : null;

        private void ToggleNavMenu()
        {
            collapseNavMenu = !collapseNavMenu;
        }

        public void TopNavbar_ToggleMenuButtonClicked()
        {
            ToggleNavMenu();
        }

        #region Notification Implimentation

        //Alert msg
        private AlertMsg _PageAlert;
        public AlertMsg PageAlert
        {
            get { return _PageAlert ?? new AlertMsg(); }
            set { _PageAlert = value; }
        }
             
        public void Reset()
        {
            PageAlert = new AlertMsg();
            StateHasChanged();
        }
        public void ClearDisplayedPageAlert()
        {
            _PageAlert = new AlertMsg();
        }

        #region PAGE HEADER/TOP BANNER MESSAGES
        public void ReportMessage(string alertText, MsgType msgType = MsgType.None, MsgRole dispMode = MsgRole.Alert)
        {
            PageAlert = new AlertMsg(alertText, msgType, dispMode);
            StateHasChanged();

        }

        public void ReportMessage(object jsonMsg)
        {
            try
            {
                PageAlert.Reset();
                if (!string.IsNullOrWhiteSpace(jsonMsg?.ToString()))
                {
                    PageAlert = JsonSerializer.Deserialize<AlertMsg>(jsonMsg?.ToString());
                    StateHasChanged();
                    return;
                }
            }
            catch
            { }
            PageAlert = new AlertMsg();
            StateHasChanged();
        }

        public void CloseAlertButtonClicked()
        {
            PageAlert.Reset();
            StateHasChanged();
        }
        #endregion

        #region PAGE LOADING INDICATORS

        public bool IsPageLoading { get; set; }
        public void ReportPageLoading(bool isLoading)
        {
            IsPageLoading = isLoading;
            StateHasChanged();

        }
        #endregion

        #region ALERT TOAST MESSAGES

        public void Notify(string title, string alertText, MsgType msgType = MsgType.None, double duration = 3000)
        {
            ShowNotificationMessage(title, alertText, msgType, duration);
        }
        public void Notify(string alertText, MsgType msgType = MsgType.None, double duration = 3000)
        {
            ShowNotificationMessage(msgType.ToString(), alertText, msgType, duration);
        }

        private void ShowNotificationMessage(string title, string alertText, MsgType msgType = MsgType.None, double duration = 3000)
        {
            //NotifService.Notify(new NotificationMessage { Style = "background-color: #eee;margin-left: auto;", Severity = GetNotifSeverity(msgType), Summary = "title", Detail = "dddddddddddddd", Duration = 3000 });
            //NotifService.Notify(GetNotifSeverity(msgType), title, alertText, duration, "display: block; margin-left: 155px;margin-right: auto;");
            _notifService.Notify(GetNotifSeverity(msgType), title, alertText, duration);
        }

        private NotificationSeverity GetNotifSeverity(MsgType msgType)
        {
            if (msgType == MsgType.Error)
                return NotificationSeverity.Error;
            else if (msgType == MsgType.Warning)
                return NotificationSeverity.Warning;
            else if (msgType == MsgType.Info)
                return NotificationSeverity.Info;
            else if (msgType == MsgType.Success)
                return NotificationSeverity.Success;
            else //if (msgType == MsgType.None)
                return NotificationSeverity.Info;
        }
        #endregion

        #region CONFIRMATION DIALOG
        public async Task<bool?> ShowConfirmDialog(string message, string title)
        {
            return await this.ShowConfirmDialog(message, title, "Ok", "Cancel");
        }

        public async Task<bool?> ShowConfirmDialog(string message, string title, string okButtonText = "Ok", string cancelButtonText = "Cancel")
        {
            return await _dialogService.Confirm(message, title, new ConfirmOptions { OkButtonText = okButtonText, CancelButtonText = cancelButtonText });
        }
        #endregion

        #endregion


        #region Syncfusion Controls
        //SfToast ToastObj;
        //private string ToastPosition = "Right";
        //private string ToastContent = "Conference Room 01 / Building 135 10:00 AM-10:30 AM";
        //private async Task ShowOnClick()
        //{
        //    await this.ToastObj.ShowAsync();
        //}
        //private async Task HideOnClick()
        //{
        //    await this.ToastObj.HideAsync("All");
        //} 
        #endregion

    }
}
