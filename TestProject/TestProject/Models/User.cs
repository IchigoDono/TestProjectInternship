using System.Collections.Generic;

#nullable disable

namespace TasksTracker.Models
{
    public partial class User
    {
        public User()
        {
            Categories = new HashSet<Category>();
        }

        public int UserId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Category> Categories { get; set; }
    }
}
