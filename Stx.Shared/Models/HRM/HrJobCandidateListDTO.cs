using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stx.Shared.Models.HRM
{
	[NotMapped]
	public class HrJobCandidateListDTO
	{
		private bool _Selected = false;
		[NotMapped]
		public bool Selected
		{
			get { return _Selected; }
			set
			{
				_Selected = value;
				SelectionChanged(JobCandidateID);
			}
		}
		public int JobCandidateID { get; set; }
		public int JobOrderID { get; set; }
		public int? CandidateID { get; set; }
		public string CandidateName { get; set; }
		public DateTime DateAdded { get; set; }
		public string JobTitle { get; set; }
		public string Email { get; set; }
		public string Mobile { get; set; }
		public string Stage { get; set; }
		public string ProfileImgKey { get; set; }
		/// <summary>
		/// Non Mapped Dynamic Image Url field which uses to generated profile image Url. 
		/// </summary>
		[NotMapped]
		public string DynmcImageUrl { get; set; }

		protected void	SelectionChanged(int jobCandidateID)
        {

        }

	}
}
