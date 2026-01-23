using Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.EntityConfiguration
{
    public class CompanyEntityConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.Property(c => c.CompanyName)
              .IsRequired()
              .HasMaxLength(250);

            builder.Property(c => c.Address)
                   .HasMaxLength(500);

            builder.Property(c => c.Area)
                   .HasMaxLength(150);

            builder.Property(c => c.PinCode)
                   .HasMaxLength(20);

            builder.Property(c => c.PhoneNumber)
                   .HasMaxLength(20);

            builder.HasIndex(c => c.CountryId);
            builder.HasIndex(c => c.StateId);
            builder.HasIndex(c => c.CityId);

            builder.HasMany(c => c.Branches)
            .WithOne(b => b.Company)
            .HasForeignKey(b => b.CompanyId)
            .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(c => c.Departments)
                   .WithOne(d => d.Company)
                   .HasForeignKey(d => d.CompanyId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(c => c.Users)
                   .WithOne(u => u.Company)
                   .HasForeignKey(u => u.CompanyId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(c => c.Country)
                   .WithMany()
                   .HasForeignKey(c => c.CountryId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(c => c.State)
                   .WithMany()
                   .HasForeignKey(c => c.StateId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(c => c.City)
                   .WithMany()
                   .HasForeignKey(c => c.CityId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
