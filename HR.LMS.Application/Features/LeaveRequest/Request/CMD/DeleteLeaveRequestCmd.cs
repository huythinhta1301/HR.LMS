﻿using HR.LMS.Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LMS.Application.Features.LeaveRequest.Request.CMD
{
    public class DeleteLeaveRequestCmd : IRequest<BaseResponse>
    {
        public int Id { get; set; }
    }
}
