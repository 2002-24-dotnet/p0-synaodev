using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PizzaBox.Domain.Models;

namespace PizzaBox.Storage.Repositories {
	public class ToppingRepository : ARepository<Topping> {
		public ToppingRepository() : base(Context.Toppings) {

		}
		public override List<Topping> Get() {
			return Table.Include(t => t.PizzaToppings).ToList();
		}
		public override Topping Get(long ID) {
			return Table.SingleOrDefault(t => t.ToppingID == ID);
		}
	}
}