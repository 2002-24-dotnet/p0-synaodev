using System;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models {
	public class PizzaTopping {
		public long PizzaID { get; set; }
		public Pizza Pizza { get; set; }
		public long ToppingID { get; set; }
		public Topping Topping { get; set; }
	}
}