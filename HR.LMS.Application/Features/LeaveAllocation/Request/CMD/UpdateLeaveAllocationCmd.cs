using HR.LMS.Application.DTOs.LeaveAllocation;
using HR.LMS.Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LMS.Application.Features.LeaveAllocation.Request.CMD
{
    public class UpdateLeaveAllocationCmd : IRequest<BaseResponse>
    {
        public LeaveAllocationDTO leaveAllocationDTO { get; set; }
    }
}
