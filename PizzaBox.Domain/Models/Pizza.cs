using System;
using System.Collections.Generic;
using System.Linq;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models {
	public class Pizza : AModel {
		public long PizzaID { get; set; }
		public decimal Price {
			get {
				if (Crust == null || Size == null || PizzaToppings == null) {
					return 0;
				}
				return Crust.Price + Size.Price + PizzaToppings.Sum(t => t.Topping.Price);
			}
		}
		public long CrustID { get; set; }
		public long SizeID { get; set; }
		#region NAVIGATIONAL PROPERTIES
		public Crust Crust { get; set; }
		public Size Size { get; set; }
		public List<PizzaTopping> PizzaToppings { get; set; }
		public List<PizzaOrder> PizzaOrders { get; set; }
		#endregion
		public Pizza() {
			PizzaID = DateTime.Now.Ticks;
		}
		public override long GetID() {
			return PizzaID;
		}
	}
}