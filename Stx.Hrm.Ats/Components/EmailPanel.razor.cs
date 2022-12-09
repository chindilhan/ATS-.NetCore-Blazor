using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using Stx.Shared.Common;
using Stx.Shared.Interfaces.Common;
using Stx.Shared.Models.Common;
using System;
using System.Threading.Tasks;

namespace Stx.HRM.Components
{
    public class EmailPanelBase : ComponentBase
    {
        [Inject] ILogger<EmailPanelBase> Logger { get; set; }
        [Inject] IEmailClientDataService EmailClientDataService { get; set; }

        public EmailMsg Email { get; set; } = new EmailMsg();

        [Parameter]
        public EventCallback<ReturnObj> ComponentActionCallback { get; set; }

        [Parameter]
        public int JobOrderID { get; set; }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                await EmailClientDataService.GetEmailTemplates(JobOrderID);
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {

            }
        }

        protected async Task SubmitButtonClicked()
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(Email.Body))
                {
                    var isSuccess = await EmailClientDataService.Send(Email);
                    if (isSuccess)
                    {
                        ReturnObj ret = new ReturnObj(true) { RetResult = Email };
                        await ComponentActionCallback.InvokeAsync(ret);
                    }
                    else
                    {

                    }
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
