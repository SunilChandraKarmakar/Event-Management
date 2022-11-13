using EventManagementService.Model.Models;

namespace EventManagementService.RepositoryService.PaymentTypeService
{
    public interface IPaymentTypeRepository
    {
        Task<IEnumerable<PaymentType>> GetPaymentTypes();
    }
}
