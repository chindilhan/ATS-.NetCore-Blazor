using System;
using System.Collections.Generic;
using System.Text;

namespace Stx.Shared.Reports
{
    public class IPDoc
    {
		public IPDoc()
		{

		}

		public IPDoc(string fldDesc, string fldData, string style="")
		{
			FldDesc = fldDesc;
			FldData = fldData;
			Style = style;
		}

		public string FldDesc { get; set; }
		public string FldData { get; set; }
		public string Style { get; set; }
		//public bool IsForceDisp { get; set; }
	}
}
