using Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using OxiFin.Application.Interfaces;
using OxiFin.Common.InternalObjects;
using OxiFin.DI;
using OxiFin.Domain.Entities.Auth;
using OxiFin.ViewModels.AppObject;
using OxiFin.ViewModels.AppObjects;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace OxiFin.Application.AppServices
{
    public class UserAppService : BaseAppService<UserApp_vw, UserApp>
    {
        readonly IUserBusiness _business;
        private readonly UserManager<UserApp> _userManager;
        private readonly JwtSettings _jwtSettings;

        public UserAppService(IUserBusiness business, IOptionsSnapshot<JwtSettings> jwtSettings) : base(business)
        {
            _userManager = AppContainer.Resolve<UserManager<UserApp>>();
            _business = business;
            _jwtSettings = jwtSettings.Value;
        }

        public async Task DesativateAsync(long userId)
        {
            await _business.DesativeAsync(userId);
        }

        public async Task<AppResult> SignIn(Login_vw request)
        {
            var user = await _userManager.Users.SingleOrDefaultAsync(u => u.UserName == request.UserName);
            if (user is null)            
                return new AppResult("User not found");
            
            var userSigninResult = await _userManager.CheckPasswordAsync(user, request.Password);

            if (userSigninResult)
            {
                var vw = Resolve<UserApp, UserLogged>(user);
                var resut = GenerateJwt(vw, new List<string>() { "ADMINISTRATOR" });

                return new AppResult(resut);
            }

            return new AppResult("Wrong Password");
        }

        public async Task<AppResult> SignUp(UserApp_vw request)
        {
            var user = Resolve(request);
            var result = await _userManager.CreateAsync(user, request.Password);

            if (result.Succeeded)
                return new AppResult(result);

            return new AppResult(result.ToString());
        }

        private TokenResult GenerateJwt(UserLogged user, IList<string> roles)
        {
            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            };

            var roleClaims = roles.Select(r => new Claim(ClaimTypes.Role, r));
            claims.AddRange(roleClaims);

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(Convert.ToDouble(_jwtSettings.ExpirationInDays));

            var token = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Issuer,
                claims,
                expires: expires,
                signingCredentials: creds
            );

            return new TokenResult()
            {
                Value = new JwtSecurityTokenHandler().WriteToken(token),
                User = user,
                Expires = expires
            };
        }
    }
}
