using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Security.Claims;
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

        [Route("api/CreateTask")]
        [HttpPost]
        public IActionResult CreateTask(CreateTaskViewModel createTaskModel)
        {
            try
            {
                _taskService.TaskCreate(createTaskModel);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("api/GetUserTasks")]
        [HttpPost]
        public IActionResult GetUserTasks(int boardId)
        {
            try
            {
                var tasks = _taskService.GetUserTasks(boardId);
                return Ok(tasks);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [Route("api/UpdateTask")]
        [HttpPost]
        public IActionResult UpdateTask(UpdateTaskViewModel updateTaskModel)
        {
            try
            {
                _taskService.UpdateTask(updateTaskModel);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [Route("api/CreateCategory")]
        [HttpPost]
        public IActionResult CreateCategory(CreateCategoryViewModel createCategoryModel)
        {
            string email = User.FindFirst(ClaimTypes.Email)?.Value;
            _taskService.CategoryCreate(createCategoryModel, email);
            return Ok(new { success = true });
        }

        [Route("api/GetCategories")]
        [HttpGet]
        public IActionResult GetCategories()
        {
            string email = User.FindFirst(ClaimTypes.Email)?.Value;

            var categories = _taskService.GetCategories(email);
            return Ok(categories.Select(s => new
            {
                Id = s.CategoryId,
                Name = s.Name
            }
            ).ToList());
        }
    }
}
