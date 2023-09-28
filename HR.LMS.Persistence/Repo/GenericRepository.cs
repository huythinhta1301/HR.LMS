using HR.LMS.Application.Contracts.Irepo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HR.LMS.Persistence.Repo
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly LeaveManagementDbContext _db; 
        public GenericRepository(LeaveManagementDbContext db)
        {

            _db = db;
        }

        public async Task<T> AddAsync(T item)
        {
            await _db.AddAsync(item);
            await _db.SaveChangesAsync();
            return item;
        }

        public async Task DeleteAsync(T item)
        {
            _db.Set<T>().Remove(item);
            await _db.SaveChangesAsync();
        }

        public async Task<bool> Exists(int id)
        {
            var item = await GetAsync(id);
            return item != null;
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _db.Set<T>().ToListAsync();
        }

        public async Task<T> GetAsync(int id)
        {
            return await _db.Set<T>().FindAsync(id);
        }

        public async Task UpdateAsync(T item)
        {
            _db.Entry(item).State = EntityState.Modified;
            await _db.SaveChangesAsync();
        }
    }
}
