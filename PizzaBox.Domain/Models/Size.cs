using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models {
	public class Size : APizzaComponent {
		public long SizeID { get; set; }
		public Size() {
			SizeID = 1;
		}
	}
}