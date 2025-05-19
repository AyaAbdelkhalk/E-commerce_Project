using E_commerce.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace E_commerce.Infrastructure
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                   .UseLazyLoadingProxies()

                        //.UseSqlServer("Data Source=DESKTOP-PQOAC0F\\SQL;Initial Catalog=EcommerceDb;Integrated Security=True;Encrypt=False;Trust Server Certificate=True;MultipleActiveResultSets=True");


            //.UseSqlServer("Data Source=.;Initial Catalog=EcommerceDb;Integrated Security=True;Encrypt=False;Trust Server Certificate=True;MultipleActiveResultSets=True");
            //.UseSqlServer("Data Source=.;Initial Catalog=OurSystem;Integrated Security=True;Encrypt=False;Trust Server Certificate=True;MultipleActiveResultSets=True");

            .UseSqlServer("Data Source=VIRUS\\SQLEXPRESS;Initial Catalog=EcommerceDb;Integrated Security=True;Encrypt=False;Trust Server Certificate=True");
            //.UseSqlServer("Data Source=DESKTOP-PQOAC0F\\SQL;Initial Catalog=Ecom2merceDbTest;Integrated Security=True;Encrypt=False;Trust Server Certificate=True").EnableRetryOnFailure();

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasIndex(u => u.UserName)
                .IsUnique();
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();
            modelBuilder.Entity<Category>()
               .HasIndex(c => c.Name)
               .IsUnique();
            // Configure relationships
            modelBuilder.Entity<OrderDetail>()
                .HasOne(od => od.Order)
                .WithMany(o => o.OrderDetails)
                .HasForeignKey(od => od.OrderID);

            modelBuilder.Entity<OrderDetail>()
                .HasOne(od => od.Product)
                .WithMany()
                .HasForeignKey(od => od.ProductID);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.User)
                .WithMany()
                .HasForeignKey(o => o.UserID);
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<CartItem> CartItems { get; set; }

    }
}
