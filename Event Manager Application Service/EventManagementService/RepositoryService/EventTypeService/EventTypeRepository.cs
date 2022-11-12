using EventManagementService.DatabaseSetting;
using EventManagementService.Model.Models;
using Microsoft.EntityFrameworkCore;

namespace EventManagementService.RepositoryService.EventTypeService
{
    public class EventTypeRepository : IEventTypeRepository
    {
        private readonly EventManagementDbContext _context;

        public EventTypeRepository(EventManagementDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<EventType>> GetEventTypes()
        {
            var eventTypes = await _context.EventTypes.ToListAsync();
            return eventTypes;
        }
    }
}