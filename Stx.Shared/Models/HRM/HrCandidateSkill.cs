using Stx.Shared.Core;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stx.Shared.Models.HRM
{
	[Table("HrCandidateSkill")]
	public class HrCandidateSkill : BaseViewModel
	{
		public HrCandidateSkill DeepCopy()
		{
			HrCandidateSkill copy = new HrCandidateSkill();
			copy.ID = this.ID;
			copy.CandidateID = this.CandidateID;
			copy.SkillName = this.SkillName;
			copy.Proficiency = this.Proficiency;
			copy.SkillType = this.SkillType;
			copy.Comments = this.Comments;
			copy.DateLastModified = this.DateLastModified;
			copy.UserModified = this.UserModified;
			return copy;
		}

		private int _ID;
		private int _CandidateID;
		private string _SkillName;
		private short _Proficiency;
		private string _SkillType;
		private string _Comments;

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
		public string SkillName
		{
			get { return this._SkillName; }
			set
			{
				this._SkillName = value;
				NotifyPropertyChanged();
			}
		}
		/// <summary>
		/// 0 None, 1 Beginner, 2 Intermediate, 3 Advanced, 4 Expert, 5 Master
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

		public DateTime? DateLastModified { get; set; }
		public string UserModified { get; set; }


	}
}
