using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LMS.Application.DTOs.LeaveType
{
    public interface ILeaveTypeDTO
    {
        public string Name { get; set; }
        public int DefaultHours { get; set; }
    }
}
