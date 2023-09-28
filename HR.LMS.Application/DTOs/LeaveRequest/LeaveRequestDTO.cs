using HR.LMS.Application.DTOs.LeaveType;
using HR.LMS.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using HR.LMS.Application.DTOs.Common;

namespace HR.LMS.Application.DTOs.LeaveRequest
{
    public class LeaveRequestDTO : BaseDTO, ILeaveRequestDTO
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public LeaveTypeDTO LeaveType { get; set; }
        public int LeaveTypeId { get; set; }
        public DateTime DateRequested { get; set; }
        public string RequestComments { get; set; }
        public DateTime? EffectiveDate { get; set; }
        public bool? Approved { get; set; }
        public bool Canceled { get; set; }
    }
}
