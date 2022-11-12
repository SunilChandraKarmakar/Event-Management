using EventManagementService.Model.ViewModels.EventType;
using EventManagementService.Model.ViewModels.User;
using EventManagementService.Model.ViewModels.VenueType;

namespace EventManagementService.Model.ViewModels.Venue
{
    public class VenueViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string UserId { get; set; }
        public int EnevtTypeId { get; set; }
        public int VenueTypeId { get; set; }
        public int NoOfGuest { get; set; }
        public DateTime BookingDate { get; set; }

        public UserViewModel User { get; set; }
        public EventTypeViewModel EventType { get; set; }
        public VenueTypeViewModel VenueType { get; set; }
    }
}
