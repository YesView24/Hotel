using Hotel.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hotel.Infrastructure.Data.Configurations
{
    public class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
    {
        public void Configure( EntityTypeBuilder<Reservation> builder )
        {
            builder.ToTable( "Reservation" )
                   .HasKey( b => b.Id );

            builder.Property( b => b.Id )
                   .HasColumnName( "ReservationId" );

            builder.HasOne( b => b.Guest )
                   .WithMany( a => a.Reservations )
                   .HasForeignKey( b => b.GuestId )
                   .OnDelete( DeleteBehavior.Cascade );

            builder.HasOne( b => b.Room )
                   .WithMany( a => a.Reservations )
                   .HasForeignKey( b => b.RoomId )
                   .OnDelete( DeleteBehavior.Cascade );

            builder.HasData(
                new Reservation { Id = 1, StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays( 2 ), RoomId = 3, GuestId = 2 },
                new Reservation { Id = 2, StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays( 3 ), RoomId = 1, GuestId = 3 },
                new Reservation { Id = 3, StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays( 4 ), RoomId = 2, GuestId = 1 } );
        }
    }
}