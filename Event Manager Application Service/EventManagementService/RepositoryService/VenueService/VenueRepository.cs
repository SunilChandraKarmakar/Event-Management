using EventManagementService.DatabaseSetting;
using EventManagementService.Model.Models;
using Microsoft.EntityFrameworkCore;

namespace EventManagementService.RepositoryService.VenueService
{
    public class VenueRepository : IVenueRepository
    {
        private readonly EventManagementDbContext _context;

        public VenueRepository(EventManagementDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Venue>> GetVenues(string userId)
        {
            var venues = await _context.Venues
                        .Include(v => v.User)
                        .Include(v => v.EventType)
                        .Include(v => v.VenueType)
                        .Where(v => v.UserId == userId)
                        .ToListAsync();

            return venues;
        }

        public async Task<Venue> GetVenue(int? id)
        {
            var existVenue = await _context.Venues.Where(v => v.Id == id).FirstOrDefaultAsync();
            return existVenue!;
        }

        public async Task<bool> Create(Venue model)
        {
            if (model == null)
                return false;

            await _context.Venues.AddAsync(model);
            var isCreated = await _context.SaveChangesAsync() > 0;

            if (isCreated)
                return true;

            return false;
        }

        public async Task<bool> Update(Venue model)
        {
            if (model == null)
                return false;

            var updateVenue = _context.Venues.Attach(model);
            updateVenue.State = EntityState.Modified;
            var isUpdate = await _context.SaveChangesAsync() > 0;

            if (isUpdate)
                return true;

            return false;
        }

        public async Task<bool> Remove(int? id)
        {
            var existVenue = await _context.Venues.Where(v => v.Id == id).FirstOrDefaultAsync();

            if (existVenue == null)
                return false;

            _context.Remove(existVenue);
            var isDeleted = await _context.SaveChangesAsync() > 0;

            if (isDeleted)
                return true;

            return false;
        }
    }
}