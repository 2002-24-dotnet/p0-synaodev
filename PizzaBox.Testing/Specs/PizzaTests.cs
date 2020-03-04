using Xunit;
using PizzaBox.Domain.Models;
using PizzaBox.Storage.Repositories;

namespace PizzaBox.Testing.Specs {
	public class PizzaTests {
		[Fact]
		public void Test_RepositoryGet() {
			var sut = new PizzaRepository();
			var actual = sut.GetPizzas();
			Assert.True(actual != null);
			Assert.True(actual.Count >= 0);
		}
	}
}