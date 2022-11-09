namespace EventManagementService.Model.Models
{
    public class EventType
    {
        public EventType()
        {
            Venues = new List<Venue>(); 
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Venue> Venues { get; set; }
    }
}