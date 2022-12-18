using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
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

        [Route("api/CreateTask")]
        [HttpPost]
        public IActionResult GetUserTasks(int boardId)
        {
            try
            {
                _taskService.GetUserTasks(boardId);
                return Ok();
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
            try
            {
                _taskService.CategoryCreate(createCategoryModel);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
