using FluentValidation;
using HR.LMS.Application.Contracts.Irepo;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LMS.Application.DTOs.LeaveAllocation.Validator
{
    public class ILeaveAllocationDTOValid : AbstractValidator<ILeaveAllocationDTO>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        public ILeaveAllocationDTOValid(ILeaveTypeRepository repo)
        {
            _leaveTypeRepository = repo;
        }
    }
}
