using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace SoundPlay.DAL.Repository.Interfaces
{
	public interface IRepository<T> where T : class
	{
		Task<T?> GetFirstOrDefaultAsync(
			Expression<Func<T, bool>>? predicate = null,
			Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
			Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
			bool isTracking = false);
		Task<IList<T>> GetAllAsync(
			Expression<Func<T, bool>>? predicate = null,
			Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
			Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
			bool isTracking = false);
		void Remove(T entity);
		void Remove(IEnumerable<T> entities);
		void Add(T entity);
		void Add(IEnumerable<T> entities);
		void Update(T entity);	
		void Update(IEnumerable<T> entities);
	}
}
