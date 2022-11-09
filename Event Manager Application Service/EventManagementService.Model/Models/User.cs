using Microsoft.AspNetCore.Identity;

namespace EventManagementService.Model.Models
{
    public class User : IdentityUser
    {
        public User()
        {
            Foods = new List<Food>();
            Venues = new List<Venue>();
        }

        public string FullName { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime LastModifiedTime { get; set; }

        public ICollection<Food> Foods { get; set; }
        public ICollection<Venue> Venues { get; set; }
    }
}