using Stx.Shared.Core;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stx.Shared.Models.HRM
{
	[Table("HrCandidateEducation")]
	public class HrCandidateEducation: BaseViewModel
	{
		public HrCandidateEducation DeepCopy()
		{
			HrCandidateEducation copy = new HrCandidateEducation();
			copy.ID = this.ID;
			copy.CandidateID = this.CandidateID;
			copy.Institute = this.Institute;
			copy.InstituteUnit = this.InstituteUnit;
			copy.Country = this.Country;
			copy.City = this.City;
			copy.QualificationName = this.QualificationName;
			copy.QualificationType = this.QualificationType;
			copy.FieldOfStudy = this.FieldOfStudy;
			copy.DateGraduated = this.DateGraduated;
			copy.DateStarted = this.DateStarted;
			copy.DateExpiration = this.DateExpiration;
			copy.Major = this.Major;
			copy.Grade = this.Grade;
			copy.Gpa = this.Gpa;
			copy.Comments = this.Comments;
			copy.Active = this.Active;
			return copy;
		}

		private int _ID;
		private int _CandidateID;
		private string _Institute;
		private string _InstituteUnit;
		private short? _Country;
		private short? _City;
		private string _QualificationName;
		private string _QualificationType;
		private string _FieldOfStudy;
		private DateTime _DateGraduated;
		private DateTime? _DateStarted;
		private DateTime? _DateExpiration;
		private string _Major;
		private string _Grade;
		private double? _Gpa;
		private string _Comments;
		private bool? _Active;

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
		public string Institute
		{
			get { return this._Institute; }
			set
			{
				this._Institute = value;
				NotifyPropertyChanged();
			}
		}
		[StringLength(100)]
		public string InstituteUnit
		{
			get { return this._InstituteUnit; }
			set
			{
				this._InstituteUnit = value;
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
		public short? City
		{
			get { return this._City; }
			set
			{
				this._City = value;
				NotifyPropertyChanged();
			}
		}
		[StringLength(100)]
		public string QualificationName
		{
			get { return this._QualificationName; }
			set
			{
				this._QualificationName = value;
				NotifyPropertyChanged();
			}
		}
		[StringLength(30)]
		public string QualificationType
		{
			get { return this._QualificationType; }
			set
			{
				this._QualificationType = value;
				NotifyPropertyChanged();
			}
		}
		[StringLength(50)]
		public string FieldOfStudy
		{
			get { return this._FieldOfStudy; }
			set
			{
				this._FieldOfStudy = value;
				NotifyPropertyChanged();
			}
		}
		public DateTime DateGraduated
		{
			get { return this._DateGraduated; }
			set
			{
				this._DateGraduated = value;
				NotifyPropertyChanged();
			}
		}
		public DateTime? DateStarted
		{
			get { return this._DateStarted; }
			set
			{
				this._DateStarted = value;
				NotifyPropertyChanged();
			}
		}
		public DateTime? DateExpiration
		{
			get { return this._DateExpiration; }
			set
			{
				this._DateExpiration = value;
				NotifyPropertyChanged();
			}
		}
		[StringLength(100)]
		public string Major
		{
			get { return this._Major; }
			set
			{
				this._Major = value;
				NotifyPropertyChanged();
			}
		}
		[StringLength(30)]
		public string Grade
		{
			get { return this._Grade; }
			set
			{
				this._Grade = value;
				NotifyPropertyChanged();
			}
		}
		public double? Gpa
		{
			get { return this._Gpa; }
			set
			{
				this._Gpa = value;
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
		public bool? Active
		{
			get { return this._Active; }
			set
			{
				this._Active = value;
				NotifyPropertyChanged();
			}
		}

	}
}
