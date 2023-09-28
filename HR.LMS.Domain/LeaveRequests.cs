using HR.LMS.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LMS.Domain
{
    public class LeaveRequests : BaseDomainEntity
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public LeaveTypes LeaveType { get; set; }
        public int LeaveTypeId { get; set; }
        public DateTime DateRequested { get; set; }
        public string RequestComments { get; set; }
        public DateTime? EffectiveDate { get; set; }
        public bool? Approved { get; set; }
        public bool Canceled { get; set; }
    }
}
