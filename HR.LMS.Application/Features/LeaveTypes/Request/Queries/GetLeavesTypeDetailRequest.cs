using HR.LMS.Application.DTOs.LeaveType;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LMS.Application.Features.LeaveTypes.Request.Queries
{
    public class GetLeavesTypeDetailRequest : IRequest<LeaveTypeDTO>
    {
        public int Id { get; set; }
    }
}
