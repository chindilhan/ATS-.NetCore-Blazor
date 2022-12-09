using Microsoft.AspNetCore.Components;
using Stx.Shared.Interfaces.HRM;
using Stx.Shared.Models.HRM;
using System;
using System.Threading.Tasks;

namespace Stx.CompLibrary
{
    public class AddEmployeeDialogBase : ComponentBase
    {
        public bool ShowDialog { get; set; }


        public HrEmployee Employee { get; set; } = new HrEmployee { CountryID = 1, JobCategoryID = 1, BirthDate = DateTime.Now, JoinedDate = DateTime.Now };

        [Parameter]
        public EventCallback<bool> CloseEventCallback { get; set; }

        [Inject]
        public IEmployeeDataService EmployeeDataService { get; set; }

        public void Show()
        {
            ShowDialog = true;
            StateHasChanged();
        }

        public void Close()
        {
            ShowDialog = false;
            StateHasChanged();
        }

        protected async Task HandleValidSubmit()
        {
            await EmployeeDataService.UpdateRecord(Employee);
            ShowDialog = false;

            await CloseEventCallback.InvokeAsync(true);
            StateHasChanged();
        }

    }
}
