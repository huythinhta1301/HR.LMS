using HR.LMS.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LMS.Application.DTOs.LeaveType
{
    public class CreateLeaveTypeDTO :BaseDTO, ILeaveTypeDTO
    {
        public string Name { get; set; }
        public int DefaultHours { get; set; }
    }
}
