using System;
using System.Collections.Generic;

#nullable disable

namespace TasksTracker.Models
{
    public partial class BoardReference
    {
        public int BoardReferenceId { get; set; }
        public string Url { get; set; }
        public Guid Reference { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ExperationDate { get; set; }
        public int BoardId { get; set; }
        public string IsActive { get; set; }

        public virtual Board Board { get; set; }
    }
}
