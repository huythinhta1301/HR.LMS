using HR.LMS.Application.DTOs.LeaveAllocation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LMS.Application.Features.LeaveAllocation.Request.Queries
{
    public class GetLeaveAllocationDetail : IRequest<LeaveAllocationDTO>
    {
        public int Id { get; set; }
    }
}
