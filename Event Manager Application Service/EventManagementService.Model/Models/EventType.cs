using System.ComponentModel.DataAnnotations;

namespace EventManagementService.Model.Models
{
    public class EventType
    {
        public EventType()
        {
            Venues = new HashSet<Venue>(); 
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "Please, provied name.")]
        [StringLength(50, MinimumLength = 2)]
        public string Name { get; set; }

        public ICollection<Venue> Venues { get; set; }
    }
}