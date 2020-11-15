using JwtAuth.Config;
using Microsoft.IdentityModel.Tokens;
using OxiFin.Common.Exceptions;
using OxiFin.ViewModels.AppObject;
using OxiFin.ViewModels.AppObjects;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace JwtAuth
{
    public static class JwtAuthenticator
    {
        public static TokenResult GenerateToken(UserLogged user, IList<string> roles)
        {
            if (user == null)
                throw new InvalidLoginException();

            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            };

            var roleClaims = roles.Select(r => new Claim(ClaimTypes.Role, r));
            claims.AddRange(roleClaims);

            var expires = DateTime.Now.AddDays(Convert.ToDouble(JwtTokenDefinitions.TokenExpirationTime));

            var handler = new JwtSecurityTokenHandler();

            var securityToken = handler.CreateJwtSecurityToken(new SecurityTokenDescriptor
            {
                Issuer = JwtTokenDefinitions.Issuer,
                Audience = JwtTokenDefinitions.Audience,
                Subject = new ClaimsIdentity(claims),
                Expires = expires,
                NotBefore = DateTime.Now,
                SigningCredentials = JwtTokenDefinitions.SigningCredentials,
                EncryptingCredentials = JwtTokenDefinitions.SigningCredentialsEncripted
            });

            return new TokenResult()
            {
                Value = handler.WriteToken(securityToken),
                User = user,
                Expires = expires
            };
        }

        public static UserApp_vw GetUser(string token)
        {
            token = token.Replace("Bearer ", "");
            if (string.IsNullOrEmpty(token))
                return null;

            var principal = GetPrincipal(token);

            return new UserApp_vw()
            {
                Id = Convert.ToInt64(ExtractClaimValueFromPrinciple(principal, "Id")),
                Email = ExtractClaimValueFromPrinciple(principal, "Email"),
                Role = ExtractClaimValueFromPrinciple(principal, "Role"),
                UserName = ExtractClaimValueFromPrinciple(principal, "UserName"),
                Active = Convert.ToBoolean(ExtractClaimValueFromPrinciple(principal, "Active"))
            };
        }

        private static string ExtractClaimValueFromPrinciple(ClaimsPrincipal claimsPrinciple, string type)
        {
            try
            {
                var a = claimsPrinciple.Claims.Where(c => c.Type == type);

                return a.Select(c => c.Value).FirstOrDefault().ToString();
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }

        private static ClaimsPrincipal GetPrincipal(string token)
        {
            try
            {
                JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
                JwtSecurityToken jwtToken = tokenHandler.ReadToken(token) as JwtSecurityToken;

                if (jwtToken == null)
                    return null;

                SecurityToken securityToken;
                ClaimsPrincipal principal = tokenHandler.ValidateToken(token, JwtTokenDefinitions.TokenValidationParameters, out securityToken);

                return principal;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
