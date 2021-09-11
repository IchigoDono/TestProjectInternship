using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestProject.ViewModels;

namespace TestProject.Services
{
    public interface IUserService
    {
        ResultViewModel Accountregistration(RegisterViewModel model);
        ResultViewModel GetToken(string username, string password);
        List<UserViewModel> GetUserList();
    }
}
