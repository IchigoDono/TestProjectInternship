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
using TestProject.ViewModels;

namespace TestProject.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class Account : ControllerBase
    {
        private readonly ApplicationContext _applicationContext;
        public Account(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }
        [Route("api/Registration")]
        [HttpPut] 
        public IActionResult Accountregistration(RegisterViewModel model)
        {
            var ExistUser = _applicationContext.Users.Any(b => b.Login == model.Login);
            if (ExistUser == true) 
            {
                return Ok("Eror! Login Exist");
            }

            User user = new User()
            {
                Name = model.Name,
                Login = model.Login,
                Password = model.Password
            };

            _applicationContext.Users.Add(user);
            int result = _applicationContext.SaveChanges();


            return _Token(model.Login, model.Password);
        }
        [Route("api/Authorization")]
        [HttpGet]
        public IActionResult Token(string username, string password)
        {
            return _Token(username, password);
        }
        
        private IActionResult _Token(string username, string password)
        {
            var identity = GetIdentity(username, password);
            if (identity == null)
            {
                return BadRequest(new { errorText = "Invalid username or password." });
            }

            var now = DateTime.UtcNow;

            var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
                    notBefore: now,
                    claims: identity.Claims,
                    expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            var response = new
            {
                access_token = encodedJwt
            };

            return Ok(encodedJwt);
        }

        private ClaimsIdentity GetIdentity(string username, string password)
        {
            var user = _applicationContext.Users.Any(x => x.Login == username && x.Password == password);
            if (user == true)
            {
                ClaimsIdentity claimsIdentity =
                new ClaimsIdentity(username, "Token", ClaimsIdentity.DefaultNameClaimType);
                return claimsIdentity;  
            }   

            return null;
        }

        [Authorize]
        [Route("api/UsersList")]
        [HttpGet]
        public IActionResult ListUsers()
        {
            var users = _applicationContext.Users.Select(s => new UserViewModel1(){ Name = s.Name, Login = s.Login });
            return Ok(users);
        }
        //[Authorize]
        //public IActionResult UserWrite()
        //{
        //    UserViewModel1 user = new UserViewModel1()
        //    {
        //        Name = "Artem"
        //    };  
        //    return Ok(user);
        //}
    }
    public class UserViewModel1
    {
        public string Name { get; set; }
        public string Login { get; set; }

    }
}
