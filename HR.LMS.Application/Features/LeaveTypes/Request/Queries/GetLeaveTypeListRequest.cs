using HR.LMS.Application.DTOs.LeaveType;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LMS.Application.Features.LeaveTypes.Request.Queries
{
    public class GetLeaveTypeListRequest : IRequest<List<LeaveTypeDTO>>
    {

    }
}
