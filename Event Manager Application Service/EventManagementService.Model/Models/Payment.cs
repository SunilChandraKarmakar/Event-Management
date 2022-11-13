using System.ComponentModel.DataAnnotations;

namespace EventManagementService.Model.Models
{
    public class Payment
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please, provied user id.")]
        [Display(Name = "User")]
        public string UserId { get; set; }

        [Required(ErrorMessage = "Please, select food.")]
        [Display(Name = "Food")]
        public int FoodId { get; set; }

        [Required(ErrorMessage = "Please, select venue.")]
        [Display(Name = "Venue")]
        public int VenueId { get; set; }

        [Required(ErrorMessage = "Please, select payment type.")]
        [Display(Name = "Payment Type")]
        public int PaymentTypeId { get; set; }

        [Required(ErrorMessage = "Please, provied amount.")]
        [DataType(DataType.Currency)]
        public decimal TotalAmmount { get; set; }
        public bool IsPaymentComplete { get; set; }

        [Required(ErrorMessage = "Please, select payment date.")]
        [DataType(DataType.Date)]
        public DateTime PaymentDate { get; set; }

        public User User { get; set; }
        public PaymentType PaymentType { get; set; }
        public Food Food { get; set; }
        public Venue Venue { get; set; }
    }
}