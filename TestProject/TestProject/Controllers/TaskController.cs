using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TasksTracker.Services;
using TasksTracker.ViewModels;

namespace TasksTracker.Controllers
{
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;
        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        //[Authorize]
        [Route("api/CreateTask")]
        [HttpPost]
        public IActionResult CreateTask(CreateTaskViewModel createTaskModel)
        {
            _taskService.TaskCreate(createTaskModel);
            return Ok();
        }

        [Authorize]
        [Route("api/UpdateTask")]
        [HttpPost]
        public IActionResult UpdateTask(UpdateTaskViewModel updateTaskModel)
        {
            _taskService.UpdateTask(updateTaskModel);
            return Ok();
        }

        [Authorize]
        [Route("api/CreateCategory")]
        [HttpPost]
        public IActionResult CreateCategory(CreateCategoryViewModel createCategoryModel)
        {
            _taskService.CategoryCreate(createCategoryModel);
            return Ok();
        }
    }
}
