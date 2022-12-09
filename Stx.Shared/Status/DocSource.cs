using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stx.Shared.Status
{

	/// <summary>
	/// Class to manage the document source for general documents
	/// 0 = Default, 2 = Imported, 3 = Erp
	/// </summary>
	public static class DocSource
	{
		public const int Entry = 0;
		public const int Imported = 2;
		public const int Erp = 3;


		/// <summary>
		/// Get the document source description based on the given doc source value
		/// 0 = Default, 2 = Imported, 3 = Erp
		/// <param name="docSource">document source</param>
		/// </summary>
		public static string GetName(int docSource)
		{
			switch (docSource)
			{
				case 0:
					return "Entry";
				case 2:
					return "Imported";
				case 3:
					return "Erp";
				default:
					return "Undefined";
			}
		}
	}
}
