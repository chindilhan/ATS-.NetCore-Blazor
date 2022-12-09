using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stx.Shared.Models
{
	[Table("Currency")]
	public class Currency
	{
		[StringLength(3)]
		public string CurrCD { get; set; }
		[StringLength(50)]
		public string Name { get; set; }
		[StringLength(3)]
		public string CurrSymbol { get; set; }
		[StringLength(3)]
		public string CurrSymbolFrgn { get; set; }
		public short? Decimals { get; set; }
		public decimal? RoundSys { get; set; }
		[StringLength(50)]
		public string Denomination { get; set; }
		public bool? Active { get; set; }
		[Timestamp]
		public byte[] Tstamp { get; set; }
		[StringLength(30)]
		public string CreatedBy { get; set; }
		public DateTime CreatedOn { get; set; }
		[StringLength(30)]
		public string ModifiedBy { get; set; }
		public DateTime? ModifiedOn { get; set; }

	}
}
