using EventManagementService.Model.ViewModels.Food;
using EventManagementService.Model.ViewModels.Venue;

namespace EventManagementService.Model.ViewModels.User
{
    public class UserViewModel
    {
        public UserViewModel()
        {
            Foods = new HashSet<FoodViewModel>();
            Venues = new HashSet<VenueViewModel>();
        }

        public string Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime CreatedTime { get; set; }
        public string Token { get; set; }

        public ICollection<VenueViewModel> Venues { get; set; }
        public ICollection<FoodViewModel> Foods { get; set; }
    }
}