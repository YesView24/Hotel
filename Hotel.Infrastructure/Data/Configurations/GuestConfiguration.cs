using Hotel.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hotel.Infrastructure.Data.Configurations
{
    public class GuestConfiguration : IEntityTypeConfiguration<Guest>
    {
        public void Configure( EntityTypeBuilder<Guest> builder )
        {
            builder.ToTable( "Guest" )
                   .HasKey( b => b.Id );

            builder.Property( b => b.Id )
                   .HasColumnName( "GuestId" );

            builder.Property( b => b.Name )
                   .IsRequired()
                   .HasMaxLength( 50 );

            builder.Property( b => b.PhoneNumber )
                   .IsRequired()
                   .HasMaxLength( 20 );

            builder.HasData(
                new Guest { Id = 1, Name = "Maxim", PhoneNumber = "PhoneNumber 1" },
                new Guest { Id = 2, Name = "Denis", PhoneNumber = "PhoneNumber 2" },
                new Guest { Id = 3, Name = "Valera", PhoneNumber = "PhoneNumber 3" },
                new Guest { Id = 4, Name = "Ivan", PhoneNumber = "PhoneNumber 4" } );
        }
    }
}