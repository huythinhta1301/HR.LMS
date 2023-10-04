using FluentValidation;
using HR.LMS.Application.Contracts.Irepo;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LMS.Application.DTOs.LeaveRequest.Validator
{
    public class ILeaveRequestDTOValid : AbstractValidator<ILeaveRequestDTO>
    {
        private readonly ILeaveTypeRepository _repo;
        public ILeaveRequestDTOValid(ILeaveTypeRepository repo)
        {
            _repo = repo;

            RuleFor(p => p.StartDate)
                .LessThan(p => p.EndDate).WithMessage("{PropertyName} must before {ComparisonValue}");
            RuleFor(p => p.EndDate)
                .GreaterThan(p => p.StartDate).WithMessage("{PropertyName} must after {ComparisonValue}");
            RuleFor(p => p.LeaveTypeId)
                .GreaterThan(0)
                .MustAsync(async (id, token) =>
                {
                    var leaveType = await _repo.Exists(id);
                    return leaveType;
                }).WithMessage("{PropertyName} does not exist.");
        }
    }
}
