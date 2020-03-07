using System;
using PizzaBox.Storage.Singletons;

namespace PizzaBox.Client {
	internal class Program {
		private static readonly PizzeriaSingleton _ps = PizzeriaSingleton.Instance;
		private static void GetAllPizzas() {
			foreach (var p in _ps.GetPizzas()) {
				Console.WriteLine(p);
			}
		}
		private static void Main(string[] args) {
			GetAllPizzas();
		}
	}
}
