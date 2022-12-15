using System.Collections.Generic;
using TasksTracker.ViewModels;

namespace TasksTracker.Services
{
    public interface IBoardService
    {
        ResultBoardViewModel BoardCreate(CreateBoardViewModel model);
        List<ResultBoardViewModel> GetBoardList(string email);
    }
}
