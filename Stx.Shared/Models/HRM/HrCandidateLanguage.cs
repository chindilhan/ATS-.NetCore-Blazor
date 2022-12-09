using Stx.Shared.Core;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stx.Shared.Models.HRM
{
	[Table("HrCandidateLanguage")]
	public class HrCandidateLanguage: BaseViewModel
	{
		public HrCandidateLanguage DeepCopy()
		{
			HrCandidateLanguage copy = new HrCandidateLanguage();
			copy.ID = this.ID;
			copy.CandidateID = this.CandidateID;
			copy.Language = this.Language;
			copy.Proficiency = this.Proficiency;
			copy.SkillType = this.SkillType;
			copy.Comments = this.Comments;
			copy.DateLastModified = this.DateLastModified;
			copy.UserModified = this.UserModified;
			return copy;
		}

		private int _ID;
		private int _CandidateID;
		private string _Language;
		private short _Proficiency;
		private string _SkillType;
		private string _Comments;
		private DateTime? _DateLastModified;
		private string _UserModified;

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
		public string Language
		{
			get { return this._Language; }
			set
			{
				this._Language = value;
				NotifyPropertyChanged();
			}
		}
		/// <summary>
		/// 0 Basic, 1 conversational, 2 Fluent, 3 Native/Bilingual
		/// </summary>
		public short Proficiency
		{
			get { return this._Proficiency; }
			set
			{
				this._Proficiency = value;
				NotifyPropertyChanged();
			}
		}
		[StringLength(5)]
		public string SkillType
		{
			get { return this._SkillType; }
			set
			{
				this._SkillType = value;
				NotifyPropertyChanged();
			}
		}
		[StringLength(200)]
		public string Comments
		{
			get { return this._Comments; }
			set
			{
				this._Comments = value;
				NotifyPropertyChanged();
			}
		}
		public DateTime? DateLastModified
		{
			get { return this._DateLastModified; }
			set
			{
				this._DateLastModified = value;
				NotifyPropertyChanged();
			}
		}
		public string UserModified
		{
			get { return this._UserModified; }
			set
			{
				this._UserModified = value;
				NotifyPropertyChanged();
			}
		}

	}
}
