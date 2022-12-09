using Stx.Shared.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stx.Shared.Status
{
	/// <summary>
	/// Class to manage the document status for general documents
	/// -1 = New, 0 = Open, 1 = Closed, 2 = Cancelled, 3 = Deleted/Void, 4 = Hold, 6 = Draft
	/// </summary>
	public static class DocStatus
	{
		public const int New = -1;
		public const int Open = 0;
		public const int Closed = 1;
		public const int Cancelled = 2;
		public const int Deleted = 3;
		public const int Hold = 4;
		public const int Draft = 6;


		/// <summary>
		/// Get the doc status description based on the given status
		/// -1 = New, 0 = Open, 1 = Closed, 2 = Cancelled, 3 = Deleted/Void, 4 = Hold, 6 = Draft
		/// <param name="docStatus">document status</param>
		/// </summary>
		public static string GetName(int docStatus)
		{
			switch (docStatus)
			{
				case -1:
					return "<New>";
				case 0:
					return "Open";
				case 1:
					return "Closed";
				case 2:
					return "Cancelled";
				case 3:
					return "Deleted";
				case 4:
					return "Hold";
				case 6:
					return "Draft";
				default:
					return "Undefined";
			}
		}

		public static List<ComboInt> GetDocStatusList()
        {
			return new List<ComboInt>
			{
				new ComboInt(0, GetName(0)),
				new ComboInt(1, GetName(1)),
				new ComboInt(2, GetName(2)),
				new ComboInt(3, GetName(3)),
				new ComboInt(4, GetName(4)),
				new ComboInt(6, GetName(6)),
			};
        }


	}

}
