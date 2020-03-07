using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PizzaBox.Domain.Models;

namespace PizzaBox.Storage.Repositories {
	public class PizzaRepository : ARepository<Pizza> {
		public override List<Pizza> Get() {
			return Table
				.Include(p => p.Crust)
				.Include(p => p.Size)
				.Include(p => p.PizzaToppings)
			.ToList();
		}
		public PizzaRepository() : base(Context.Pizzas) {

		}
		/*public Pizza Get(long ID) {
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
		}*/
	}
}