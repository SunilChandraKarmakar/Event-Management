using EventManagementService.DatabaseSetting;
using EventManagementService.Model.Models;
using Microsoft.EntityFrameworkCore;

namespace EventManagementService.RepositoryService.FoodService
{
    public class FoodRepository : IFoodRepository
    {
        private readonly EventManagementDbContext _context;

        public FoodRepository(EventManagementDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Food>> GetFoods(string userId)
        {
            var foods = await _context.Foods
                        .Include(f => f.User)
                        .Include(f => f.FoodType)
                        .Include(f => f.MealType)
                        .Include(f => f.DishType)
                        .Where(v => v.UserId == userId)
                        .ToListAsync();

            return foods;
        }

        public async Task<Food> GetFood(int? id)
        {
            var existFood = await _context.Foods.Where(v => v.Id == id).FirstOrDefaultAsync();
            return existFood!;
        }

        public async Task<bool> Create(Food model)
        {
            if (model == null)
                return false;

            await _context.Foods.AddAsync(model);
            var isCreated = await _context.SaveChangesAsync() > 0;

            if (isCreated)
                return true;

            return false;
        }

        public async Task<bool> Update(Food model)
        {
            if (model == null)
                return false;

            var updateFood = _context.Foods.Attach(model);
            updateFood.State = EntityState.Modified;
            var isUpdate = await _context.SaveChangesAsync() > 0;

            if (isUpdate)
                return true;

            return false;
        }

        public async Task<bool> Remove(int? id)
        {
            var existFood = await _context.Foods.Where(v => v.Id == id).FirstOrDefaultAsync();

            if (existFood == null)
                return false;

            _context.Foods.Remove(existFood);
            var isDeleted = await _context.SaveChangesAsync() > 0;

            if (isDeleted)
                return true;

            return false;
        }
    }
}