using Stx.Shared.Core;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stx.Shared.Models.HRM
{
	[Table("HrCandidateExperience")]
	public class HrCandidateExperience: BaseViewModel
	{
		public HrCandidateExperience DeepCopy()
		{
			HrCandidateExperience copy = new HrCandidateExperience();
			copy.ID = this.ID;
			copy.CandidateID = this.CandidateID;
			copy.Title = this.Title;
			copy.CompanyName = this.CompanyName;
			copy.CorporateID = this.CorporateID;
			copy.Country = this.Country;
			copy.DateStart = this.DateStart;
			copy.DateEnd = this.DateEnd;
			copy.DateAdded = this.DateAdded;
			copy.IsCurrentJob = this.IsCurrentJob;
			copy.Active = this.Active;
			copy.Description = this.Description;
			copy.Comments = this.Comments;
			copy.Salary = this.Salary;
			copy.SalaryCycle = this.SalaryCycle;
			copy.Bonus = this.Bonus;
			copy.Commission = this.Commission;
			copy.JobOrderID = this.JobOrderID;
			copy.PlacementID = this.PlacementID;
			copy.TerminationReason = this.TerminationReason;
			return copy;
		}

		private int _ID;
		private int _CandidateID;
		private string _Title;
		private string _CompanyName;
		private int? _CorporateID;
		private short? _Country;
		private DateTime? _DateStart;
		private DateTime? _DateEnd;
		private DateTime? _DateAdded;
		private bool? _IsCurrentJob;
		private bool? _Active;
		private string _Description;
		private string _Comments;
		private decimal? _Salary;
		private string _SalaryCycle;
		private decimal? _Bonus;
		private decimal? _Commission;
		private int? _JobOrderID;
		private int? _PlacementID;
		private string _TerminationReason;

		public int ID
		{
			get { return this._ID; }
			set
			{
				this._ID = value;
				NotifyPropertyChanged();
			}
		}
		public int CandidateID
		{
			get { return this._CandidateID; }
			set
			{
				this._CandidateID = value;
				NotifyPropertyChanged();
			}
		}
		[StringLength(100)]
		public string Title
		{
			get { return this._Title; }
			set
			{
				this._Title = value;
				NotifyPropertyChanged();
			}
		}
		[StringLength(100)]
		public string CompanyName
		{
			get { return this._CompanyName; }
			set
			{
				this._CompanyName = value;
				NotifyPropertyChanged();
			}
		}
		public int? CorporateID
		{
			get { return this._CorporateID; }
			set
			{
				this._CorporateID = value;
				NotifyPropertyChanged();
			}
		}
		public short? Country
		{
			get { return this._Country; }
			set
			{
				this._Country = value;
				NotifyPropertyChanged();
			}
		}
		public DateTime? DateStart
		{
			get { return this._DateStart; }
			set
			{
				this._DateStart = value;
				NotifyPropertyChanged();
			}
		}
		public DateTime? DateEnd
		{
			get { return this._DateEnd; }
			set
			{
				this._DateEnd = value;
				NotifyPropertyChanged();
			}
		}
		public DateTime? DateAdded
		{
			get { return this._DateAdded; }
			set
			{
				this._DateAdded = value;
				NotifyPropertyChanged();
			}
		}
		public bool? IsCurrentJob
		{
			get { return this._IsCurrentJob ?? false; }
			set
			{
				this._IsCurrentJob = value ?? false;
				NotifyPropertyChanged();
			}
		}
		public bool? Active
		{
			get { return this._Active; }
			set
			{
				this._Active = value;
				NotifyPropertyChanged();
			}
		}
		[StringLength(3000)]
		public string Description
		{
			get { return this._Description; }
			set
			{
				this._Description = value;
				NotifyPropertyChanged();
			}
		}
		[StringLength(3000)]
		public string Comments
		{
			get { return this._Comments; }
			set
			{
				this._Comments = value;
				NotifyPropertyChanged();
			}
		}
		public decimal? Salary
		{
			get { return this._Salary; }
			set
			{
				this._Salary = value;
				NotifyPropertyChanged();
			}
		}
		[StringLength(6)]
		public string SalaryCycle
		{
			get { return this._SalaryCycle; }
			set
			{
				this._SalaryCycle = value;
				NotifyPropertyChanged();
			}
		}
		public decimal? Bonus
		{
			get { return this._Bonus; }
			set
			{
				this._Bonus = value;
				NotifyPropertyChanged();
			}
		}
		public decimal? Commission
		{
			get { return this._Commission; }
			set
			{
				this._Commission = value;
				NotifyPropertyChanged();
			}
		}
		public int? JobOrderID
		{
			get { return this._JobOrderID; }
			set
			{
				this._JobOrderID = value;
				NotifyPropertyChanged();
			}
		}
		public int? PlacementID
		{
			get { return this._PlacementID; }
			set
			{
				this._PlacementID = value;
				NotifyPropertyChanged();
			}
		}
		[StringLength(50)]
		public string TerminationReason
		{
			get { return this._TerminationReason; }
			set
			{
				this._TerminationReason = value;
				NotifyPropertyChanged();
			}
		}

	}
}
