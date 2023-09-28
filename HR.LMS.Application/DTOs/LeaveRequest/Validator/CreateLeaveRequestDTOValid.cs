using FluentValidation;
using HR.LMS.Application.Contracts.Irepo;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LMS.Application.DTOs.LeaveRequest.Validator
{
    public class CreateLeaveRequestDTOValid : AbstractValidator<CreateLeaveRequestDTO>
    {
        private readonly ILeaveTypeRepository _repo;
        public CreateLeaveRequestDTOValid(ILeaveTypeRepository repo)
        {
            _repo = repo;
            Include(new ILeaveRequestDTOValid(_repo));
            //RuleFor(s => s.StartDate)
            //    .LessThan(s => s.EndDate).WithMessage("Start Date must before End Date");
            //RuleFor(s => s.EndDate)
            //    .GreaterThan(s => s.StartDate).WithMessage("End Date must after Start Date");
            //RuleFor(s => s.LeaveTypeId)
            //    .NotNull()
            //    .NotEmpty()
            //    .GreaterThan(0)
            //    .MustAsync(async (id, token) =>
            //    {
            //        var leaveType = await _repo.Exists(id);
            //        return !leaveType;
            //    }).WithMessage("ID not exists");
        }
    }
}
