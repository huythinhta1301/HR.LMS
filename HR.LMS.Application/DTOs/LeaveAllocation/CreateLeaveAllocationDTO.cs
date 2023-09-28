using HR.LMS.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LMS.Application.DTOs.LeaveAllocation
{
    public class CreateLeaveAllocationDTO : BaseDTO, ILeaveAllocationDTO
    {
        public int TotalHours { get; set; }
        public int LeaveTypeId { get; set; }
        public int Period { get; set; }
    }
}
