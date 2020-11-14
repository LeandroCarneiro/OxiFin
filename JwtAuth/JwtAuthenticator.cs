using JwtAuth.Config;
using Microsoft.IdentityModel.Tokens;
using OxiFin.Common.Exceptions;
using OxiFin.ViewModels.AppObjects;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;

namespace JwtAuth
{
    public static class JwtAuthenticator
    {
        public static string GenerateToken(UserApp_vw user)
        {
            if (user == null)
                throw new InvalidLoginException();

            var handler = new JwtSecurityTokenHandler();

            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim("Id", user.Id.ToString()));
            claims.Add(new Claim("Email", user.Email));
            claims.Add(new Claim("Active", (user.Active).ToString()));
            claims.Add(new Claim(ClaimTypes.Role, user.Role));

            var securityToken = handler.CreateJwtSecurityToken(new SecurityTokenDescriptor
            {
                Issuer = JwtTokenDefinitions.Issuer,
                Audience = JwtTokenDefinitions.Audience,
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                NotBefore = DateTime.Now.AddDays(1),
                SigningCredentials = JwtTokenDefinitions.SigningCredentials,
                EncryptingCredentials = JwtTokenDefinitions.SigningCredentialsEncripted
            });

            var token = handler.WriteToken(securityToken);

            return token;
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
