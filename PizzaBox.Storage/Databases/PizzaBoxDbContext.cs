using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PizzaBox.Domain.Models;

namespace PizzaBox.Storage.Databases {
	public class PizzaBoxDbContext : DbContext {
		public DbSet<Crust> Crusts { get; set; }
		public DbSet<Size> Sizes { get; set; }
		public DbSet<Topping> Toppings { get; set; }
		public DbSet<Pizza> Pizzas { get; set; }
		public DbSet<User> Users { get; set; }
		public DbSet<Order> Orders { get; set; }
		public DbSet<Store> Stores { get; set; }
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
			builder.Entity<User>().HasKey(u => u.UserID);
			builder.Entity<User>().Property(u => u.UserID).ValueGeneratedNever();
			builder.Entity<Order>().HasKey(o => o.OrderID);
			builder.Entity<Order>().Property(o => o.OrderID).ValueGeneratedNever();
			builder.Entity<Store>().HasKey(r => r.StoreID);
			builder.Entity<Store>().Property(r => r.StoreID).ValueGeneratedNever();

			builder.Entity<PizzaTopping>().HasKey(pt => new { pt.PizzaID, pt.ToppingID });
			builder.Entity<OrderPizza>().HasKey(po => new { po.PizzaID, po.OrderID });

			builder.Entity<Crust>().HasMany(c => c.Pizzas).WithOne(p => p.Crust);
			builder.Entity<Size>().HasMany(s => s.Pizzas).WithOne(p => p.Size);
			builder.Entity<User>().HasMany(u => u.Orders).WithOne(o => o.User);
			builder.Entity<Store>().HasMany(r => r.Orders).WithOne(o => o.Store);

			builder.Entity<Pizza>().HasMany(p => p.PizzaToppings).WithOne(pt => pt.Pizza).HasForeignKey(pt => pt.PizzaID);
			builder.Entity<Topping>().HasMany(t => t.PizzaToppings).WithOne(pt => pt.Topping).HasForeignKey(pt => pt.ToppingID);
			builder.Entity<Pizza>().HasMany(p => p.OrderPizzas).WithOne(po => po.Pizza).HasForeignKey(po => po.PizzaID);
			builder.Entity<Order>().HasMany(o => o.OrderPizzas).WithOne(po => po.Order).HasForeignKey(po => po.OrderID);

			builder.Entity<Crust>().HasData(new Crust[] {
				new Crust() { CrustID = 1, Name = "Deep Dish", Price = 3.50M },
				new Crust() { CrustID = 2, Name = "New York Style", Price = 2.50M },
				new Crust() { CrustID = 3, Name = "Thin Crust", Price = 1.50M }
			});

			builder.Entity<Size>().HasData(new Size[] {
				new Size() { SizeID = 1, Name = "Large", Price = 12.00M },
				new Size() { SizeID = 2, Name = "Medium", Price = 10.00M },
				new Size() { SizeID = 3, Name = "Small", Price = 8.00M }
			});

			builder.Entity<Topping>().HasData(new Topping[] {
				new Topping() { ToppingID = 1, Name = "Cheese", Price = 0.25M },
				new Topping() { ToppingID = 2, Name = "Pepperoni", Price = 0.50M },
				new Topping() { ToppingID = 3, Name = "Tomato Sauce", Price = 0.75M }
			});

			builder.Entity<Pizza>().HasData(new Pizza[] {
				new Pizza() { PizzaID = 1, CrustID = 1, SizeID = 1 },
				new Pizza() { PizzaID = 2, CrustID = 2, SizeID = 2 },
				new Pizza() { PizzaID = 3, CrustID = 3, SizeID = 3 }
			});

			builder.Entity<Store>().HasData(new Store[] {
				new Store() { StoreID = 1, Name = "Eat At Joe's", Location = "Albequerque" },
				new Store() { StoreID = 2, Name = "Muggy Pizza", Location = "New York" }
			});

			builder.Entity<User>().HasData(new User[] {
				new User() { UserID = 1, Username = "Tyler", Password = "Cadena" },
				new User() { UserID = 2, Username = "Cody", Password = "Benjamin" },
				new User() { UserID = 3, Username = "Mario", Password = "Mario" }
			});

			builder.Entity<Order>().HasData(new Order[] {
				new Order() { OrderID = 1, StoreID = 1, UserID = 1, Completed = true },
				new Order() { OrderID = 2, StoreID = 2, UserID = 2, Completed = true }
			});
		}
	}
}