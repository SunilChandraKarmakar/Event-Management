using EventManagementService.DatabaseSetting;
using EventManagementService.Model.Models;
using Microsoft.EntityFrameworkCore;

namespace EventManagementService.RepositoryService.DishService
{
    public class DishTypeRepository : IDishTypeRepository
    {
        private readonly EventManagementDbContext _context;

        public DishTypeRepository(EventManagementDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DishType>> GetDishTypes()
        {
            var dishTypes = await _context.DishTypes.ToListAsync();
            return dishTypes;
        }
    }
}