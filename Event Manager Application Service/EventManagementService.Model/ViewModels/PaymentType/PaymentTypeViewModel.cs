using EventManagementService.Model.ViewModels.Payment;

namespace EventManagementService.Model.ViewModels.PaymentType
{
    public class PaymentTypeViewModel
    {
        public PaymentTypeViewModel()
        {
            Payments = new HashSet<PaymentViewModel>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<PaymentViewModel> Payments { get; set; }
    }
}