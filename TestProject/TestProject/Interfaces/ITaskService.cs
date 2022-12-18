using TasksTracker.ViewModels;

namespace TasksTracker.Services
{
    public interface ITaskService
    {
        void CategoryCreate(CreateCategoryViewModel model);
        void TaskCreate(CreateTaskViewModel model);
        void UpdateTask(UpdateTaskViewModel model);
    }
}
