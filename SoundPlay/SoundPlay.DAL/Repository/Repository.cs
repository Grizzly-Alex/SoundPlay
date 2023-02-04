namespace SoundPlay.DAL.Repository;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
{
	protected readonly ApplicationDbContext _dbContext;
	private readonly DbSet<TEntity> _dbSet;

	public Repository(ApplicationDbContext dbContext)
	{
		_dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
		_dbSet = _dbContext.Set<TEntity>();	
	}

	public void Add(TEntity entity) => _dbSet.Add(entity);	

	public void Add(IEnumerable<TEntity> entities) => _dbSet.AddRange(entities);

	public void Remove(TEntity entity) => _dbSet.Remove(entity);

	public void Remove(IEnumerable<TEntity> entities) => _dbSet.AddRange(entities);

	public void Update(TEntity entity) => _dbSet.Update(entity);	

	public void Update(IEnumerable<TEntity> entities) => _dbSet.UpdateRange(entities);

	public async Task<IList<TEntity>> GetAllAsync(
		Expression<Func<TEntity, bool>>? predicate = null,
		Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
		Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
		bool isTracking = false)
	{
		IQueryable<TEntity> query = _dbSet;	

		if (!isTracking) { query = query.AsNoTracking(); }
		if (include is not null) { query = include(query); }
		if (predicate is not null) { query = query.Where(predicate); }

		return orderBy is not null
			? await orderBy(query).ToListAsync()
			: await query.ToListAsync();
	}

	public async Task<TEntity?> GetFirstOrDefaultAsync(
		Expression<Func<TEntity, bool>>? predicate = null,
		Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
		Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
		bool isTracking = false)
	{
		IQueryable<TEntity> query = _dbSet;

		if (!isTracking) { query = query.AsNoTracking(); }
		if (predicate is not null) { query = query.Where(predicate); }
		if (include is not null) { query = include(query); }

		return orderBy is not null 
			? await orderBy(query).FirstOrDefaultAsync()
			: await query.FirstOrDefaultAsync();
	}

	public async Task<TResult?> GetFirstOrDefaultAsync<TResult>(
		Expression<Func<TEntity, TResult>> selector,
		Expression<Func<TEntity, bool>>? predicate = null,
		Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
		Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
		bool isTracking = true)
	{
		IQueryable<TEntity> query = _dbSet;

		if (!isTracking) { query = query.AsNoTracking(); }
		if (predicate is not null) { query = query.Where(predicate); }
		if (include is not null) { query = include(query); }

		return orderBy is not null
			? await orderBy(query).Select(selector).FirstOrDefaultAsync()
			: await query.Select(selector).FirstOrDefaultAsync();
	}

	public async Task<IList<TResult>> GetAllAsync<TResult>(
		Expression<Func<TEntity, TResult>> selector,
		Expression<Func<TEntity, bool>>? predicate = null,
		Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
		Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
		bool isTracking = false)
	{
		IQueryable<TEntity> query = _dbSet;

		if (!isTracking) { query = query.AsNoTracking(); }
		if (predicate is not null) { query = query.Where(predicate); }
		if (include is not null) { query = include(query); }

		return orderBy is not null
			? await orderBy(query).Select(selector).ToListAsync()
			: await query.Select(selector).ToListAsync();
	}
}
