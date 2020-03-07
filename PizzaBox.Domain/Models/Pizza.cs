using System;
using System.Collections.Generic;
using System.Linq;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models {
	public class Pizza : AModel {
		public long PizzaID { get; set; }
		public string Name { get; set; }
		public decimal Price {
			get {
				if (Crust == null || Size == null || PizzaToppings == null) {
					return 0;
				}
				return Crust.Price + Size.Price + PizzaToppings.Sum(t => t.Topping.Price);
			}
		}
		#region NAVIGATIONAL PROPERTIES
		public Crust Crust { get; set; }
		public Size Size { get; set; }
		public List<PizzaTopping> PizzaToppings { get; set; }
		#endregion
		public Pizza() {
			PizzaID = DateTime.Now.Ticks;
		}
		public override long GetID() {
			return PizzaID;
		}
		public override string ToString() {
			string topping_names = "";
			if (PizzaToppings != null) {
				foreach (PizzaTopping t in PizzaToppings) {
					topping_names += (t.Topping.Name + " ");
				}
			}
			return $"{PizzaID} {Name ?? "N/A"} {Price} {Crust.Name ?? "N/A"} {Size.Name ?? "N/A"} {topping_names}";
		}
	}
}