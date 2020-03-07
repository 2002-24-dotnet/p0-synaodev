using Microsoft.EntityFrameworkCore;
using PizzaBox.Domain.Models;

namespace PizzaBox.Storage.Databases {
	public class PizzaBoxDbContext : DbContext {
		public DbSet<Crust> Crusts { get; set; }
		public DbSet<Size> Sizes { get; set; }
		public DbSet<Topping> Toppings { get; set; }
		public DbSet<Pizza> Pizzas { get; set; }
		protected override void OnConfiguring(DbContextOptionsBuilder builder) {
			builder.UseSqlServer("server=localhost;database=pizzaboxdb;user id=sa;password=Password12345;");
		}
		protected override void OnModelCreating(ModelBuilder builder) {
			builder.Entity<Crust>().HasKey(c => c.CrustID);
			builder.Entity<Crust>().Property(c => c.CrustID).ValueGeneratedNever();

			builder.Entity<Pizza>().HasKey(p => p.PizzaID);
			builder.Entity<Pizza>().Property(p => p.PizzaID).ValueGeneratedNever();

			builder.Entity<Size>().HasKey(s => s.SizeID);
			builder.Entity<Size>().Property(s => s.SizeID).ValueGeneratedNever();

			builder.Entity<Topping>().HasKey(t => t.ToppingID);
			builder.Entity<Topping>().Property(t => t.ToppingID).ValueGeneratedNever();
			builder.Entity<PizzaTopping>().HasKey(pt => new { pt.PizzaID, pt.ToppingID });

			builder.Entity<Crust>().HasMany(c => c.Pizzas).WithOne(p => p.Crust);
			builder.Entity<Pizza>().HasMany(p => p.PizzaToppings).WithOne(pt => pt.Pizza).HasForeignKey(pt => pt.PizzaID);
			builder.Entity<Size>().HasMany(s => s.Pizzas).WithOne(p => p.Size);
			builder.Entity<Topping>().HasMany(t => t.PizzaToppings).WithOne(pt => pt.Topping).HasForeignKey(pt => pt.ToppingID);

			builder.Entity<Crust>().HasData(new Crust[] {
				new Crust() { Name = "Deep Dish", Price = 3.50M },
				new Crust() { Name = "New York Style", Price = 2.50M },
				new Crust() { Name = "Thin Crust", Price = 1.50M }
			});

			builder.Entity<Size>().HasData(new Size[] {
				new Size() { Name = "Large", Price = 12.00M },
				new Size() { Name = "Medium", Price = 10.00M },
				new Size() { Name = "Small", Price = 8.00M },
			});

			builder.Entity<Topping>().HasData(new Topping[] {
				new Topping() { Name = "Cheese", Price = 0.25M },
				new Topping() { Name = "Pepperoni", Price = 0.50M },
				new Topping() { Name = "Tomato Sauce", Price = 0.75M },
			});
		}
	}
}