using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PizzaBox.Domain.Models;
using PizzaBox.Storage.Databases;

namespace PizzaBox.Storage.Repositories {
	public class PizzaRepository {
		static private readonly PizzaBoxDbContext _db = new PizzaBoxDbContext();
		public PizzaRepository() {

		}
		public List<Pizza> Get() {
			return _db.Pizzas
				.Include(p => p.PizzaID)
				.Include(p => p.Crust)
				.Include(p => p.Size)
				.Include(p => p.Toppings)
			.ToList();
		}
	}
}