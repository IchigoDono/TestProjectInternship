using System;
using System.Collections.Generic;

#nullable disable

namespace TasksTracker.Models
{
    public partial class Category
    {
        public Category()
        {
            Tasks = new HashSet<Task>();
        }

        public int CategoryId { get; set; }
        public string Name { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<Task> Tasks { get; set; }
    }
}
