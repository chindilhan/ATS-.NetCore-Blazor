using System;
using System.Collections.Generic;
using System.Text;

namespace Stx.Shared.Common
{
	public class ComboShort
	{
		public ComboShort()
		{
		}

		public ComboShort(short value, string text)
		{
			Value = value;
			Text = text;
		}

		public short Value { get; set; }
		public string Text { get; set; }

	}
}
