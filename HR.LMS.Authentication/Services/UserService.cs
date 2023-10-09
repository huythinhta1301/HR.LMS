using HR.LMS.Application.Contracts.Identity;
using HR.LMS.Application.Models.Identity;
using HR.LMS.Authentication.Models;
using HR.LMS.Helper;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LMS.Authentication.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _user;
        public UserService(UserManager<User> user)
        {
           _user = user;
        }
        public async Task<List<UserInfo>> GetListUser()
        {
            var listUser = await _user.GetUsersInRoleAsync(Role.EMPLOYEE);
            return listUser.Select(q => new UserInfo
            {
                Id = q.Id,
                Email = q.Email,
                Firstname = q.FirstName,
                Lastname = q.LastName,
            }).ToList();
        }

        public async Task<UserInfo> GetUserById(string userId)
        {
            var user = await _user.FindByIdAsync(userId);
            return new UserInfo
            {
                Id = user.Id,
                Email = user.Email,
                Firstname = user.FirstName,
                Lastname = user.LastName,
            };
        }
    }
}
