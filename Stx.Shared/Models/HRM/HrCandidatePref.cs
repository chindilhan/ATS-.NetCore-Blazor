using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stx.Shared.Models.HRM
{
	[NotMapped]
	public class HrCandidatePref
	{
		public int CandidateID { get; set; }
		public DateTime? DateAvailable { get; set; }
		public DateTime? DateLastModified { get; set; }
		public DateTime? DateNextCall { get; set; }
		public int? TimeZoneOffsetEST { get; set; }
		public string PreferredContactModes { get; set; }
		public string JobSearchingMode { get; set; }
		public bool? IsMassMailOptOut { get; set; }
		public bool? IsSmsOptIn { get; set; }
		public bool? IsWhatsappOptIn { get; set; }
		public bool? IsMessengerOptIn { get; set; }
		public bool? IsExempt { get; set; }
	}
}
