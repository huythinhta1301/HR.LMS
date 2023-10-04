using HR.LMS.Application.DTOs.LeaveRequest;
using HR.LMS.Application.Response;
using HR.LMS.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LMS.Application.Features.LeaveRequest.Request.CMD
{
    public class CreateLeaveRequestCmd : IRequest<BaseResponse>
    {
        public CreateLeaveRequestDTO CreateLeaveRequestDTO { get; set; }
    }
}
