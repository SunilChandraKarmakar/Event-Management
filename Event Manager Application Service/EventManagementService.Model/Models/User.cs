using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace EventManagementService.Model.Models
{
    public class User : IdentityUser
    {
        public User()
        {
            Foods = new HashSet<Food>();
            Venues = new HashSet<Venue>();
            Payments = new HashSet<Payment>();
        }

        public string FullName { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime LastModifiedTime { get; set; }
        public string MobileNumber { get; set; }
        public string Address { get; set; }

        public ICollection<Food> Foods { get; set; }
        public ICollection<Venue> Venues { get; set; }
        public ICollection<Payment> Payments { get; set; }
    }
}