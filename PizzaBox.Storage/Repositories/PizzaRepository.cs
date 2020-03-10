using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PizzaBox.Domain.Models;

namespace PizzaBox.Storage.Repositories {
	public class PizzaRepository : ARepository<Pizza> {
		public PizzaRepository() : base(Context.Pizzas) {

		}
		public override List<Pizza> Get() {
			return Table
				.Include(p => p.Crust)
				.Include(p => p.Size)
				.Include(p => p.PizzaToppings)
				.ThenInclude(pt => pt.Topping)
			.ToList();
		}
		public override Pizza Get(long ID) {
			return Table.SingleOrDefault(p => p.PizzaID == ID);
		}
	}
}