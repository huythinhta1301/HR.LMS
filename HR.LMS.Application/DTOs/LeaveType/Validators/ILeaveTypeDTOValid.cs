using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LMS.Application.DTOs.LeaveType.Validators
{
    public class ILeaveTypeDTOValid : AbstractValidator<ILeaveTypeDTO>
    {
        public ILeaveTypeDTOValid()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Please input {PropertyName}.")
                .NotNull()
                .MaximumLength(50).WithMessage("Name is too long (<= 50 characters)")
                .MinimumLength(3).WithMessage("Name is too short (>= 3 characters)");

            RuleFor(p => p.DefaultHours)
                .NotEmpty().WithMessage("Please input {PropertyName}.")
                .GreaterThan(0).WithMessage("Greater than 0")
                .LessThan(50).WithMessage("Less than 50");
        }
    }
}
