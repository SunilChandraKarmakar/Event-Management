namespace EventManagementService.Model.Models
{
    public class Venue
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int EnevtTypeId { get; set; }
        public int VenueTypeId { get; set; }
        public int NoOfGuest { get; set; }
        public DateTime BookingDate { get; set; }

        public User User { get; set; }
        public EventType EventType { get; set; }
        public VenueType VenueType { get; set; }
    }
}