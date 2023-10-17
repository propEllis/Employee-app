using Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Data
{
    public class EmployeeContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }

        public EmployeeContext(DbContextOptions options) : base(options)
        {
        }

        //You can override the OnModelCreating method in your derived context and use the fluent API to configure your model. This is the most powerful method of configuration and allows configuration to be specified without modifying your entity classes.
        //he configuration is applied in the order the methods are called and if there are any conflicts the latest call will override previously specified configuration.
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new EmployeeConfig());
        }
    }
}