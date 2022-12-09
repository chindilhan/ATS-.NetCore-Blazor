using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace Stx.HRM.Components
{
    public class EvaluationToolbarBase : ComponentBase
    {
        [Parameter]
        public EventCallback<string> MoveButtonClickedCallback { get; set; }
        [Parameter]
        public EventCallback<string> ToolButtonClickedCallback { get; set; }

        [Parameter]
        public EventCallback<string> ToolMenuClickedCallback { get; set; }

        protected async Task MoveButtonClicked(string stageToMove)
        {
            await MoveButtonClickedCallback.InvokeAsync(stageToMove);
        }
        protected async Task ToolButtonClicked(string toolActionName)
        {
            await ToolButtonClickedCallback.InvokeAsync(toolActionName);
        }
        protected async Task ToolMenuClicked(string toolActionName)
        {
            await ToolMenuClickedCallback.InvokeAsync(toolActionName);
        }
    }
}
