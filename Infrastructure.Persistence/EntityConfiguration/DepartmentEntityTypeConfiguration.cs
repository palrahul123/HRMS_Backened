using Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.EntityConfiguration
{
    public class DepartmentEntityTypeConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {

            builder.Property(d => d.DepartmentName)
                    .IsRequired()
                    .HasMaxLength(200);


            builder.HasOne(d => d.Company)
                   .WithMany(c => c.Departments)
                   .HasForeignKey(d => d.CompanyId)
                   .OnDelete(DeleteBehavior.Restrict);


            builder.HasOne(d => d.Branch)
                   .WithMany(b => b.Departments)
                   .HasForeignKey(d => d.BranchId)
                   .OnDelete(DeleteBehavior.Restrict);


            builder.HasMany(d => d.Designations)
                   .WithOne(des => des.Department)
                   .HasForeignKey(des => des.DepartmentId)
                   .OnDelete(DeleteBehavior.Cascade);


            builder.HasIndex(d => d.CompanyId);
            builder.HasIndex(d => d.BranchId);
        }
    }
}
