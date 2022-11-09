using EventManagementService.Model.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EventManagementService.DatabaseSetting
{
    public class EventManagementDbContext : IdentityDbContext<User, IdentityRole, string>
    {
        public EventManagementDbContext(DbContextOptions<EventManagementDbContext> options) : base(options)
        {

        }

        public DbSet<EventType> EventTypes { get; set; }
        public DbSet<VenueType> VenueTypes { get; set; }
        public DbSet<FoodType> FoodTypes { get; set; }
        public DbSet<MealType> MealTypes { get; set; }
        public DbSet<DishType> DishTypes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Venue> Venues { get; set; }
        public DbSet<Food> Foods { get; set; }
    }
}