namespace SoundPlay.DAL.Repository;

public class Repository<T> : IRepository<T> where T : Entity
{
	protected readonly ApplicationDbContext _dbContext;
	private readonly DbSet<T> _dbSet;

	public Repository(ApplicationDbContext dbContext)
	{
		_dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
		_dbSet = _dbContext.Set<T>();	
	}

	public void Add(T entity) => _dbSet.Add(entity);	

	public void Add(IEnumerable<T> entities) => _dbSet.AddRange(entities);

	public void Remove(T entity) => _dbSet.Remove(entity);

	public void Remove(IEnumerable<T> entities) => _dbSet.AddRange(entities);

	public void Update(T entity) => _dbSet.Update(entity);	

	public void Update(IEnumerable<T> entities) => _dbSet.UpdateRange(entities);

	public async Task<IList<T>> GetAllAsync(
		Expression<Func<T, bool>>? predicate = null,
		Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
		Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
		bool isTracking = false)
	{
		IQueryable<T> query = _dbSet;	

		if (!isTracking) { query = query.AsNoTracking(); }
		if (include is not null) { query = include(query); }
		if (predicate is not null) { query = query.Where(predicate); }

		return orderBy is not null
			? await orderBy(query).ToListAsync()
			: await query.ToListAsync();
	}

	public async Task<T?> GetFirstOrDefaultAsync(
		Expression<Func<T, bool>>? predicate = null,
		Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
		Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
		bool isTracking = false)
	{
		IQueryable<T> query = _dbSet;

		if (!isTracking) { query = query.AsNoTracking(); }
		if (predicate is not null) { query = query.Where(predicate); }
		if (include is not null) { query = include(query); }

		return orderBy is not null 
			? await orderBy(query).FirstOrDefaultAsync()
			: await query.FirstOrDefaultAsync();
	}
}
