using System;
using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models {
	public class Crust : APizzaComponent {
		public long CrustID { get; set; }
		public List<Pizza> Pizzas { get; set; }
		public Crust() {
			CrustID = DateTime.Now.Ticks;
		}
		public override long GetID() {
			return CrustID;
		}
	}
}