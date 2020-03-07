using System.Collections.Generic;

namespace PizzaBox.Storage.Repositories {
	public interface IRepository<T> where T : class {
		List<T> Get();
		T Get(long ID);
		bool Post(T entity);
		bool Put(T entity);
		bool Delete(T entity);
	}
}