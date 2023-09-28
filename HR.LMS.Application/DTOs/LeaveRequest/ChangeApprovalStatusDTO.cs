using HR.LMS.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LMS.Application.DTOs.LeaveRequest
{
    public class ChangeApprovalStatusDTO : BaseDTO
    {
        public bool? Approved { get; set; }
    }
}
