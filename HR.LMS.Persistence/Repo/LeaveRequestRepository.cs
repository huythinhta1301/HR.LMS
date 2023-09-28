using HR.LMS.Application.Contracts.Irepo;
using HR.LMS.Application.DTOs.LeaveRequest;
using HR.LMS.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LMS.Persistence.Repo
{
    public class LeaveRequestRepository : GenericRepository<LeaveRequests>, ILeaveRequestRepository
    {
        private readonly LeaveManagementDbContext _db;
        public LeaveRequestRepository(LeaveManagementDbContext db) : base(db)
        {
            _db = db;
        }
        public async Task<LeaveRequests> GetLeaveRequestWithDetail(int id)
        {
            var leaveRequest = await _db.LeaveRequests.Include(i => i.LeaveType).FirstOrDefaultAsync(a => a.Id == id);
            return leaveRequest;
        }

        public async Task<List<LeaveRequests>> GetLeaveRequestWithDetail()
        {
            var list = await _db.LeaveRequests.Include(a => a.LeaveType).ToListAsync();
            return list;
        }

        public async Task UpdateApprovedStatus(LeaveRequests leaveRequests, bool? Approved)
        {
            leaveRequests.Approved = Approved;
            _db.Entry(leaveRequests).State = EntityState.Modified;
            await _db.SaveChangesAsync();
        }
    }
}
