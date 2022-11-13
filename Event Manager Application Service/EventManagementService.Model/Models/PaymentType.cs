using System.ComponentModel.DataAnnotations;

namespace EventManagementService.Model.Models
{
    public class PaymentType
    {
        public PaymentType()
        {
            Payments = new HashSet<Payment>();
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "Please, provied name.")]
        [StringLength(50, MinimumLength = 2)]
        public string Name { get; set; }

        public ICollection<Payment> Payments { get; set; }
    }
}