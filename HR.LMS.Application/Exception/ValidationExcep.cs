using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LMS.Application.Exception
{
    public class ValidationExcep : ApplicationException
    {
        public List<string> Errors { get; set; } = new List<string> ();

        public ValidationExcep(ValidationResult validationResult)
        {
           foreach(var err in validationResult.Errors)
            {
                Errors.Add(err.ErrorMessage);
            } 
        }
    }
}
