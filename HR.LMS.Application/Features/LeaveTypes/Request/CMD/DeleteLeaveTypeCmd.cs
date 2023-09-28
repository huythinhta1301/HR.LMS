using HR.LMS.Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LMS.Application.Features.LeaveTypes.Request.CMD
{
    public class DeleteLeaveTypeCmd : IRequest<BaseResponse>
    {
        public int Id { get; set; }
    }
}
