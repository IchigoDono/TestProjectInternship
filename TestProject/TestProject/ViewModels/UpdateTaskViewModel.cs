using System.ComponentModel.DataAnnotations;

namespace TasksTracker.ViewModels
{
    public class UpdateTaskViewModel
    {
        [Required]
        [StringLength(255, MinimumLength = 2)]
        public string Name { get; set; }
        [Required]
        [StringLength(255, MinimumLength = 2)]
        public int Status { get; set; }
        [Required]
        [StringLength(255, MinimumLength = 2)]
        public int CategoryId { get; set; }
        [StringLength(255, MinimumLength = 2)]
        public int TaskId { get; set; }
    }
}