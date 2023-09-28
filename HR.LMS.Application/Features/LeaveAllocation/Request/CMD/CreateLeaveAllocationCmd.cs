using HR.LMS.Application.DTOs.LeaveAllocation;
using HR.LMS.Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LMS.Application.Features.LeaveAllocation.Request.CMD
{
    public class CreateLeaveAllocationCmd : IRequest<BaseResponse>
    {
        public CreateLeaveAllocationDTO createLeaveAllocationDTO { get; set; }
    }
}
