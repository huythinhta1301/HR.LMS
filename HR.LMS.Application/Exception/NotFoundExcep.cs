using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LMS.Application.Exception
{
    public class NotFoundExcep : ApplicationException
    {
        public NotFoundExcep(string key,object value) : base($"{key} [{value}] is not found")
        {
            
        }
    }
}
