using Microsoft.AspNetCore.Mvc;
using System;
using TasksTracker.Services;
using TasksTracker.ViewModels;

namespace TasksTracker.Controllers
{
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserService _userService;
        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        [Route("api/AccountRegistration")]
        [HttpPut]
        public IActionResult Registration(RegisterViewModel model)
        {
            try
            {
                ResultViewModel result = _userService.AccountRegistration(model);

                if (result.ErrorMessage != null)
                {
                    return BadRequest(result.ErrorMessage);
                }

                return Ok(result.Token);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Route("api/Authorization")]
        [HttpGet]
        public IActionResult Authorization(string username, string password)
        {
            try
            {
                ResultViewModel result = _userService.GetToken(username, password);

                if (result.ErrorMessage != null)
                {
                    return BadRequest(result.ErrorMessage);
                }

                return Ok(result.Token);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [Route("api/AccountInformation")]
        [HttpGet]
        public IActionResult GetInformation(string email)
        {
            try
            {
                UserViewModel result = _userService.GetUser(email);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
