using System.Collections.Generic;
using System.Linq;
using PizzaBox.Domain.Models;
using PizzaBox.Storage.Databases;

namespace PizzaBox.Storage.Repositories {
	public class PizzaRepository {
		static private readonly PizzaBoxDbContext _db = new PizzaBoxDbContext();
		public PizzaRepository() {

		}
		public List<Pizza> Get() {
			return _db.Pizzas.ToList();
		}
	}
}