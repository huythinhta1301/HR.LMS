using HR.LMS.Application.DTOs.LeaveRequest;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LMS.Application.Features.LeaveRequest.Request.Queries
{
    public class GetLeaveRequestList : IRequest<List<LeaveRequestListDTO>>
    {
    }
}
