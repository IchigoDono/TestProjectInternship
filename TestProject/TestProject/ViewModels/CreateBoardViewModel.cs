using System.ComponentModel.DataAnnotations;

namespace TasksTracker.ViewModels
{
    public class CreateBoardViewModel
    {
        [Required]
        [StringLength(255, MinimumLength = 2)]
        public string Name { get; set; }
        [Required]
        [StringLength(255, MinimumLength = 2)]
        public string Description { get; set; }
    }
}
