using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LMS.Application.DTOs.LeaveType.Validators
{
    public class CreateLeaveTypeDTOValid : AbstractValidator<CreateLeaveTypeDTO>
    {
        public CreateLeaveTypeDTOValid()
        {
            Include(new ILeaveTypeDTOValid());
        }
    }
}
