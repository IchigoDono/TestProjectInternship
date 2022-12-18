using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TasksTracker.ViewModels
{
    public class TaskViewModel
    {
        public IEnumerable<TaskItemViewModel> CreatedList { get; set; }
        public IEnumerable<TaskItemViewModel> PerformedList { get; set; }
        public IEnumerable<TaskItemViewModel> CompletedList { get; set; }
        public IEnumerable<TaskItemViewModel> ArchivalList { get; set; }
    }

    public class TaskItemViewModel 
    {
        public int TaskId { get; set; }
        public string Name { get; set; }
        public int BoardId { get; set; }
        public DateTime CreationDate { get; set; }
        public int Status { get; set; }
        public DateTime LastUpdate { get; set; }
        public int CategoryId { get; set; }
    }
}

