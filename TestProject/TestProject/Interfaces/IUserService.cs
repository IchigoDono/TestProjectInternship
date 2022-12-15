using System.Collections.Generic;
using TasksTracker.ViewModels;

namespace TasksTracker.Services
{
    public interface IUserService
    {
        ResultViewModel AccountRegistration(RegisterViewModel model);
        ResultViewModel GetToken(string username, string password);
        List<UserViewModel> GetUsersList();
        UserViewModel GetUser(string email);
    }
}
