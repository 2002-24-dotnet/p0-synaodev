using System;
using PizzaBox.Storage.Repositories;

namespace PizzaBox.Client {
	internal class Program {
		private static readonly PizzaRepository _rp = new PizzaRepository();
		private static void GetAllPizzas() {
			foreach (var p in _rp.Get()) {
				Console.WriteLine(p.PizzaID);
			}
		}
		private static void Main(string[] args) {
			GetAllPizzas();
		}
	}
}
