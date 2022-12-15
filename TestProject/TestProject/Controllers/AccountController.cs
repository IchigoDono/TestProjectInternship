using Microsoft.AspNetCore.Mvc;
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
            ResultViewModel result = _userService.AccountRegistration(model);

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


        [Route("api/AccountInformation")]
        [HttpGet]
        public IActionResult GetInformation(string email)
        {
            UserViewModel result = _userService.GetUser(email);

            return Ok();
        }
    }
}
