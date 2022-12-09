using Stx.Shared;
using Stx.Shared.Common;
using Stx.Shared.Extensions.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stx.HRM.Components.Job
{
	[Table("HrReviewQuestion")]
	public class HrReviewQuestion
	{
		private string _FieldSrcData;
		public int ID { get; set; }
		public bool IsAutoEvaluate { get; set; }
		public string FieldSrcData
		{
			get { return _FieldSrcData; }
			set
			{
				_FieldSrcData = value;
				UpdateList();
			}
		}
		public string FieldType { get; set; }
		//public string AnswerType { get; set; }

		//public string QFieldValue { get; set; }
		public string Desc { get; set; }
		public string RequiredAnswer { get; set; }
		/// <summary>
		/// fill, min, yn, mcq, num
		/// </summary>
		public string EvaluateCriteria { get; set; }
		/// <summary>
		/// R- Required | O - Optional
		/// </summary>
		public string EvaluateType { get; set; }

		[NotMapped]
		public List<ComboStr> FieldSrcDataList { get; set; } = new List<ComboStr>();

		public void UpdateList()
		{
			if (!string.IsNullOrWhiteSpace(FieldType) && FieldType.Compare("list"))
			{
				FieldSrcDataList.Clear();
				try
				{
					FieldSrcData.Split(",", StringSplitOptions.RemoveEmptyEntries)
						.Where(x=> !string.IsNullOrWhiteSpace(x)).ToList()
						.ForEach(x => FieldSrcDataList.Add(new ComboStr(x, x)));
				}
				catch { }
			}
		}
		public void UpdateFieldSrcData()
		{
			if (FieldSrcDataList != null && FieldSrcDataList.Count > 0)
			{
				try
				{
					FieldSrcData = string.Join(",", FieldSrcDataList.Select(x=> x.Value));
				}
				catch { }
			}
		}

	}
}
