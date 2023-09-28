using HR.LMS.Application.Contracts.Irepo;
using HR.LMS.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HR.LMS.Persistence.Repo
{
    public class LeaveAllocationRepository : GenericRepository<LeaveAllocations>, ILeaveAllocationRepository
    {
        private readonly LeaveManagementDbContext _context;
        public LeaveAllocationRepository(LeaveManagementDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<LeaveAllocations> GetLeaveAllocationWithDetail(int id)
        {
            var leaveAllo = await _context.LeaveAllocations
                .Include(a => a.LeaveType)
                .FirstOrDefaultAsync(s => s.Id.Equals(id));
            return leaveAllo;
        }

        public async Task<List<LeaveAllocations>> GetLeaveAllocationWithDetail()
        {
            var listLeaveAllo = await _context.LeaveAllocations.Include(a => a.LeaveType)
                .ToListAsync();
            return listLeaveAllo;
        }
    }
}
