using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetUsers()
        {
            UserViewModel user = new UserViewModel()
            {
            };
            return Ok(user);
        }
    }
    public class UserViewModel
    {
        public String Name { get; set; }
    }
}
