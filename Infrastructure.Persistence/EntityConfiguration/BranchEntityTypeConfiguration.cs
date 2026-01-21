using Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.EntityConfiguration
{
    public class BranchEntityTypeConfiguration : IEntityTypeConfiguration<Branch>
    {
        public void Configure(EntityTypeBuilder<Branch> builder)
        {
            builder.HasKey(k => k.Id);
            builder.Property(p => p.BranchName).IsRequired().HasMaxLength(200);

            builder.HasMany(p => p.departments)
                .WithOne(p => p.Branch)
                .HasForeignKey(p => p.BranchId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
