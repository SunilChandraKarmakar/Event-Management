using EventManagementService.Model.ViewModels.Food;
using EventManagementService.Model.ViewModels.PaymentType;
using EventManagementService.Model.ViewModels.User;
using EventManagementService.Model.ViewModels.Venue;

namespace EventManagementService.Model.ViewModels.Payment
{
    public class PaymentViewModel
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int FoodId { get; set; }
        public int VenueId { get; set; }
        public int PaymentTypeId { get; set; }
        public decimal TotalAmmount { get; set; }
        public bool IsPaymentComplete { get; set; }
        public DateTime PaymentDate { get; set; }

        public UserViewModel User { get; set; }
        public PaymentTypeViewModel PaymentType { get; set; }
        public FoodViewModel Food { get; set; }
        public VenueViewModel Venue { get; set; }
    }
}
