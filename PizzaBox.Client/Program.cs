using System;
using System.Collections.Generic;
using PizzaBox.Domain.Models;
using PizzaBox.Storage.Singletons;

namespace PizzaBox.Client {
	internal class Program {
		private static readonly PizzeriaChain _pc = PizzeriaChain.Instance;
		private static void Main(string[] args) {
			Console.WriteLine("Welcome to Tyler's Pizzaria!");
			while (true) {
				Console.WriteLine("Do you have a user account? (y/n)");
				if (Console.ReadKey().Key == ConsoleKey.Y) {
					User user = Login();
					if (user != null) {
						WhichStore(user);
					}
				}
				Console.WriteLine("Would you like to register a new account? (y/n)");
				if (Console.ReadKey().Key == ConsoleKey.Y) {
					User user = Register();
					if (user != null) {
						WhichStore(user);
					}
				}
				Console.WriteLine("Would you like to quit? (y/n)");
				if (Console.ReadKey().Key == ConsoleKey.Y) {
					break;
				}
				Console.Clear();
			}
			Console.WriteLine("Goodbye!");
		}
		private static User Login() {
			Console.WriteLine("Beginning login...");
			Console.WriteLine("Please enter your username: ");
			string username = Console.ReadLine();
			User user = _pc.FindUserByName(username);
			if (user == null) {
				Console.WriteLine("A user with that username doesn't exist!");
				return null;
			}
			Console.WriteLine("Please enter your password: ");
			string password = Console.ReadLine();
			if (user.Password != password) {
				Console.WriteLine("Password is incorrect!");
				return null;
			}
			return user;
		}
		private static User Register() {
			Console.WriteLine("Beginning registration...");
			Console.WriteLine("Please enter your username: ");
			string username = Console.ReadLine();
			if (username.Length < 8) {
				Console.WriteLine("Usernames should be at least eight characters long!");
				return null;
			}
			User ensure = _pc.FindUserByName(username);
			if (ensure != null) {
				Console.WriteLine("A user with this username already exists!");
				return null;
			}
			Console.WriteLine("Please enter your password: ");
			string password = Console.ReadLine();
			if (password.Length < 8) {
				Console.WriteLine("Passwords should be at least eight characters long!");
				return null;
			}
			if (!_pc.PostUser(username, password)) {
				Console.WriteLine("Registration failed for unknown reason!");
				return null;
			}
			Console.WriteLine("Registration successful!");
			return _pc.FindUserByName(username);
		}
		private static void PrintAllPizzas(List<Pizza> pizzas) {
			for (int i = 0; i < pizzas.Count; ++i) {
				Pizza p = pizzas[i];
				Console.WriteLine("{0}: {1}", i + 1, p.ToString());
			}
		}
		private static void PrintAllStores(List<Store> stores) {
			for (int i = 0; i < stores.Count; ++i) {
				Store s = stores[i];
				Console.WriteLine("{0}: {1} at {2}", i + 1, s.Name, s.Location);
			}
		}
		private static bool MakeOrder(User user, Store store, List<Pizza> pizzas) {
			Console.Clear();
			Console.WriteLine("Here is your order...\n");
			Console.WriteLine("User: {0}\nStore: {1} at {2}\nPizzas: ", user.Username, store.Name, store.Location);
			PrintAllPizzas(pizzas);
			Console.WriteLine("Is this all correct? (y/n)");
			if (Console.ReadKey().Key != ConsoleKey.Y) {
				Console.WriteLine("Never mind...");
				return false;
			}
			DateTime datetime = DateTime.Now;
			if (!_pc.PostOrder(user, store, datetime, pizzas)) {
				Console.WriteLine("Error! Something went wrong when sending the order!");
				Console.WriteLine("Canceling order...");
				return false;
			}
			Console.WriteLine("Order successful!");
			return true;
		}
		private static bool WhichPizza(User user, Store store) {
			List<Pizza> pizza_list = _pc.GetPizzas();
			List<Pizza> ordering = new List<Pizza>();
			int index = 0;
			Console.Clear();
			while (ordering.Count < 50) {
				Console.WriteLine("You have {0} pizzas. Would you like to add one? (y/n)", ordering.Count);
				if (Console.ReadKey().Key != ConsoleKey.Y) {
					break;
				}
				Console.Clear();
				PrintAllPizzas(pizza_list);
				Console.WriteLine("Which pizza do you want? (#): ");
				if (!int.TryParse(Console.ReadLine(), out index)) {
					Console.WriteLine("This isn't a number...");
				} else if (index < 1 || index > pizza_list.Count) {
					Console.WriteLine("That number isn't on the list!");
				} else {
					Pizza pizza = pizza_list[index - 1];
					ordering.Add(pizza);
				}
			}
			if (ordering.Count == 0) {
				Console.WriteLine("Canceling order...");
				return false;
			}
			if (!MakeOrder(user, store, ordering)) {
				return false;
			}
			return true;
		}
		private static bool BeenTwoHours(User user, Store store) {
			DateTime now = DateTime.Now;
			if (user.Orders.Count == 0) {
				return true;
			}
			Order order = user.Orders[user.Orders.Count - 1];
			if (now.Subtract(order.DateTime) >= TimeSpan.FromHours(2.0)) {
				return true;
			}
			if (!order.Store.Equals(store)) {
				return true;
			}
			Console.WriteLine("You can't order twice from the same store until two hours have passed since your last!");
			return false;
		} 
		private static void WhichStore(User user) {
			List<Store> stores = _pc.GetStores();
			int index = 0;
			while (true) {
				Console.Clear();
				PrintAllStores(stores);
				Console.WriteLine("Which store is closest for you? (#): ");
				if (!int.TryParse(Console.ReadLine(), out index)) {
					Console.WriteLine("This isn't a number...");
				} else if (index < 1 || index > stores.Count) {
					Console.WriteLine("That number isn't on the list!");
				} else {
					Store store = stores[index - 1];
					if (!BeenTwoHours(user, store)) {
						Console.WriteLine("Would you like to select another store?");
						if (Console.ReadKey().Key != ConsoleKey.Y) {
							index = 0;
							break;
						}
					} else if (!WhichPizza(user, store)) {
						Console.WriteLine("Would you like try again? (y/n)");
						if (Console.ReadKey().Key != ConsoleKey.Y) {
							index = 0;
							break;
						}
					} else {
						Console.WriteLine("Would you like to make another order? (y/n)");
						if (Console.ReadKey().Key != ConsoleKey.Y) {
							index = 0;
							break;
						}
					}
				}
			}
		}
	}
}
