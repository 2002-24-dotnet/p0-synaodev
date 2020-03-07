using Xunit;
using PizzaBox.Storage.Singletons;

namespace PizzaBox.Testing.Specs {
	public class PizzaTests {
		[Fact]
		public void Test_RepositoryGet() {
			var pizzeria = PizzeriaSingleton.Instance;
			var actual = pizzeria.GetCrusts();
			Assert.True(actual != null);
			Assert.True(actual.Count >= 0);
		}
		[Fact]
		public void Test_RepositoryPost() {
			var pizzeria = PizzeriaSingleton.Instance;
			var result = pizzeria.PostCrust("Pickled", 2.15M);
			Assert.True(result);
		}
		[Fact]
		public void Test_RepositoryPut() {
			var pizzeria = PizzeriaSingleton.Instance;
			var crusts = pizzeria.GetCrusts();
			var c = crusts.Find(c => c.Name == "Pickled");
			Assert.True(c != null);
			c.Name = "Pockled";
			var result = pizzeria.PutCrust(c);
			Assert.True(result);
		}
		[Fact]
		public void Test_RepositoryDelete() {
			var pizzeria = PizzeriaSingleton.Instance;
			var crusts = pizzeria.GetCrusts();
			var c = crusts.Find(c => c.Name == "Pockled");
			Assert.True(c != null);
			var result = pizzeria.DeleteCrust(c);
			Assert.True(result);
		}
	}
}