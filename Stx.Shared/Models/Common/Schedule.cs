using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Stx.Shared.Models.Common
{
    [Table("Schedule")]
    public class Schedule
    {
		[Required(ErrorMessage = "Select an event type.")]
		public string EventType { get; set; }
		public DateTime DateFrom { get; set; }
		public string TimeZone { get; set; }
		public DateTime TimeFrom { get; set; }
		public DateTime TimeTo { get; set; }
		public int CandidateID { get; set; }
		public int EvaluatorID { get; set; }
		[Required(ErrorMessage = "At least one atendee is required.")]
		public string Atendee { get; set; }
		public string Location { get; set; }
		[Required(ErrorMessage ="Event title is required.")]
		public string Title { get; set; }
		[Required(ErrorMessage ="Event description is required.")]
		public string Desctiption { get; set; }

	}
}