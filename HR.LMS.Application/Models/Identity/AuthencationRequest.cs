using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LMS.Application.Models.Identity
{
    public class AuthencationRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
