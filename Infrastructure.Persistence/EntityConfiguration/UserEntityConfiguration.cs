using Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.EntityConfiguration
{
    public class UserEntityConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasMany(r => r.userRoles)
                   .WithOne(c => c.User)
                   .HasForeignKey(r => r.UserId)
                   .OnDelete(DeleteBehavior.Cascade);


            builder.HasOne(u => u.Company)
                   .WithMany(c => c.Users)
                   .HasForeignKey(u => u.CompanyId)
                   .OnDelete(DeleteBehavior.Cascade);


            builder.HasOne(u => u.Branch)
                   .WithMany(b => b.Users)
                   .HasForeignKey(u => u.BranchId)
                   .OnDelete(DeleteBehavior.Restrict);


            builder.HasOne(u => u.Branch)
                   .WithMany(b => b.Users)
                   .HasForeignKey(u => u.BranchId)
                   .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
