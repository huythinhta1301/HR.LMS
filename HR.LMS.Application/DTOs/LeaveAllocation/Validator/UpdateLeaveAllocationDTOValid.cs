using FluentValidation;
using HR.LMS.Application.Contracts.Irepo;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LMS.Application.DTOs.LeaveAllocation.Validator
{
    public class UpdateLeaveAllocationDTOValid : AbstractValidator<ILeaveAllocationDTO>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        public UpdateLeaveAllocationDTOValid(ILeaveTypeRepository repo)
        {
            _leaveTypeRepository = repo;
            Include(new ILeaveAllocationDTOValid(_leaveTypeRepository));
        }
    }
}
