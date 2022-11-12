using EventManagementService.Model.ViewModels.Venue;

namespace EventManagementService.Model.ViewModels.EventType
{
    public class EventTypeViewModel
    {
        public EventTypeViewModel()
        {
            Venues = new HashSet<VenueViewModel>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<VenueViewModel> Venues { get; set; }
    }
}
