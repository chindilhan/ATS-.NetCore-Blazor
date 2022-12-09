using Microsoft.AspNetCore.Components;
using Stx.Shared.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Stx.CompLibrary.Common
{
	public partial class StxAlertMsgBase: ComponentBase
	{
		[Parameter]
		public EventCallback<bool> CloseButtonClickEventCallback { get; set; }

		[Parameter]
		public AlertMsg AlertMessage { get; set; }


		public string MsgStyles { get; private set; } = "docalert-msg-info";
		public string MsgIconStyles { get; private set; } = "bi-info-circle";

		protected override Task OnInitializedAsync()
		{

			if (AlertMessage != null)
			{
				switch (AlertMessage.MsgType)
				{
					case MsgType.Success:
						MsgStyles = "docalert-msg-success";
						MsgIconStyles = "bi-check-circle";
						break;
					case MsgType.Info:
						MsgStyles = "docalert-msg-info";
						MsgIconStyles = "bi-info-circle";
						break;
					case MsgType.Warning:
						MsgStyles = "docalert-msg-warning";
						MsgIconStyles = "bi-exclamation-circle";
						break;
					case MsgType.Error:
						MsgStyles = "docalert-msg-danger";
						MsgIconStyles = "bi-x-circle";
						break;
					default:
						MsgStyles = "docalert-msg-info";
						MsgIconStyles = "bi-info-circle";
						break;
				}
			}
			return base.OnInitializedAsync();
		}

		protected async Task CloseButtonClicked()
		{
			await CloseButtonClickEventCallback.InvokeAsync(true);
		}

	}
}
