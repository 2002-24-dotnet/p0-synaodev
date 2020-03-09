using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PizzaBox.Domain.Models;

namespace PizzaBox.Storage.Repositories {
	public class CrustRepository : ARepository<Crust> {
		public CrustRepository() : base(Context.Crusts) {
			
		}
		public override List<Crust> Get() {
			return Table.Include(c => c.Pizzas).ToList();
		}
		public override Crust Get(long ID) {
			return Table.SingleOrDefault(c => c.CrustID == ID);
		}
	}
}