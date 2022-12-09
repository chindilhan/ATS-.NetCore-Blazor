using System;
using System.Collections.Generic;
using System.Text;

namespace Stx.Shared.Common
{
	public class ComboInt
	{
		public ComboInt()
		{
		}

		public ComboInt(int value, string text)
		{
			Value = value;
			Text = text;
		}

		public int Value { get; set; }
		public string Text { get; set; }

	}
}
