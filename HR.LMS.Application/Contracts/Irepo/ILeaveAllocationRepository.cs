using HR.LMS.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HR.LMS.Application.Contracts.Irepo
{
    public interface ILeaveAllocationRepository : IGenericRepository<LeaveAllocations>
    {
        Task<LeaveAllocations> GetLeaveAllocationWithDetail(int id);
        Task<List<LeaveAllocations>> GetLeaveAllocationWithDetail();
    }
}
