using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stx.Shared.Models.Account
{
	[NotMapped]
    public class SigninUserClaim
	{
            [Required]
            public string UserName { get; set; }

            [Required]
            public string ClaimType { get; set; }

            [Required]
            public string ClaimValue { get; set; }

    }
}
