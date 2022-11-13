using EventManagementService.DatabaseSetting;
using EventManagementService.Model.Models;
using Microsoft.EntityFrameworkCore;

namespace EventManagementService.RepositoryService.FoodTypeService
{
    public class FoodTypeRepository : IFoodTypeRepository
    {
        private readonly EventManagementDbContext _context;

        public FoodTypeRepository(EventManagementDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<FoodType>> GetFoodTypes()
        {
            var foodTypes = await _context.FoodTypes.ToListAsync();
            return foodTypes;
        }
    }
}
