using System.Collections.Generic;
using TasksTracker.Models;
using TasksTracker.ViewModels;

namespace TasksTracker.Services
{
    public interface ITaskService
    {
        void CategoryCreate(CreateCategoryViewModel model, string email);
        void TaskCreate(CreateTaskViewModel model);
        void UpdateTask(UpdateTaskViewModel model);
        TaskViewModel GetUserTasks(int boardId);
        List<Category> GetCategories(string email);
    }
}
