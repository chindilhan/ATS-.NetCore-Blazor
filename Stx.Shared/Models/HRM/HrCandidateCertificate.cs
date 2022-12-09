using Stx.Shared.Core;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stx.Shared.Models.HRM
{
	[Table("HrCandidateCertificate")]
	public class HrCandidateCertificate:BaseViewModel
	{
		public HrCandidateCertificate DeepCopy()
		{
			HrCandidateCertificate copy = new HrCandidateCertificate();
			copy.ID = this.ID;
			copy.CandidateID = this.CandidateID;
			copy.CertificateName = this.CertificateName;
			copy.LicenseNumber = this.LicenseNumber;
			copy.LicenseType = this.LicenseType;
			copy.Results = this.Results;
			copy.Status = this.Status;
			copy.IssuedBy = this.IssuedBy;
			copy.Country = this.Country;
			copy.Description = this.Description;
			copy.Comments = this.Comments;
			copy.IsPending = this.IsPending;
			copy.FileAttachments = this.FileAttachments;
			copy.Active = this.Active;
			copy.DateCertified = this.DateCertified;
			copy.DateExpiration = this.DateExpiration;
			copy.DateAdded = this.DateAdded;
			copy.DateLastModified = this.DateLastModified;
			return copy;
		}

		private int _ID;
		private int _CandidateID;
		private string _CertificateName;
		private string _LicenseNumber;
		private string _LicenseType;
		private string _Results;
		private string _Status;
		private string _IssuedBy;
		private short? _Country;
		private string _Description;
		private string _Comments;
		private bool? _IsPending;
		private string _FileAttachments;
		private bool? _Active;
		private DateTime? _DateCertified;
		private DateTime? _DateExpiration;
		private DateTime? _DateAdded;
		private DateTime? _DateLastModified;

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
		public string CertificateName
		{
			get { return this._CertificateName; }
			set
			{
				this._CertificateName = value;
				NotifyPropertyChanged();
			}
		}
		[StringLength(100)]
		public string LicenseNumber
		{
			get { return this._LicenseNumber; }
			set
			{
				this._LicenseNumber = value;
				NotifyPropertyChanged();
			}
		}
		[StringLength(30)]
		public string LicenseType
		{
			get { return this._LicenseType; }
			set
			{
				this._LicenseType = value;
				NotifyPropertyChanged();
			}
		}
		[StringLength(200)]
		public string Results
		{
			get { return this._Results; }
			set
			{
				this._Results = value;
				NotifyPropertyChanged();
			}
		}
		[StringLength(30)]
		public string Status
		{
			get { return this._Status; }
			set
			{
				this._Status = value;
				NotifyPropertyChanged();
			}
		}
		[StringLength(100)]
		public string IssuedBy
		{
			get { return this._IssuedBy; }
			set
			{
				this._IssuedBy = value;
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
		public bool? IsPending
		{
			get { return this._IsPending; }
			set
			{
				this._IsPending = value;
				NotifyPropertyChanged();
			}
		}
		[StringLength(200)]
		public string FileAttachments
		{
			get { return this._FileAttachments; }
			set
			{
				this._FileAttachments = value;
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
		public DateTime? DateCertified
		{
			get { return this._DateCertified; }
			set
			{
				this._DateCertified = value;
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
		public DateTime? DateAdded
		{
			get { return this._DateAdded; }
			set
			{
				this._DateAdded = value;
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

	}
}
