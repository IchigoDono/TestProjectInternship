using System;
using System.Collections.Generic;

#nullable disable

namespace TasksTracker.Models
{
    public partial class Task
    {
        public string TaskId { get; set; }
        public string Name { get; set; }
        public int BoardId { get; set; }
        public DateTime CreationDate { get; set; }
        public int Status { get; set; }
        public DateTime LastUpdate { get; set; }
        public int CategoryId { get; set; }

        public virtual Board Board { get; set; }
        public virtual Category Category { get; set; }
    }
}
