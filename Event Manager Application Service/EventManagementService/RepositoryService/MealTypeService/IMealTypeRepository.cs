using EventManagementService.Model.Models;

namespace EventManagementService.RepositoryService.MealTypeService
{
    public interface IMealTypeRepository
    {
        Task<IEnumerable<MealType>> GetMealTypes();
    }
}