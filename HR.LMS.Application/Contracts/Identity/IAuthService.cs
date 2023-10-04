using HR.LMS.Application.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LMS.Application.Contracts.Identity
{
    public interface IAuthService
    {
        Task<AuthenticationResponse> Login(AuthencationRequest login);

        Task<RegistrationResponse> Register(RegistrationRequest register);
    }
}
