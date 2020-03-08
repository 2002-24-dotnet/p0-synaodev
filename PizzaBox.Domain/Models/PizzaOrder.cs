
namespace PizzaBox.Domain.Models {
	public class PizzaOrder {
		public long PizzaID { get; set; }
		public Pizza Pizza { get; set; }
		public long OrderID { get; set; }
		public Order Order { get; set; }
	}
}