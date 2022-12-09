using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using Stx.Shared.Common;
using Stx.Shared.Interfaces.Common;
using Stx.Shared.Models.Common;
using System;
using System.Threading.Tasks;

namespace Stx.HRM.Components.CorporateComp
{
    public class BillingPanelBase : ComponentBase
    {
        [Inject] ILogger<BillingPanelBase> Logger { get; set; }
        [Inject] IEmailClientDataService EmailClientDataService { get; set; }

        public Schedule CandSchedule { get; set; } = new Schedule();

        [Parameter]
        public EventCallback<ReturnObj> ComponentActionCallback { get; set; }

        [Parameter]
        public int JobOrderID { get; set; }

#pragma warning disable CS1998 // This async method lacks 'await' operators and will run synchronously. Consider using the 'await' operator to await non-blocking API calls, or 'await Task.Run(...)' to do CPU-bound work on a background thread.
        protected override async Task OnInitializedAsync()
#pragma warning restore CS1998 // This async method lacks 'await' operators and will run synchronously. Consider using the 'await' operator to await non-blocking API calls, or 'await Task.Run(...)' to do CPU-bound work on a background thread.
        {
            try
            {
                //await EmailClientDataService.GetEmailTemplates(JobOrderID);
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {

            }
        }

#pragma warning disable CS1998 // This async method lacks 'await' operators and will run synchronously. Consider using the 'await' operator to await non-blocking API calls, or 'await Task.Run(...)' to do CPU-bound work on a background thread.
        protected async Task SubmitButtonClicked()
#pragma warning restore CS1998 // This async method lacks 'await' operators and will run synchronously. Consider using the 'await' operator to await non-blocking API calls, or 'await Task.Run(...)' to do CPU-bound work on a background thread.
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(CandSchedule.Title))
                {
                    //var isSuccess = await EmailClientDataService.Send(CandSchedule.Title);
                    //if (isSuccess)
                    //{
                    //    ReturnObj ret = new ReturnObj(true) { RetResult = CandSchedule };
                    //    await ComponentActionCallback.InvokeAsync(ret);
                    //}
                    //else
                    //{

                    //}
                }
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {

            }
        }

        protected async Task CloseButtonClicked()
        {
            await ComponentActionCallback.InvokeAsync(new ReturnObj(false));
        }

    }
}
