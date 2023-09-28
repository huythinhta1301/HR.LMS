using FluentValidation;
using HR.LMS.Application.Contracts.Irepo;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LMS.Application.DTOs.LeaveRequest.Validator
{
    public class UpdateLeaveRequestDTOValid : AbstractValidator<UpdateLeaveRequestDTO>
    {
        private readonly ILeaveTypeRepository _repo;
        public UpdateLeaveRequestDTOValid(ILeaveTypeRepository repo)
        {
            _repo = repo;
            Include(new ILeaveRequestDTOValid(_repo));
            RuleFor(p => p.Id).NotNull().NotEmpty().WithMessage("{PropertyName} must be present");
        }
    }
}
