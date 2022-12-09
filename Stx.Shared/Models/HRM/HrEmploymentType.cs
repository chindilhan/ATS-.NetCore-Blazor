using Stx.Shared.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Stx.Shared.Models.HRM
{
    public class HrEmploymentType: BaseViewModel
    {
        public HrEmploymentType()
        {

        }

        public HrEmploymentType(short id, string employmentType)
        {
            ID = id;
            EmploymentType = employmentType;
        }


		private bool _IsSelected;
		private short _ID;
		private string _EmploymentType;

        [NotMapped]
		public bool IsSelected
		{
			get { return this._IsSelected; }
			set
			{
				this._IsSelected = value;
				NotifyPropertyChanged();
			}
		}
		public short ID
		{
			get { return this._ID; }
			set
			{
				this._ID = value;
				NotifyPropertyChanged();
			}
		}
		public string EmploymentType
		{
			get { return this._EmploymentType; }
			set
			{
				this._EmploymentType = value;
				NotifyPropertyChanged();
			}
		}

	}
}
