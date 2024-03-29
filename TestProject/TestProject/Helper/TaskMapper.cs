﻿using System;
using System.Collections.Generic;
using System.Linq;
using TasksTracker.Enums;
using TasksTracker.Models;
using TasksTracker.ViewModels;

namespace TasksTracker.Helper
{
    public class TaskMapper
    {
        public static TaskViewModel TasksMapper(List<Task> task)
        {
            TaskViewModel taskView = new TaskViewModel()
            {
                CreatedList = task.Where(s => s.Status == (int)TaskStatus.Created).Select(s => new TaskItemViewModel
                {
                    TaskId = s.TaskId,
                    Name = s.Name,
                    Status = s.Status,
                    BoardId = s.BoardId,
                    CategoryId = s.CategoryId,
                    CreationDate = s.CreationDate,
                    LastUpdate = s.LastUpdate
                }).ToList(),

                ArchivalList = task.Where(s => s.Status == (int)TaskStatus.Archival).Select(s => new TaskItemViewModel
                {
                    TaskId = s.TaskId,
                    Name = s.Name,
                    Status = s.Status,
                    BoardId = s.BoardId,
                    CategoryId = s.CategoryId,
                    CreationDate = s.CreationDate,
                    LastUpdate = s.LastUpdate
                }).ToList(),

                CompletedList = task.Where(s => s.Status == (int)TaskStatus.Completed).Select(s => new TaskItemViewModel
                {
                    TaskId = s.TaskId,
                    Name = s.Name,
                    Status = s.Status,
                    BoardId = s.BoardId,
                    CategoryId = s.CategoryId,
                    CreationDate = s.CreationDate,
                    LastUpdate = s.LastUpdate
                }).ToList(),
                PerformedList = task.Where(s => s.Status == (int)TaskStatus.Performed).Select(s => new TaskItemViewModel
                {
                    TaskId = s.TaskId,
                    Name = s.Name,
                    Status = s.Status,
                    BoardId = s.BoardId,
                    CategoryId = s.CategoryId,
                    CreationDate = s.CreationDate,
                    LastUpdate = s.LastUpdate
                }).ToList()
            };
            return taskView;
        }
    }
}