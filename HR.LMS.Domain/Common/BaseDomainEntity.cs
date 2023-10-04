using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LMS.Domain.Common
{
    public abstract class BaseDomainEntity
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime DateModified { get; set; }
        public string? UpdatedBy { get; set; }
    }
}
