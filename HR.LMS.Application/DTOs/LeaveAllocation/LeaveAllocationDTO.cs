using HR.LMS.Application.DTOs.Common;
using HR.LMS.Application.DTOs.LeaveType;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LMS.Application.DTOs.LeaveAllocation
{
    public class LeaveAllocationDTO : BaseDTO, ILeaveAllocationDTO
    {
        public int TotalHours { get; set; }
        public LeaveTypeDTO LeaveType { get; set; }
        public int LeaveTypeId { get; set; }
        public int Period { get; set; }
    }
}
