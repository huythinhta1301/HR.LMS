using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LMS.Application.DTOs.LeaveType.Validators
{
    public class UpdateLeaveTypeDTOValid : AbstractValidator<LeaveTypeDTO>
    {
        public UpdateLeaveTypeDTOValid()
        {
            Include(new ILeaveTypeDTOValid());
            RuleFor(p => p.Id).NotEmpty().WithMessage("{PropertyName} must be present");
        }
    }
}
