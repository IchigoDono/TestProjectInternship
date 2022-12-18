using TasksTracker.Models;
using TasksTracker.ViewModels;

namespace TasksTracker.Mapper
{
    public class UserMapper
    {
        public static UserViewModel UserViewModelMapper(User user)
        {
            UserViewModel userViewModel = new UserViewModel()
            {
                Email = user.Email,
                LastName = user.LastName,
                Name = user.Name
            };
            return userViewModel;
        }
    }
}

