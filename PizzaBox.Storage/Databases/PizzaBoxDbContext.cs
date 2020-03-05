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

			builder.Entity<Pizza>().HasData(new Pizza());
			builder.Entity<Crust>().HasData(new Crust() { CrustID = 1, PizzaID = 1 });
			builder.Entity<Size>().HasData(new Size() { SizeID = 1, PizzaID = 1 });
			builder.Entity<Topping>().HasData(new Topping() { ToppingID = 1, PizzaID = 1 });
		}
	}
}