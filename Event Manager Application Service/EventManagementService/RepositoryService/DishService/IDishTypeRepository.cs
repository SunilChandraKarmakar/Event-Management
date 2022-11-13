using EventManagementService.Model.Models;

namespace EventManagementService.RepositoryService.DishService
{
    public interface IDishTypeRepository
    {
        Task<IEnumerable<DishType>> GetDishTypes();
    }
}
