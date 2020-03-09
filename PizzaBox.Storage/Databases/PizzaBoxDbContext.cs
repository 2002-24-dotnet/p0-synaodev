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
			//builder.Entity<Pizza>().Property(p => p.CrustID).ValueGeneratedNever();
			//builder.Entity<Pizza>().Property(p => p.SizeID).ValueGeneratedNever();

			builder.Entity<Size>().HasKey(s => s.SizeID);
			builder.Entity<Size>().Property(s => s.SizeID).ValueGeneratedNever();

			builder.Entity<Topping>().HasKey(t => t.ToppingID);
			builder.Entity<Topping>().Property(t => t.ToppingID).ValueGeneratedNever();

			builder.Entity<User>().HasKey(u => u.UserID);
			builder.Entity<User>().Property(u => u.UserID).ValueGeneratedNever();

			builder.Entity<Order>().HasKey(o => o.OrderID);
			builder.Entity<Order>().Property(o => o.OrderID).ValueGeneratedNever();
			//builder.Entity<Order>().Property(o => o.StoreID).ValueGeneratedNever();
			//builder.Entity<Order>().Property(o => o.UserID).ValueGeneratedNever();

			builder.Entity<Store>().HasKey(r => r.StoreID);
			builder.Entity<Store>().Property(r => r.StoreID).ValueGeneratedNever();

			builder.Entity<Crust>().HasMany(c => c.Pizzas).WithOne(p => p.Crust).HasForeignKey(p => p.CrustID);
			builder.Entity<Size>().HasMany(s => s.Pizzas).WithOne(p => p.Size).HasForeignKey(p => p.SizeID);
			builder.Entity<User>().HasMany(u => u.Orders).WithOne(o => o.User).HasForeignKey(o => o.UserID);
			builder.Entity<Store>().HasMany(r => r.Orders).WithOne(o => o.Store).HasForeignKey(r => r.StoreID);

			builder.Entity<Pizza>().HasMany(p => p.PizzaToppings).WithOne(pt => pt.Pizza).HasForeignKey(pt => pt.PizzaID);
			builder.Entity<Topping>().HasMany(t => t.PizzaToppings).WithOne(pt => pt.Topping).HasForeignKey(pt => pt.ToppingID);
			builder.Entity<Pizza>().HasMany(p => p.OrderPizzas).WithOne(po => po.Pizza).HasForeignKey(po => po.PizzaID);
			builder.Entity<Order>().HasMany(o => o.OrderPizzas).WithOne(po => po.Order).HasForeignKey(po => po.OrderID);

			builder.Entity<PizzaTopping>().HasKey(pt => new { pt.PizzaID, pt.ToppingID });
			//builder.Entity<PizzaTopping>().Property(pt => pt.PizzaID).ValueGeneratedNever();
			//builder.Entity<PizzaTopping>().Property(pt => pt.ToppingID).ValueGeneratedNever();
			builder.Entity<OrderPizza>().HasKey(po => new { po.PizzaID, po.OrderID });
			//builder.Entity<OrderPizza>().Property(po => po.OrderID).ValueGeneratedNever();
			//builder.Entity<OrderPizza>().Property(po => po.PizzaID).ValueGeneratedNever();
			builder.Entity<PizzaTopping>().HasOne(pt => pt.Pizza).WithMany(p => p.PizzaToppings).HasForeignKey(p => p.PizzaID);
			builder.Entity<PizzaTopping>().HasOne(pt => pt.Topping).WithMany(t => t.PizzaToppings).HasForeignKey(t => t.ToppingID);
			builder.Entity<OrderPizza>().HasOne(op => op.Order).WithMany(o => o.OrderPizzas).HasForeignKey(o => o.OrderID);
			builder.Entity<OrderPizza>().HasOne(op => op.Pizza).WithMany(p => p.OrderPizzas).HasForeignKey(p => p.PizzaID);

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
				new Topping() { Name = "Cheese", Price = 0.25M },
				new Topping() { Name = "Tomato Sauce", Price = 0.75M },
				new Topping() { Name = "Pepperoni", Price = 0.50M },
				new Topping() { Name = "Bacon", Price = 0.45M },
				new Topping() { Name = "Anchovies", Price = 1.00M }
			});

			builder.Entity<Pizza>().HasData(new Pizza[] {
				new Pizza() { CrustID = 1, SizeID = 1 },
				new Pizza() { CrustID = 2, SizeID = 2 },
				new Pizza() { CrustID = 3, SizeID = 3 }
			});

			builder.Entity<Store>().HasData(new Store[] {
				new Store() { Name = "Eat At Joe's", Location = "Albequerque" },
				new Store() { Name = "Muggy Pizza", Location = "New York" }
			});

			builder.Entity<User>().HasData(new User[] {
				new User() { Username = "Tyler", Password = "Cadena" },
				new User() { Username = "Cody", Password = "Benjamin" },
				new User() { Username = "Mario", Password = "Mario" }
			});

			/*builder.Entity<Order>().HasData(new Order[] {
				new Order() { OrderID = 1, StoreID = 1, UserID = 1, Completed = true },
				new Order() { OrderID = 2, StoreID = 2, UserID = 2, Completed = true }
			});*/
		}
	}
}