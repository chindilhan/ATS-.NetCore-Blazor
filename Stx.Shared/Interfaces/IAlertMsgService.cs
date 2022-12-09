using Stx.Shared.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Stx.Shared.Interfaces
{
	public interface IAlertMsgService
	{
		//public string GetAlertJson(MsgType msgType, MsgRole dispMode, string alertText);
		public void ReportMessage(object jsonMsg);
		public void ReportMessage(string message, MsgType msgType = MsgType.None, MsgRole dispMode = MsgRole.Alert);
		public void Notify(string title, string message, MsgType msgType = MsgType.None, double duration = 3000);
		public void Notify(string message, MsgType msgType = MsgType.None, double duration = 3000);

        public Task<bool?> ShowConfirmDialog(string message, string title);
        public Task<bool?> ShowConfirmDialog(string message, string title, string okButtonText = "Ok", string cancelButtonText = "Cancel");

        void ReportPageLoading(bool isLoading = false);

		public void Reset();

	}
}
