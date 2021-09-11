using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TestProject.ViewModels;

namespace TestProject.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationContext _applicationContext;
        public UserService(ApplicationContext applicationContext) 
        {
            _applicationContext = applicationContext;
        }


        public ResultViewModel Accountregistration(RegisterViewModel model) 
        {
            ResultViewModel result = new ResultViewModel();

            bool existUser = _applicationContext.Users.Any(b => b.Login == model.Login);
            if (existUser == true)
            {
                result.ErrorMessage ="Eror! Login Exist";
                return result;
            }

            User user = new User()
            {
                Name = model.Name,
                Login = model.Login,
                Password = model.Password
            };

            _applicationContext.Users.Add(user);
            int successfully = _applicationContext.SaveChanges();

            if (successfully == 0)
            {
                result.ErrorMessage = "Eror!";
                return result;
            }

            return GetToken(model.Login, model.Password);
        }



        public ResultViewModel GetToken(string username, string password)
        {
            ResultViewModel result = new ResultViewModel();
            ClaimsIdentity identity = GetIdentity(username, password);
            if (identity == null)
            {
                result.ErrorMessage = "Invalid username or password.";
                return result;
            }

            DateTime now = DateTime.UtcNow;

            JwtSecurityToken jwt = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
                    notBefore: now,
                    claims: identity.Claims,
                    expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            result.Token = new JwtSecurityTokenHandler().WriteToken(jwt);

            return result;
        }

        public List<UserViewModel> GetUserList() 
        {
            List<UserViewModel> users = _applicationContext.Users.Select(s => new UserViewModel() { Name = s.Name, Login = s.Login }).ToList();

            return users;
        }

        ClaimsIdentity GetIdentity(string username, string password)
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
    }
}
