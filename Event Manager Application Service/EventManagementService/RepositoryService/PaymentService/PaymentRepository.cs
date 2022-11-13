using EventManagementService.DatabaseSetting;
using EventManagementService.Model.Models;
using Microsoft.EntityFrameworkCore;

namespace EventManagementService.RepositoryService.PaymentService
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly EventManagementDbContext _context;

        public PaymentRepository(EventManagementDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Payment>> GetPayments(string userId)
        {
            var payments = await _context.Payments
                        .Include(p => p.User)
                        .Include(p => p.PaymentType)
                        .Include(p => p.Food)
                        .Include(p => p.Venue)
                        .Where(v => v.UserId == userId)
                        .ToListAsync();

            return payments;
        }

        public async Task<bool> Create(Payment model)
        {
            if (model == null)
                return false;

            await _context.Payments.AddAsync(model);
            var isCreated = await _context.SaveChangesAsync() > 0;

            if (isCreated)
                return true;

            return false;
        }
    }
}