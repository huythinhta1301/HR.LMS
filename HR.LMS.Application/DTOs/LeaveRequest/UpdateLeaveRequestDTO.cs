using HR.LMS.Application.DTOs.Common;
using HR.LMS.Application.DTOs.LeaveType;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LMS.Application.DTOs.LeaveRequest
{
    public class UpdateLeaveRequestDTO : BaseDTO, ILeaveRequestDTO
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int LeaveTypeId { get; set; }
        public string RequestComments { get; set; }
        public bool Canceled { get; set; }
    }
}
