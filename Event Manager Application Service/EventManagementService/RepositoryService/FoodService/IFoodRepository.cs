using EventManagementService.Model.Models;

namespace EventManagementService.RepositoryService.FoodService
{
    public interface IFoodRepository
    {
        Task<IEnumerable<Food>> GetFoods(string userId);
        Task<Food> GetFood(int? id);
        Task<bool> Create(Food model);
        Task<bool> Update(Food model);
        Task<bool> Remove(int? id);
    }
}
