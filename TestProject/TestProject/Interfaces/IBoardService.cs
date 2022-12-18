using System.Collections.Generic;
using TasksTracker.Models;
using TasksTracker.ViewModels;

namespace TasksTracker.Services
{
    public interface IBoardService
    {
        ResultBoardViewModel BoardCreate(CreateBoardViewModel model, string email);
        List<UserBoard> GetBoardList(string email);
    }
}
