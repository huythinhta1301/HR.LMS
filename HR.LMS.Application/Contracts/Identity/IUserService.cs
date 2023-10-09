using HR.LMS.Application.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LMS.Application.Contracts.Identity
{
    public interface IUserService
    {
        Task<List<UserInfo>> GetListUser();
        Task<UserInfo> GetUserById(string userId);
    }
}
