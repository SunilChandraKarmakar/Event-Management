using EventManagementService.Model.Models;

namespace EventManagementService.RepositoryService.VenueService
{
    public interface IVenueRepository
    {
        Task<IEnumerable<Venue>> GetVenues(string userId);
        Task<Venue> GetVenue(int? id);
        Task<bool> Create(Venue model);
        Task<bool> Update(Venue model);
        Task<bool> Remove(int? id);
    }
}