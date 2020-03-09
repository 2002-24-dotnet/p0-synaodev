using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PizzaBox.Domain.Models;

namespace PizzaBox.Storage.Repositories {
	public class UserRepository : ARepository<User> {
		public UserRepository() : base(Context.Users) {

		}
		public override List<User> Get() {
			return Table.Include(u => u.Orders).ToList();
		}
		public override User Get(long ID) {
			return Table.SingleOrDefault(u => u.UserID == ID);
		}
		public User FindByName(string username) {
			return Table.Where(u => u.Username == username).First();
		}
	}
}