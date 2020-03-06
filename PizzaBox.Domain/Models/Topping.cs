using System;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models {
	public class Topping : APizzaComponent {
		public long ToppingID { get; set; }
		public Topping() {
			ToppingID = DateTime.Now.Ticks;
		}
	}
}