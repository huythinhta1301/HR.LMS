using HR.LMS.Application.Contracts.Irepo;
using HR.LMS.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HR.LMS.Persistence.Repo
{
    public class LeaveTypeRepository : GenericRepository<LeaveTypes>, ILeaveTypeRepository
    {
        private readonly LeaveManagementDbContext _db;
        public LeaveTypeRepository(LeaveManagementDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<LeaveTypes> GetLeaveTypeWithDetail(int id)
        {
            var leaveType = await _db.LeaveTypes.FirstOrDefaultAsync(i => i.Id == id);
            return leaveType;
        }

        public async Task<List<LeaveTypes>> GetLeaveTypeWithDetail()
        {
            var list = await _db.LeaveTypes.ToListAsync();
            return list;
        }
    }
}
