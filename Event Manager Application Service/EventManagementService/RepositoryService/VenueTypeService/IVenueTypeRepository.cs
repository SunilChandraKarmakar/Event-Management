using EventManagementService.Model.Models;

namespace EventManagementService.RepositoryService.VenueTypeService
{
    public interface IVenueTypeRepository
    {
        Task<IEnumerable<VenueType>> GetVenueTypes();
    }
}
