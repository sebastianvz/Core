using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Reglas;
using Reglas.Common;

namespace APICore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizationController : ControllerBase
    {
        private readonly IAuthorizationRule _Authorizationrule;

        public AuthorizationController(IAuthorizationRule _Authorizationrule)
        {
            this._Authorizationrule = _Authorizationrule;
        }



        // POST: api/User
        [HttpPost("Authenticate")]
        public IActionResult Authenticate([FromBody] LoginDto login)
        {
            try
            {
                var auth = _Authorizationrule.Auth(login);
                return Ok(auth);
            }
            catch (CustomException ex)
            {
                return GenerateException((int)HttpStatusCode.Conflict, ex.Message);
            }
            catch (Exception ex)
            {
                return GenerateException((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        IActionResult GenerateException(int errorCode, string message)
        {
            return StatusCode(errorCode, new { message });
        }

    }
}
