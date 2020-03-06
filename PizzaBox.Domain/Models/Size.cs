using System;
using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models {
	public class Size : APizzaComponent {
		public long SizeID { get; set; }
		public List<Pizza> Pizzas { get; set; }
		public Size() {
			SizeID = DateTime.Now.Ticks;
		}
	}
}