using HR.LMS.Application.DTOs.LeaveRequest;
using HR.LMS.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HR.LMS.Application.Contracts.Irepo
{
    public interface ILeaveRequestRepository : IGenericRepository<LeaveRequests>
    {
        Task<LeaveRequests> GetLeaveRequestWithDetail(int id);
        Task<List<LeaveRequests>> GetLeaveRequestWithDetail();
        Task UpdateApprovedStatus(LeaveRequests leaveRequests, bool? Approved);
    }
}
