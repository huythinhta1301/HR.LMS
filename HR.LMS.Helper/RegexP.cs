using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LMS.Helper
{
    public class RegexP
    {
        public const string UsernamePattern = @"^[a-zA-Z0-9]+$";
        public const string EmailPattern = @"^[a-zA-Z0-9]+@[a-zA-Z0-9]+\.[a-zA-Z]+$";
        public const string PhonePattern = @"^\d{10}$";
    }
}
