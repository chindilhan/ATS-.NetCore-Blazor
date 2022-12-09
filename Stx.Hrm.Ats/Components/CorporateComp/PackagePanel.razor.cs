using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using Stx.Shared.Common;
using Stx.Shared.Interfaces.Common;
using Stx.Shared.Models.Common;
using System;
using System.Threading.Tasks;

namespace Stx.HRM.Components.CorporateComp
{
    public class PackagePanelBase : ComponentBase
    {
        [Inject] ILogger<PackagePanelBase> Logger { get; set; }
        [Inject] IEmailClientDataService EmailClientDataService { get; set; }

        public Schedule CandSchedule { get; set; } = new Schedule();

        [Parameter]
        public EventCallback<ReturnObj> ComponentActionCallback { get; set; }

        [Parameter]
        public int JobOrderID { get; set; }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                //await EmailClientDataService.GetEmailTemplates(JobOrderID);
            }
            catch (Exception ex)
            {

            }
        }

        protected async Task SubmitButtonClicked()
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
            catch (Exception ex)
            {

            }
        }

        protected async Task CloseButtonClicked()
        {
            await ComponentActionCallback.InvokeAsync(new ReturnObj(false));
        }

    }
}
