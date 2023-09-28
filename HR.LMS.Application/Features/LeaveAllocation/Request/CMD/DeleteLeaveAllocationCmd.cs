using HR.LMS.Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LMS.Application.Features.LeaveAllocation.Request.CMD
{
    public class DeleteLeaveAllocationCmd : IRequest<BaseResponse>
    {
        public int Id { get; set; }
    }
}
