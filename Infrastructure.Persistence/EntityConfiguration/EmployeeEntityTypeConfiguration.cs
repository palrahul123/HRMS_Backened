using Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.EntityConfiguration;

public class EmployeeEntityTypeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.HasMany(e => e.EmployeeBankAccounts)
               .WithOne(eba => eba.Employee)
               .HasForeignKey(eba => eba.EmployeeId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(e => e.DocumentUploads)
            .WithOne(du => du.Employee)
                .HasForeignKey(du => du.EmployeeId)
                .OnDelete(DeleteBehavior.Cascade);
    }
}

