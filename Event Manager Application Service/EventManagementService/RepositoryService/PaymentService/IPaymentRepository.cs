using EventManagementService.Model.Models;

namespace EventManagementService.RepositoryService.PaymentService
{
    public interface IPaymentRepository
    {
        Task<IEnumerable<Payment>> GetPayments(string userId);
        Task<bool> Create(Payment model);
    }
}
