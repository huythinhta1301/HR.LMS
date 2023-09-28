using HR.LMS.Application.DTOs.LeaveType;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LMS.Application.DTOs.LeaveAllocation
{
    public interface ILeaveAllocationDTO
    {
        public int TotalHours { get; set; }
        public int LeaveTypeId { get; set; }
        public int Period { get; set; }
    }
}
