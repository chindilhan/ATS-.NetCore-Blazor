using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Stx.CompLibrary
{
	public partial class StxPageHeader: ComponentBase
	{

		//[Parameter]
		//public EventCallback<string> AddButtonClickEventCallback { get; set; }


		[Parameter]
		public EventCallback<bool> CloseEventCallbacks { get; set; }

		[Parameter]
		public string PageHeader { get; set; }
		[Parameter]
		public string AddNewDocPageHref { get; set; }

		//protected async Task AddButtonClicked()
		//{
		//	await AddButtonClickEventCallback.InvokeAsync()
		//}

	}
}
