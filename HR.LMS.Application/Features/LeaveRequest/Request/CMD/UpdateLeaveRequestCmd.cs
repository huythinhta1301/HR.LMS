using HR.LMS.Application.DTOs.LeaveRequest;
using HR.LMS.Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LMS.Application.Features.LeaveRequest.Request.CMD
{
    public class UpdateLeaveRequestCmd : IRequest<BaseResponse>
    {
        public int Id { get; set; }
        public UpdateLeaveRequestDTO UpdateLeaveRequestDTO { get; set; }

        public ChangeApprovalStatusDTO ChangeApprovalStatusDTO { get; set; }
    }
}
