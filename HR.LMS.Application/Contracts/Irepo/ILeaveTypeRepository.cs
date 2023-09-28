using HR.LMS.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HR.LMS.Application.Contracts.Irepo
{
    public interface ILeaveTypeRepository : IGenericRepository<LeaveTypes>
    {
        Task<LeaveTypes> GetLeaveTypeWithDetail(int id);
        Task<List<LeaveTypes>> GetLeaveTypeWithDetail();
    }
}
