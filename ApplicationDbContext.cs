using HomeGrocery.DAL.Models;
using Microsoft.EntityFrameworkCore;
namespace HomeGrocery.DAL.Context
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions options)
            : base(options)
        {
        }
        public DbSet<Role> Role { get; set; } = null!;
        public DbSet<User> User { get; set; } = null!;
        public DbSet<Product> Product { get; set; } = null!;
        public DbSet<Order> Order { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
            .HasData(
            new Product { ProductID = 1, ProductName = "Milk", ProductPrice = 25, Imageurl = "MIlkImage" },
            new Product { ProductID = 2, ProductName = "Bread", ProductPrice = 15, Imageurl = "BreadImage" },
            new Product { ProductID = 3, ProductName = "Butter", ProductPrice = 50, Imageurl = "Buttermage" },
            new Product { ProductID = 4, ProductName = "Honey", ProductPrice = 80, Imageurl = "HoneyImage" },
            new Product { ProductID = 5, ProductName = "Toothpaste", ProductPrice = 60, Imageurl = "ToothpasteImage" }
            );

            modelBuilder.Entity<User>()
                .HasData(
                new User { UserID = 1 , FirstName = "Admin" , LastName="Grocery", Email="admin07@gmail.com" , Password = "adminspassword"}

                );



        }

    }
}
