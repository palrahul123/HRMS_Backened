using Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.EntityConfiguration
{
    public class CountryEntityTypeConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.Property(c => c.Name)
               .IsRequired()
               .HasMaxLength(150);

            builder.Property(c => c.Code)
                   .HasMaxLength(10);

            builder.HasMany(c => c.States)
                   .WithOne(s => s.Country)
                   .HasForeignKey(s => s.CountryId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
