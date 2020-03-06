using System;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models {
	public class Crust : APizzaComponent {
		public long CrustID { get; set; }
		public Crust() {
			CrustID = DateTime.Now.Ticks;
		}
	}
}