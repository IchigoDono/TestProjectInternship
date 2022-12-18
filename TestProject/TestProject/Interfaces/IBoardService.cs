using System.Collections.Generic;
using TasksTracker.Models;
using TasksTracker.ViewModels;

namespace TasksTracker.Services
{
    public interface IBoardService
    {
        ResultBoardViewModel BoardCreate(CreateBoardViewModel model);
        List<UserBoard> GetBoardList(string email);
    }
}
