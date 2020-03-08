using System;
using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models {
	public class User : AModel {
		public long UserID { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public List<Order> Orders { get; set; }
		public User() {
			UserID = DateTime.Now.Ticks;
		}
		public override long GetID() {
			return UserID;
		}
	}
}