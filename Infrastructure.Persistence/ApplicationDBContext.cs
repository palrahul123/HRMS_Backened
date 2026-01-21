using Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }

        override protected void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDBContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Company> companies { get; set; }
        public DbSet<Department> departments { get; set; }
        public DbSet<Designation> designations { get; set; }
        public DbSet<User> users { get; set; }
        public DbSet<Branch> branches { get; set; }
    }
}
