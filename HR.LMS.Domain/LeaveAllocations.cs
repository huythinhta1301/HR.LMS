using HR.LMS.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LMS.Domain
{
    public class LeaveAllocations : BaseDomainEntity
    {
        public int TotalHours { get; set; }
        public LeaveTypes LeaveType { get; set; }
        public int LeaveTypeId { get; set; }
        public int Period { get; set; }
    }
}
