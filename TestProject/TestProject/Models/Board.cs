using System;
using System.Collections.Generic;

#nullable disable

namespace TasksTracker.Models
{
    public partial class Board
    {
        public string Name { get; set; }
        public int BoardId { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public bool IsActive { get; set; }
    }
}
