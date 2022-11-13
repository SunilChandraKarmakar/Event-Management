using System.ComponentModel.DataAnnotations;

namespace EventManagementService.Model.ViewModels.Venue
{
    public class VenueUpdateViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please, provied any title.")]
        [StringLength(50, MinimumLength = 2)]
        public string Title { get; set; }

        [Required(ErrorMessage = "Please, provied user id.")]
        [Display(Name = "User Id")]
        public string UserId { get; set; }

        [Required(ErrorMessage = "Please, select event type.")]
        [Display(Name = "Event Type")]
        public int EventTypeId { get; set; }

        [Required(ErrorMessage = "Please, select venue type.")]
        [Display(Name = "Venue Type")]
        public int VenueTypeId { get; set; }

        [Required(ErrorMessage = "Please, provied number of guest.")]
        [Display(Name = "Number of Guest")]
        [DataType(DataType.PhoneNumber)]
        public int NoOfGuest { get; set; }

        [Required(ErrorMessage = "Please, select booking date.")]
        [Display(Name = "Booking Date")]
        [DataType(DataType.DateTime)]
        public DateTime BookingDate { get; set; }

        [Required(ErrorMessage = "Please, provied venue amount.")]
        [Display(Name = "Venue Amount")]
        [DataType(DataType.Currency)]
        public double VenueAmount { get; set; }
    }
}
