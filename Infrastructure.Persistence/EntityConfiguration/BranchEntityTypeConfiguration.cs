using Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.EntityConfiguration
{
    public class BranchEntityTypeConfiguration : IEntityTypeConfiguration<Branch>
    {
        public void Configure(EntityTypeBuilder<Branch> builder)

        {
            builder.Property(b => b.BranchName)
               .IsRequired()
               .HasMaxLength(250);

            builder.Property(b => b.Address)
                   .HasMaxLength(500);

            builder.Property(b => b.Area)
                   .HasMaxLength(150);

            builder.HasIndex(b => b.CountryId);
            builder.HasIndex(b => b.StateId);
            builder.HasIndex(b => b.CityId);
            builder.HasIndex(b => b.CompanyId);

            builder.HasOne(b => b.Country)
                   .WithMany()
                   .HasForeignKey(b => b.CountryId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(b => b.State)
                   .WithMany()
                   .HasForeignKey(b => b.StateId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(b => b.City)
                   .WithMany()
                   .HasForeignKey(b => b.CityId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(b => b.Company)
                   .WithMany(c => c.Branches)
                   .HasForeignKey(b => b.CompanyId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
