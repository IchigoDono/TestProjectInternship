using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using TasksTracker.Constant;
using TasksTracker.Mapper;
using TasksTracker.Models;
using TasksTracker.ViewModels;

namespace TasksTracker.Services
{
    public class UserService : IUserService
    {
        private readonly TasksTrackerDBContext _applicationContext;
        public UserService(TasksTrackerDBContext applicationContext)
        {
            _applicationContext = applicationContext;
        }


        public ResultViewModel AccountRegistration(RegisterViewModel model)
        {
            ResultViewModel result = new ResultViewModel();

            bool existUser = _applicationContext.Users.Any(b => b.Email == model.Email);
            if (existUser == true)
            {
                result.ErrorMessage = "Eror! Login Exist";
                return result;
            }

            User user = new User()
            {
                Name = model.Name,
                LastName = model.LastName,
                Email = model.Email,
                Password = model.Password,
            };

            _applicationContext.Users.Add(user);
            int successfully = _applicationContext.SaveChanges();

            if (successfully == 0)
            {
                result.ErrorMessage = "Eror!";
                return result;
            }

            return GetToken(model.Email, model.Password);
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

        public List<UserViewModel> GetUsersList()
        {
            List<UserViewModel> users = _applicationContext.Users.Select(s => new UserViewModel() { Name = s.Name, Email = s.Email }).ToList();

            return users;
        }

        public UserViewModel GetUser(string email)
        {
            User user = _applicationContext.Users.FirstOrDefault(s => s.Email == email);
            UserViewModel userResult = UserMapper.UserViewModelMapper(user);
            return userResult;
        }

        ClaimsIdentity GetIdentity(string username, string password)
        {
            var user = _applicationContext.Users.Any(x => x.Email == username && x.Password == password);
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
