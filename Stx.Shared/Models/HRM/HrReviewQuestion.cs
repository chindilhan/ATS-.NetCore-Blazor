using Microsoft.AspNetCore.Components;
using Stx.Shared;
using Stx.Shared.Common;
using Stx.Shared.Extensions;
using Stx.Shared.Extensions.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stx.Shared.Models.HRM
{
	[Table("HrReviewQuestion")]
	public class HrReviewQuestion: INotifyPropertyChanged
	{

		public event PropertyChangedEventHandler PropertyChanged;

		private void RaisePropertyChanged(string info)
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(info));
			}
		}

        public HrReviewQuestion()
        {
            //FieldSrcDataList.ListChanged += HandleFieldSrcDataListItemChanged;
        }

        //private void HandleFieldSrcDataListItemChanged(object sender, ListChangedEventArgs e)
        //{
        //    RaisePropertyChanged(e.ListChangedType.ToString());
        //}

        private int _ID;
        private int _JobOrderID;
        private bool _IsAutoEvaluate = false;
        private string _FieldSrcData;
        private string _FieldType;
        private string _Desc;
        private string _RequiredAnswer;
        private string _EvaluateCriteria;
        private string _EvaluateType;
        private BindingList<ComboStr> _FieldSrcDataList = new BindingList<ComboStr>();
        private DateTime? _DateLastModified;
        private string _UserModified;
        private string _UserAnswer;

        #region Properties

        public int ID
        {
            get { return this._ID; }
            set
            {
                this._ID = value;
                RaisePropertyChanged("ID");
                if (_DisplayKey <= 0) _DisplayKey = value;
            }
        }
        public int JobOrderID
        {
            get { return this._JobOrderID; }
            set
            {
                this._JobOrderID = value;
                RaisePropertyChanged("JobOrderID");
            }
        }
        public bool IsAutoEvaluate
        {
            get { return this._IsAutoEvaluate; }
            set
            {
                this._IsAutoEvaluate = value;
                RaisePropertyChanged("IsAutoEvaluate");
            }
        }

        public string FieldSrcData
        {
            get { return _FieldSrcData; }
            set
            {
                _FieldSrcData = value;
                //RaisePropertyChanged("FieldSrcData");
            }
        }

        public string FieldType
        {
            get { return this._FieldType; }
            set
            {
                this._FieldType = value;
                RaisePropertyChanged("FieldType");
            }
        }

        public string Desc
        {
            get { return this._Desc; }
            set
            {
                this._Desc = value;
                RaisePropertyChanged("Desc");
            }
        }

        public string RequiredAnswer
        {
            get { return this._RequiredAnswer; }
            set
            {
                this._RequiredAnswer = value;
                RaisePropertyChanged("RequiredAnswer");
            }
        }
        /// <summary>
        /// fill, min, yn, mcq, num
        /// </summary>
        public string EvaluateCriteria
        {
            get { return this._EvaluateCriteria; }
            set
            {
                this._EvaluateCriteria = value;
                RaisePropertyChanged("EvaluateCriteria");
            }
        }
        /// <summary>
        /// R- Required | O - Optional
        /// </summary>
        public string EvaluateType
        {
            get { return this._EvaluateType; }
            set
            {
                this._EvaluateType = value;
                RaisePropertyChanged("EvaluateType");
            }
        }
        public DateTime? DateLastModified
        {
            get { return this._DateLastModified; }
            set
            {
                this._DateLastModified = value;
                RaisePropertyChanged("DateLastModified");
            }
        }
        public string UserModified
        {
            get { return this._UserModified; }
            set
            {
                this._UserModified = value;
                RaisePropertyChanged("UserModified");
            }
        }

        int _DisplayKey = 0;
        [NotMapped]
        public int DisplayKey
        {
            get { return this._DisplayKey; }
            set
            {
                this._DisplayKey = value;
                RaisePropertyChanged("DisplayKey");
            }
        }
        [NotMapped]
        public BindingList<ComboStr> FieldSrcDataList
        {
            get { return this._FieldSrcDataList; }
            set
            {
                this._FieldSrcDataList = value;
                RaisePropertyChanged("FieldSrcDataList");
            }
        }

        [NotMapped]
        public string UserAnswer
        {
            get { return this._UserAnswer; }
            set
            {
                this._UserAnswer = value;
                RaisePropertyChanged("UserAnswer");
            }
        }


        #endregion

        public void SplitSrcDataToList()
		{
			if (!string.IsNullOrWhiteSpace(FieldType) && FieldType.Compare("list"))
			{
				FieldSrcDataList.Clear();
				try
				{
                    if (string.IsNullOrWhiteSpace(FieldSrcData))
                    {
                        FieldSrcData = "";
                        FieldSrcDataList.Add(new ComboStr());
                    }
                    else
                    {
                        FieldSrcData.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries)
                            .Where(x => !string.IsNullOrWhiteSpace(x)).ToList()
                            .ForEach(x => FieldSrcDataList.Add(new ComboStr(x, x)));
                    }
                    RaisePropertyChanged("FieldSrcData");
                }
                catch { }
			}
		}
		public void UpdateListItemData()
        {
            RaisePropertyChanged("FieldSrcDataList");
            UpdateFieldSrcData();
        }
        public void UpdateFieldSrcData()
		{
			if (FieldSrcDataList != null && FieldSrcDataList.Count > 0)
			{
				try
				{
					FieldSrcData = string.Join(",", FieldSrcDataList.Select(x=> x.Value));
                    RaisePropertyChanged("FieldSrcData");

                    //FieldSrcDataList
                    //	.Where(x => !string.IsNullOrWhiteSpace(x.Value) && string.IsNullOrWhiteSpace(x.Text))
                    //	.ToList().ForEach(x => x.Text = x.Value);
                }
                catch { }
			}
		}

	}
}
