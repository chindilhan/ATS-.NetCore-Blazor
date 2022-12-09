using System;
using System.Collections.Generic;
using System.Text;

namespace Stx.Shared.Models.DTO.HRM
{
    public class UserSignupDTO
    {
        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Password { get; set; }
    }
}
