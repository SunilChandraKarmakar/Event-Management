using EventManagementService.DatabaseSetting;
using EventManagementService.Model.Models;
using Microsoft.EntityFrameworkCore;

namespace EventManagementService.RepositoryService.MealTypeService
{
    public class MealTypeRepository : IMealTypeRepository
    {
        private readonly EventManagementDbContext _context;

        public MealTypeRepository(EventManagementDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MealType>> GetMealTypes()
        {
            var mealTypes = await _context.MealTypes.ToListAsync();
            return mealTypes;
        }
    }
}