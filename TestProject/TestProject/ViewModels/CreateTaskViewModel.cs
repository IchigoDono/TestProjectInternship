using System.ComponentModel.DataAnnotations;

namespace TasksTracker.ViewModels
{
    public class CreateTaskViewModel
    {
        [Required]
        [StringLength(255, MinimumLength = 2)]
        public string Name { get; set; }
        [Required]
        public int BoardId { get; set; }
        [Required]
        public int Status { get; set; }
        [Required]
        public int CategoryId { get; set; }

    }
}
