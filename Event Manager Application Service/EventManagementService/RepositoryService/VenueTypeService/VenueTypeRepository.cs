using EventManagementService.DatabaseSetting;
using EventManagementService.Model.Models;
using Microsoft.EntityFrameworkCore;

namespace EventManagementService.RepositoryService.VenueTypeService
{
    public class VenueTypeRepository : IVenueTypeRepository
    {
        private readonly EventManagementDbContext _context;

        public VenueTypeRepository(EventManagementDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<VenueType>> GetVenueTypes()
        {
            var venueTypes = await _context.VenueTypes.ToListAsync();
            return venueTypes;
        }
    }
}
