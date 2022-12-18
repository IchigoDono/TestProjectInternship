using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using TasksTracker.Enums;
using TasksTracker.Helper;
using TasksTracker.Models;
using TasksTracker.ViewModels;

namespace TasksTracker.Services
{
    public class TaskService : ITaskService
    {
        private readonly TasksTrackerDBContext _applicationContext;
        public TaskService(TasksTrackerDBContext applicationContext)
        {
            _applicationContext = applicationContext;
        }
        public void TaskCreate(CreateTaskViewModel model)
        {
            Task task = new Task()
            {
                Name = model.Name,
                BoardId = model.BoardId,
                CreationDate = DateTime.Now,
                Status = model.Status,
                LastUpdate = DateTime.Now,
                CategoryId = model.CategoryId
            };

            _applicationContext.Tasks.Add(task);
            _applicationContext.SaveChanges();
        }

        public TaskViewModel GetUserTasks(int boardId)
        {
            var task = _applicationContext.Tasks
                            .Where(s => s.BoardId == boardId).ToList();
            return TaskMapper.TasksMapper(task);
        }
            public void UpdateTask(UpdateTaskViewModel model)
        {
            Task task = _applicationContext.Tasks.FirstOrDefault(s => s.TaskId == model.TaskId);
            task.LastUpdate = DateTime.Now;
            task.Name = model.Name;
            task.CategoryId = model.CategoryId;
            task.Status = model.Status;
            _applicationContext.Update(task);
        }
        public void CategoryCreate(CreateCategoryViewModel model)
        {
            Category category = new Category()
            {
                Name = model.Name,
                UserId = model.UserId
            };

            _applicationContext.Categories.Add(category);
            _applicationContext.SaveChanges();
        }

        }
    }

