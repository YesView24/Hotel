using Hotel.Domain.Entities;
using Hotel.Infrastructure.Data.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Infrastructure.Foundation
{
    public class HotelDbContext : DbContext
    {
        public DbSet<Guest>? Guests { get; set; }
        public DbSet<Reservation>? Reservations { get; set; }
        public DbSet<Room>? Rooms { get; set; }

        public HotelDbContext( DbContextOptions<HotelDbContext> options ) : base( options )
        { }

        protected override void OnModelCreating( ModelBuilder modelBuilder )
        {
            base.OnModelCreating( modelBuilder );

            modelBuilder.ApplyConfigurationsFromAssembly( typeof( GuestConfiguration ).Assembly );
        }
    }
}