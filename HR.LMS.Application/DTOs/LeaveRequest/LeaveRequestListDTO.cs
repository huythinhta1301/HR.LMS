using HR.LMS.Application.DTOs.Common;
using HR.LMS.Application.DTOs.LeaveType;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LMS.Application.DTOs.LeaveRequest
{
    public class LeaveRequestListDTO : BaseDTO
    {
        public LeaveTypeDTO LeaveType { get; set; }
        public DateTime DateRequested { get; set; }
        public bool? Approved { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
