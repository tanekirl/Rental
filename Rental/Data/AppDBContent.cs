using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Rental.Data.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rental.Data
{
    public class AppDBContent : IdentityDbContext<User>
    {
        public AppDBContent(DbContextOptions<AppDBContent> options) : base(options) { }

        public DbSet<Car> Car { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<RentalCartItem> RentalCartItem { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderDetail> OrderDetail { get; set; }
        public DbSet<CarImage> CarImages { get; set; } // Додайте цю лінію

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>()
                .Property(c => c.price)
                .HasColumnType("decimal(18, 2)"); // Задайте точність і масштаб для price

            // Конфігурація для CarImage
            modelBuilder.Entity<CarImage>()
                .HasKey(ci => ci.Id); // Визначаємо первинний ключ

            modelBuilder.Entity<CarImage>()
                .HasOne(ci => ci.Car)
                .WithMany(c => c.Images) // Вказуємо, що Car має багато зображень
                .HasForeignKey(ci => ci.CarId); // Визначаємо зовнішній ключ
            base.OnModelCreating(modelBuilder);
        }
    }
}