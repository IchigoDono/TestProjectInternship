using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TestProject.Services;
using TestProject.ViewModels;

namespace TestProject.Controllers
{
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserService _userService;
        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        [Route("api/Registration")]
        [HttpPut] 
        public IActionResult Registration(RegisterViewModel model)
        {
            ResultViewModel result = _userService.Accountregistration(model);

            if (result.ErrorMessage != null) 
            {
                return BadRequest(result.ErrorMessage);
            }

            return Ok(result.Token);
        }

        [Route("api/Authorization")]
        [HttpGet]
        public IActionResult Authorization(string username, string password)
        {
            ResultViewModel result = _userService.GetToken(username, password);

            if (result.ErrorMessage != null)
            {
                return BadRequest(result.ErrorMessage);
            }

            return Ok(result.Token);
        }
        
    }
}
