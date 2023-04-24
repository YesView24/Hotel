using Hotel.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hotel.Infrastructure.Data.Configurations
{
    public class RoomConfiguration : IEntityTypeConfiguration<Room>
    {
        public void Configure( EntityTypeBuilder<Room> builder )
        {
            builder.ToTable( "Room" )
                   .HasKey( b => b.Id );

            builder.Property( b => b.Id )
                   .HasColumnName( "RoomId" );

            builder.Property( b => b.Number )
                   .IsRequired()
                   .HasMaxLength( 10 );

            builder.Property( b => b.Description )
                   .IsRequired()
                   .HasMaxLength( 200 );

            builder.HasData(
                new Room { Id = 1, Number = "1a", Description = "Room 1a", Capacity = 1 },
                new Room { Id = 2, Number = "2a", Description = "Room 2a", Capacity = 2 },
                new Room { Id = 3, Number = "3a", Description = "Room 3a", Capacity = 3 } );
        }
    }
}