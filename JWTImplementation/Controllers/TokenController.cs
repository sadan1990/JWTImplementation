using JWTImplementation.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWTImplementation.Controllers
{
    public class TokenController : Controller
    {
        private readonly AuthService authService;
        public TokenController(AuthService authService)
        {
            this.authService = authService;
        }
        [HttpGet]
        [Route("api/token")]
        //http://localhost:2063/api/token
        public IActionResult GetToken()
        {
            return Ok(authService.GenerateSecurityToken());
        }

        [HttpPost]
        [Route("api/tokenparam")]
        public IActionResult GetTokenWithParams([FromBody]TokenParams tokenParams)
        {
            return Ok(tokenParams);
        }
    }
}
