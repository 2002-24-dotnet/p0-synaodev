using System;
using System.Collections.Generic;

namespace PizzaBox.Domain.Models {
	public class Pizza {
		public long PizzaID { get; set; }
		public string Name { get; set; }
		#region NAVIGATIONAL PROPERTIES
		public Crust Crust { get; set; }
		public Size Size { get; set; }
		public List<Topping> Toppings { get; set; }
		#endregion
		public decimal Price {
			get {
				if (Crust == null || Size == null || Toppings == null) {
					return 0;
				}
				decimal _price = Crust.Price + Size.Price;
				foreach (var t in Toppings) {
					_price += t.Price;
				}
				return _price;
			}
		}
		public override string ToString() {
			string topping_names = "";
			if (Toppings != null) {
				foreach (Topping t in Toppings) {
					topping_names += t.Name;
				}
			}
			return $"{PizzaID} {Name ?? "N/A"} {Price} {Crust.Name ?? "N/A"} {Size.Name ?? "N/A"} {topping_names}";
		}
		public Pizza() {
			PizzaID = DateTime.Now.Ticks;
			Name = "N/A";
		}
	}
}