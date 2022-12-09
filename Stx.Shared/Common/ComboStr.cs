using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Stx.Shared.Common
{
	public class ComboStr : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		private void RaisePropertyChanged(string info)
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(info));
			}
		}

		private string _Value;
		private string _Text;
		public ComboStr()
		{
		}

		public ComboStr(string value, string text)
		{
			Value = value;
			Text = text;
		}

		public string Value
		{
			get { return _Value; }
			set
			{
				_Value = value;
				RaisePropertyChanged("Value");
			}
		}

		public string Text
		{
			get { return _Text; }
			set
			{
				_Text = value;
				RaisePropertyChanged("Text");
			}
		}

	}
}
