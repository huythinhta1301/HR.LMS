using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LMS.Application.Exception
{
    public class BadRequestExcep : ApplicationException
    {
        public BadRequestExcep(string msg) : base(msg)
        {
            
        }
    }
}
