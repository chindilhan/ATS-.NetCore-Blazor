using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Stx.Shared.Models.Parm
{
    [NotMapped]
    public class HrJobSearchParmDTO
    {
        private string _SearchMode = "";
        private int _CandidateID;
        private string _Keyword = "";
        private string _Location = "";
        private List<short> _EmploymentTypes;
        private List<string> _JobIndustries = new List<string>();
        private string _Specialty = "";
        private decimal _SalaryFrom = 0;
        private decimal _SalaryTo = 0;
        private int _CorporateID;

        public HrJobSearchParmDTO()
        {

        }

        public HrJobSearchParmDTO(string keyword, string location, List<string> jobIndustries, int candidateId)
        {
            this.Keyword = keyword;
            this.Location = location;
            this.JobIndustries = jobIndustries;
            this.CandidateID = candidateId;
        }
		public HrJobSearchParmDTO(int corporateID)
		{
			this.SearchMode = "CORP";
			this.CorporateID = corporateID;
		}

		public string SearchMode 
		{
			get { return this._SearchMode; }
			set
			{
				this._SearchMode = value;
				//NotifyPropertyChanged();
			}
		}

		public int CorporateID
		{
			get { return this._CorporateID; }
			set
			{
				this._CorporateID = value;
				//NotifyPropertyChanged();
			}
		}

		public int CandidateID
		{
			get { return this._CandidateID; }
			set
			{
				this._CandidateID = value;
				//NotifyPropertyChanged();
			}
		}

		public string Keyword
		{
			get { return this._Keyword; }
			set
			{
				this._Keyword = value;
				//NotifyPropertyChanged();
			}
		}
		public string Location
		{
			get { return this._Location; }
			set
			{
				this._Location = value;
				//NotifyPropertyChanged();
			}
		}
		public List<short> EmploymentTypes
		{
			get { return this._EmploymentTypes; }
			set
			{
				this._EmploymentTypes = value;
				//NotifyPropertyChanged();
			}
		}
		public List<string> JobIndustries
		{
			get { return _JobIndustries ?? new List<string>(); }
			set
			{
				this._JobIndustries = value;
				//NotifyPropertyChanged();
			}
		}
		public string Specialty
		{
			get { return this._Specialty; }
			set
			{
				this._Specialty = value;
				//NotifyPropertyChanged();
			}
		}
		public decimal SalaryFrom
		{
			get { return this._SalaryFrom; }
			set
			{
				this._SalaryFrom = value;
				//NotifyPropertyChanged();
			}
		}
		public decimal SalaryTo
		{
			get { return this._SalaryTo; }
			set
			{
				this._SalaryTo = value;
				//NotifyPropertyChanged();
			}
		}

	}
}
