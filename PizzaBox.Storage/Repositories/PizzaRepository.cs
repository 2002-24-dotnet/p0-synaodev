using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PizzaBox.Domain.Models;
using PizzaBox.Storage.Databases;

namespace PizzaBox.Storage.Repositories {
	public class PizzaRepository {
		static private readonly PizzaBoxDbContext _db = new PizzaBoxDbContext();
		public List<Pizza> Get() {
			return _db.Pizzas
				.Include(p => p.Crust)
				.Include(p => p.Size)
				.Include(p => p.PizzaToppings)
			.ToList();
		}
		public Pizza Get(long ID) {
			return _db.Pizzas.SingleOrDefault(p => p.PizzaID == ID);
		}
		public bool Post(Pizza pizza) {
			_db.Pizzas.Add(pizza);
			return _db.SaveChanges() == 1;
		}
		public bool Put(Pizza pizza) {
			Pizza p = Get(pizza.PizzaID);
			p = pizza;
			return _db.SaveChanges() == 1;
		}
	}
}