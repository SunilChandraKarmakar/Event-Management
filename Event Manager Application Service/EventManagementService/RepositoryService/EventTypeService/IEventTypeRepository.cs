using EventManagementService.Model.Models;

namespace EventManagementService.RepositoryService.EventTypeService
{
    public interface IEventTypeRepository
    {
        Task<IEnumerable<EventType>> GetEventTypes();
    }
}
