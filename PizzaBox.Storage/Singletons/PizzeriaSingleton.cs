using System.Collections.Generic;
using PizzaBox.Domain.Models;
using PizzaBox.Storage.Repositories;

namespace PizzaBox.Storage.Singletons {
	public class PizzeriaSingleton {
		private PizzeriaSingleton() {}
		private static readonly PizzeriaSingleton _ps = new PizzeriaSingleton();
		public static PizzeriaSingleton Instance {
			get { return _ps; }
		}
		private readonly PizzaRepository _pr = new PizzaRepository();
		private readonly CrustRepository _cr = new CrustRepository();
		private readonly SizeRepository _sr = new SizeRepository();
		private readonly ToppingRepository _tr = new ToppingRepository();
		// GET ALL
		public List<Pizza> GetPizzas() {
			return _pr.Get();
		}
		public List<Crust> GetCrusts() {
			return _cr.Get();
		}
		public List<Size> GetSizes() {
			return _sr.Get();
		}
		public List<Topping> GetToppings() {
			return _tr.Get();
		}
		// GET ONE
		public Pizza GetPizza(long ID) {
			return _pr.Get(ID);
		}
		public Crust GetCrust(long ID) {
			return _cr.Get(ID);
		}
		public Size GetSize(long ID) {
			return _sr.Get(ID);
		}
		public Topping GetTopping(long ID) {
			return _tr.Get(ID);
		}
		// POST
		public bool PostPizza(Crust crust, Size size, List<Topping> toppings) {
			Pizza p = new Pizza() {
				Crust = crust,
				Size = size,
				// Toppings?
			};
			return _pr.Post(p);
		}
		public bool PostCrust(string name, decimal price) {
			Crust c = new Crust () {
				Name = name,
				Price = price
			};
			return _cr.Post(c);
		}
		public bool PostSize(string name, decimal price) {
			Size s = new Size() {
				Name = name,
				Price = price
			};
			return _sr.Post(s);
		}
		public bool PostTopping(string name, decimal price) {
			Topping t = new Topping() {
				Name = name,
				Price = price
			};
			return _tr.Post(t);
		}
		// PUT
		public bool PutPizza(Pizza p) {
			return _pr.Put(p);
		}
		public bool PutCrust(Crust c) {
			return _cr.Put(c);
		}
		public bool PutSize(Size s) {
			return _sr.Put(s);
		}
		public bool PutTopping(Topping t) {
			return _tr.Put(t);
		}
		// DELETE
		public bool DeletePizza(Pizza p) {
			return _pr.Delete(p);
		}
		public bool DeleteCrust(Crust c) {
			return _cr.Delete(c);
		}
		public bool DeleteSize(Size s) {
			return _sr.Delete(s);
		}
		public bool DeleteTopping(Topping t) {
			return _tr.Delete(t);
		}
	}
}