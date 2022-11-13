using EventManagementService.DatabaseSetting;
using EventManagementService.Model.Models;
using Microsoft.EntityFrameworkCore;

namespace EventManagementService.RepositoryService.PaymentTypeService
{
    public class PaymentTypeRepository : IPaymentTypeRepository
    {
        private readonly EventManagementDbContext _context;

        public PaymentTypeRepository(EventManagementDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PaymentType>> GetPaymentTypes()
        {
            var paymentTypes = await _context.PaymentTypes.ToListAsync();
            return paymentTypes;
        }
    }
}