using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TasksTracker.Services;

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

        [Authorize]
        [Route("api/CreateTasks")]
        [HttpGet]
        public IActionResult CreateTasks(string login)
        {
            //var result = _taskService.GetUserList();
            //return Ok(result);
            return Ok();
        }
    }
}
