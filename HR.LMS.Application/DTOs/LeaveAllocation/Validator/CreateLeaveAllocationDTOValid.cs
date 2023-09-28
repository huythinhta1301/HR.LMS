using FluentValidation;
using HR.LMS.Application.Contracts.Irepo;
using HR.LMS.Application.DTOs.LeaveAllocation.Validator;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LMS.Application.DTOs.LeaveAllocation.Validator
{
    public class CreateLeaveAllocationDTOValid : AbstractValidator<CreateLeaveAllocationDTO>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        public CreateLeaveAllocationDTOValid(ILeaveTypeRepository repo)
        {
            _leaveTypeRepository = repo;
            Include(new ILeaveAllocationDTOValid(_leaveTypeRepository));
        }
    }
}
