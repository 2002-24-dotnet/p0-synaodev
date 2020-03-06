using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PizzaBox.Domain.Models;

namespace PizzaBox.Storage.Databases {
	public class PizzaBoxDbContext : DbContext {
		public DbSet<Crust> Crusts { get; set; }
		public DbSet<Size> Sizes { get; set; }
		public DbSet<Topping> Toppings { get; set; }
		public DbSet<Pizza> Pizzas { get; set; }
		protected override void OnConfiguring(DbContextOptionsBuilder builder) {
			builder.UseSqlServer("server=localhost;database=pizzaboxdb;user id=sa;password=Tj6601Tj?;");
		}
		protected override void OnModelCreating(ModelBuilder builder) {
			builder.Entity<Pizza>().HasKey(p => p.PizzaID);
			builder.Entity<Crust>().HasKey(c => c.CrustID);
			builder.Entity<Size>().HasKey(s => s.SizeID);
			builder.Entity<Topping>().HasKey(t => t.ToppingID);

			builder.Entity<Crust>().HasMany<Pizza>().WithOne(p => p.Crust);
			builder.Entity<Size>().HasMany<Pizza>().WithOne(p => p.Size);
			builder.Entity<Topping>().HasMany<Pizza>();

			builder.Entity<Crust>().HasData(new Crust[] {
				new Crust() { Name = "Deep Dish", Price = 3.50M },
				new Crust() { Name = "New York Style", Price = 2.50M },
				new Crust() { Name = "Thin Crust", Price = 1.50M }
			});

			builder.Entity<Size>().HasData(new Size[] {
				new Size() { Name = "Large", Price = 12.00M },
				new Size() { Name = "Medium", Price = 10.00M },
				new Size() { Name = "Small", Price = 8.00M }
			});

			builder.Entity<Topping>().HasData(new Topping[] {
				new Topping() { Name = "Cheese", Price = 0.25M },
				new Topping() { Name = "Pepperoni", Price = 0.50M },
				new Topping() { Name = "Tomato Sauce", Price = 0.75M }
			});
		}
	}
}