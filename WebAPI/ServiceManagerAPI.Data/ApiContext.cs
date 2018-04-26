namespace ServiceManagerAPI.Data
{
    using ServiceManagerAPI.Entities.Models;
    using System.Configuration;
    using System.Data.Entity;

    public class ApiContext : DbContext
    {
        public ApiContext()
            : base("name=ApiContext")
        {
            // Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApiContext, Configuration>());
        }

        public virtual DbSet<Service> Services { get; set; }

        public virtual DbSet<Order> Orders { get; set; }

        public virtual DbSet<Customer> Customers { get; set; }

        public virtual DbSet<Employee> Employees { get; set; }
    }
}