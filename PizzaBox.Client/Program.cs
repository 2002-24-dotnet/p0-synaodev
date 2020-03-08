using System.Collections.Generic;
using PizzaBox.Domain.Models;
using PizzaBox.Storage.Singletons;

namespace PizzaBox.Client {
	internal class Program {
		private static readonly PizzeriaSingleton _ps = PizzeriaSingleton.Instance;
		private static void Main(string[] args) {
			List<Pizza> pizzas = _ps.GetPizzas();
			foreach (Pizza pizza in pizzas) {
				System.Console.WriteLine(pizza);
			}
		}
	}
}
