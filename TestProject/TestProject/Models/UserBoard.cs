using System;
using System.Collections.Generic;

#nullable disable

namespace TasksTracker.Models
{
    public partial class UserBoard
    {
        public int UserId { get; set; }
        public int BoardId { get; set; }

        public virtual Board Board { get; set; }
        public virtual User User { get; set; }
    }
}
