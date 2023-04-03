using CSM.Components.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace CSM.Components.DataAccess
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Customer>()
                .HasIndex(customer => customer.CustomerId);
            modelBuilder.Entity<Customer>()
                .HasIndex(customer => customer.Email);
            modelBuilder.Entity<Customer>()
                .HasIndex(customer => customer.Mobile);
        }
    }
}
