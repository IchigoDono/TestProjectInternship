using System;

namespace TasksTracker.ViewModels
{
    public class ResultBoardViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public string ErrorMessage { get; set; }
    }
}
