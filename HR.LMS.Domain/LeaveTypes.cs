using HR.LMS.Domain.Common;
using System;

namespace HR.LMS.Domain
{
    public class LeaveTypes : BaseDomainEntity
    {
        public string Name { get; set; }
        public int DefaultHours { get; set; }
    }
}
