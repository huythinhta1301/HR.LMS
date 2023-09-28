using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HR.LMS.Application.Persistence.Contracts
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetAsync (int id);
        Task<IReadOnlyList<T>> GetAllAsync ();
        Task<T> AddAsync (T item);
        Task<T> UpdateAsync (T item);
        Task<T> DeleteAsync (T item);
        Task<bool> Exists(int id);
    }
}
