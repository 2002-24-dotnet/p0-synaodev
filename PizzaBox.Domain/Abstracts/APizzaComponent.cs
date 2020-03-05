
using PizzaBox.Domain.Models;

namespace PizzaBox.Domain.Abstracts {
	public abstract class APizzaComponent {
		public decimal Price { get; set; }
		public string Name { get; set; }
		#region NAVIGATIONAL PROPERTIES
		public virtual long PizzaID { get; set; }
		public virtual Pizza Pizza { get; set; }
		#endregion
	}
}