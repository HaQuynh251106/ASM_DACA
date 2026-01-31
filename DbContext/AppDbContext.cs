using Microsoft.EntityFrameworkCore;
using ASM_Bai2.Models;
using ASM_Bai2.Models.StoredProcedureResults;

namespace ASM_Bai2.DBContext

{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Category> Categories { get; set; }


        public DbSet<OrderDetailResult> OrderDetailResults { get; set; }
        public DbSet<OrderWithCustomerResult> OrderWithCustomerResults { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Customer>();
            modelBuilder.Entity<Product>();
            modelBuilder.Entity<Order>();
            modelBuilder.Entity<OrderItem>();
            modelBuilder.Entity<Category>();
            modelBuilder.Entity<OrderDetailResult>().HasNoKey();
            modelBuilder.Entity<OrderWithCustomerResult>().HasNoKey();
        }

    }
}
