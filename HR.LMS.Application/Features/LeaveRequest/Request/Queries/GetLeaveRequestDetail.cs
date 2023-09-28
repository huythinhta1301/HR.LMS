using HR.LMS.Application.DTOs.LeaveRequest;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LMS.Application.Features.LeaveRequest.Request.Queries
{
    public class GetLeaveRequestDetail : IRequest<LeaveRequestListDTO>
    {
        public int Id { get; set; }
    }
}
