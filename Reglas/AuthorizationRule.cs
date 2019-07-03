using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using DTOs;
using ServiciosRepositorio;
using Reglas.Common;
using Microsoft.Extensions.Configuration;

namespace Reglas
{
    public class AuthorizationRule : IAuthorizationRule
    {
        private readonly IAutorizationService _autorizationService;
        private readonly IConfiguration _configuration;
        #region Constructor
        public AuthorizationRule(IAutorizationService _autorizationService, IConfiguration _configuration)
        {
            this._autorizationService = _autorizationService;
            this._configuration = _configuration;
        }
        #endregion

        #region Public Methods
        public AuthorizationDto Auth(LoginDto dto)
        {
            AuthorizationDto auth = _autorizationService.Autentication(dto);
            if (auth == null)
            {
                throw new CustomException("login.invalidLogin");
            }
            var expiration = DateTime.UtcNow;

            var claimsData = new[] {
                    new Claim("Username", auth.Username),
                };

            var token = BuildToken(claimsData, Convert.ToInt32(_configuration["experiration"]));
            auth.RoleId = auth.UserId = 0;
            auth.Token = token;
            auth.Expiration = expiration;

            return auth;
        }
        #endregion

        #region Private Methods
        private string BuildToken(Claim[] claims, int expiredMiunutes)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var expiration = DateTime.UtcNow;
            var key = Encoding.ASCII.GetBytes(_configuration["key"]);

            var token = new JwtSecurityToken(
                null,
                null,
                claims,
                expiration,
                expiration.AddMinutes(expiredMiunutes),
                new SigningCredentials(new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature
                ));

            return tokenHandler.WriteToken(token);
        }
        #endregion
    }
}
