using EventManagementService.Model.Models;

namespace EventManagementService.RepositoryService.FoodTypeService
{
    public interface IFoodTypeRepository
    {
        Task<IEnumerable<FoodType>> GetFoodTypes();
    }
}
