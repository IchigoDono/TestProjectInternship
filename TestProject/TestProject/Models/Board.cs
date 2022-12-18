using System;
using System.Collections.Generic;

#nullable disable

namespace TasksTracker.Models
{
    public partial class Board
    {
        public Board()
        {
            Tasks = new HashSet<Task>();
            UserBoards = new HashSet<UserBoard>();
        }

        public string Name { get; set; }
        public int BoardId { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<Task> Tasks { get; set; }
        public virtual ICollection<UserBoard> UserBoards { get; set; }
    }
}
