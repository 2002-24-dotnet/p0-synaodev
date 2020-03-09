using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PizzaBox.Domain.Models;

namespace PizzaBox.Storage.Repositories {
	public class OrderRepository : ARepository<Order> {
		public OrderRepository() : base(Context.Orders) {

		}
		public override List<Order> Get() {
			return Table
				.Include(o => o.OrderPizzas)
				.Include(o => o.User)
				.Include(o => o.Store)
			.ToList();
		}
		public override Order Get(long ID) {
			return Table.SingleOrDefault(o => o.OrderID == ID);
		}
	}
}