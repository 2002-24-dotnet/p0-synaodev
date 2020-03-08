using System;
using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models {
	public class Order : AModel {
		public long OrderID { get; set; }
		public List<PizzaOrder> PizzaOrders { get; set; }
		public long UserID { get; set; }
		public long StoreID { get; set; }
		#region NAVIGATIONAL PROPERTIES
		public User User { get; set; }
		public Store Store { get; set; }
		#endregion
		public Order() {
			OrderID = DateTime.Now.Ticks;
		}
		public override long GetID() {
			return OrderID;
		}
	}
}