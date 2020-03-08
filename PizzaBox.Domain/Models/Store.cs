using System;
using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models {
	public class Store : AModel {
		public long StoreID { get; set; }
		public string Name { get; set; }
		public string Location { get; set; }
		public List<Order> Orders { get; set; }
		public Store() {
			StoreID = DateTime.Now.Ticks;
		}
		public override long GetID() {
			return StoreID;
		}
	}
}