using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HR.LMS.Application.Contracts.Irepo
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetAsync(int id);
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<T> AddAsync(T item);
        Task UpdateAsync(T item);
        Task DeleteAsync(T item);
        Task<bool> Exists(int id);
    }
}
