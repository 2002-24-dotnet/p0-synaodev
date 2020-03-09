using System; 
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
		private readonly UserRepository _ur = new UserRepository();
		private readonly OrderRepository _or = new OrderRepository();
		private readonly StoreRepository _rr = new StoreRepository();
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
		public List<User> GetUsers() {
			return _ur.Get();
		}
		public List<Order> GetOrders() {
			return _or.Get();
		}
		public List<Store> GetStores() {
			return _rr.Get();
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
		public User GetUser(long ID) {
			return _ur.Get(ID);
		}
		public Order GetOrder(long ID) {
			return _or.Get(ID);
		}
		public Store GetStore(long ID) {
			return _rr.Get(ID);
		}
		// POST
		public bool PostPizza(Crust crust, Size size, List<Topping> toppings) {
			Pizza p = new Pizza() {
				Crust = crust,
				Size = size,
				PizzaToppings = new List<PizzaTopping>()
			};
			foreach (Topping t in toppings) {
				p.PizzaToppings.Add(new PizzaTopping() {
					Pizza = p,
					Topping = t
				});
			}
			return _pr.Post(p);
		}
		public bool PostCrust(string name, decimal price) {
			Crust c = new Crust() {
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
		public bool PostUser(string first_name, string last_name) {
			User u = new User() {
				FirstName = first_name,
				LastName = last_name
			};
			return _ur.Post(u);
		}
		public bool PostOrder(User user, Store store, DateTime datetime, List<Pizza> pizzas) {
			Order o = new Order() {
				User = user,
				Store = store,
				DateTime = datetime,
				OrderPizzas = new List<OrderPizza>()
			};
			foreach (Pizza p in pizzas) {
				o.OrderPizzas.Add(new OrderPizza() {
					Order = o,
					Pizza = p
				});
			}
			return _or.Post(o);
		}
		public bool PostStore(string name, string location) {
			Store r = new Store() {
				Name = name,
				Location = location
			};
			return _rr.Post(r);
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
		public bool PutUser(User u) {
			return _ur.Put(u);
		}
		public bool PutOrder(Order o) {
			return _or.Put(o);
		}
		public bool PutStore(Store s) {
			return _rr.Put(s);
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
		public bool DeleteUser(User u) {
			return _ur.Delete(u);
		}
		public bool DeleteOrder(Order o) {
			return _or.Delete(o);
		}
		public bool DeleteStore(Store s) {
			return _rr.Delete(s);
		}
	}
}