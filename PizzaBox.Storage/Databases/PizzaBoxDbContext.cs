using Microsoft.EntityFrameworkCore;
using PizzaBox.Domain.Models;

namespace PizzaBox.Storage.Databases {
	public class PizzaBoxDbContext : DbContext {
		protected override void OnModelCreating(ModelBuilder builder) {
			builder.Entity<Pizza>().HasKey(p => p.ID);
			builder.Entity<Pizza>().HasData(new Pizza[] {
				new Pizza(),
				new Pizza()
			});
		}
		protected override void OnConfiguring(DbContextOptionsBuilder builder) {
			builder.UseSqlServer("server=localhost;database=pizzaboxdb;user id=sa; password=Tj6601Tj?;");
		}
		public DbSet<Pizza> Pizzas { get; set; }
	}
}