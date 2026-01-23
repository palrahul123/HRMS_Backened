using Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.EntityConfiguration
{
    public class StateEntityTypeConfiguration : IEntityTypeConfiguration<State>
    {
        public void Configure(EntityTypeBuilder<State> builder)
        {
            builder.Property(s => s.Name)
               .IsRequired()
               .HasMaxLength(150);

            builder.Property(s => s.Code)
                   .HasMaxLength(10);

            builder.HasIndex(s => s.CountryId);

            builder.HasMany(s => s.Cities)
                   .WithOne(c => c.State)
                   .HasForeignKey(c => c.StateId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
