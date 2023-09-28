using HR.LMS.Application.Contracts.Irepo;
using HR.LMS.Domain;
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

        public Task<LeaveTypes> GetLeaveTypeWithDetail(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<LeaveTypes>> GetLeaveTypeWithDetail()
        {
            throw new NotImplementedException();
        }
    }
}
