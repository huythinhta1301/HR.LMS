using HR.LMS.Application.DTOs.LeaveType;
using HR.LMS.Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LMS.Application.Features.LeaveTypes.Request.CMD
{
    public class UpdateLeaveTypeCmd : IRequest<BaseResponse>
    {
        public LeaveTypeDTO LeaveTypeDTO { get; set; }
    }
}
