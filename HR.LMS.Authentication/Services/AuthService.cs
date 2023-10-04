using HR.LMS.Application.Contracts.Identity;
using HR.LMS.Application.Models.Identity;
using HR.LMS.Authentication.Models;
using HR.LMS.Helper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace HR.LMS.Authentication.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<User> _user;
        private readonly JwtSettings _jwtSettings;
        private readonly SignInManager<User> _signIN;
        public AuthService(UserManager<User> user, IOptions<JwtSettings> jwtSetting, SignInManager<User> signIn)
        {
            _jwtSettings = jwtSetting.Value;
            _signIN= signIn;
            _user = user;

        }
        public async Task<AuthenticationResponse> Login(AuthencationRequest login)
        {
            var user = await _user.FindByEmailAsync(login.Email);

            if(user == null) throw new Exception();

            var loginRes = await _signIN.PasswordSignInAsync(user.UserName, login.Password,false,false);

            if(!loginRes.Succeeded) throw new Exception("");
   
            JwtSecurityToken jwtSecurityToken = await GenerateToken(user);

            AuthenticationResponse response = new AuthenticationResponse
            {
                Id = user.Id,
                Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                Email = user.Email,
                UserName = user.UserName
            };
            return response;
        }

        public async Task<RegistrationResponse> Register(RegistrationRequest register)
        {
            var FindEmail = await _user.FindByEmailAsync(register.Email);
            if(FindEmail != null) throw new Exception("Email Exist");

            var FindUsername = await _user.FindByNameAsync(register.Username);
            if( FindUsername != null) throw new Exception("Username Exist");

            var regisAccount = new User
            {
                Email = register.Email,
                UserName = register.Username,
                FirstName = register.FirstName,
                LastName = register.LastName,
            };

            var result = await _user.CreateAsync(regisAccount);
            if (result.Succeeded)
            {
                await _user.AddToRoleAsync(regisAccount, nameof(Role.EMPLOYEE));
                return new RegistrationResponse() { Id = regisAccount.Id };
            }
            else
            {
                throw new Exception("FAIL TO CREATE ACCOUNT");
            }

        }
        private async Task<JwtSecurityToken> GenerateToken(User user)
        {
            var userClaims = await _user.GetClaimsAsync(user);
            var roles = await _user.GetRolesAsync(user);

            var roleClaims = new List<Claim>();

            for (int i = 0; i < roles.Count; i++)
            {
                roleClaims.Add(new Claim(ClaimTypes.Role, roles[i]));
            }

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("Uid", user.Id)
            }
            .Union(userClaims)
            .Union(roleClaims);

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_jwtSettings.DurationInMinutes),
                signingCredentials: signingCredentials);
            return jwtSecurityToken;
        }
    }
}
