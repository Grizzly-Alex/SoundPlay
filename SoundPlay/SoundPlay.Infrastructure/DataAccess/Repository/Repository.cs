namespace SoundPlay.Infrastructure.DataAccess.Repository;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
{
	protected readonly ApplicationDbContext _dbContext;
	private readonly DbSet<TEntity> _dbSet;

	public Repository(ApplicationDbContext dbContext)
	{
		_dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
		_dbSet = _dbContext.Set<TEntity>();
        
    }

	public void Add(TEntity entity)
	{
		_dbSet.Entry(entity).State = EntityState.Added;
    }	

    public void Remove(int id)
    {
		var entity = _dbSet.First(e => e.Id == id);
        _dbSet.Entry(entity).State = EntityState.Deleted;

    }

    public void Update(TEntity entity)
	{
        _dbSet.Entry(entity).State = EntityState.Modified;
    }

	public async Task<IEnumerable<TEntity>> GetAllAsync(
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
		bool isTracking = false)
	{
		IQueryable<TEntity> query = _dbSet;

		if (!isTracking) { query = query.AsNoTracking(); }
		if (predicate is not null) { query = query.Where(predicate); }
		if (include is not null) { query = include(query); }

		return orderBy is not null
			? await orderBy(query).Select(selector).FirstOrDefaultAsync()
			: await query.Select(selector).FirstOrDefaultAsync();
	}

	public async Task<IEnumerable<TResult>> GetAllAsync<TResult>(
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

    public async Task<IPagedList<TResult>> GetPagedListAsync<TResult>(
		Expression<Func<TEntity, TResult>> selector,
		Expression<Func<TEntity, bool>>? predicate = null,
		Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
		Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
		int pageIndex = default,
		int itemsPerPage = int.MaxValue,
		bool isTracking = true,
		CancellationToken cancellationToken = default)
    {
        IQueryable<TEntity> query = _dbSet;

        if (!isTracking) { query = query.AsNoTracking(); }
        if (predicate is not null) { query = query.Where(predicate); }
        if (include is not null) { query = include(query); }

        return orderBy is not null
            ? await orderBy(query).Select(selector).ToPagedListAsync(pageIndex, itemsPerPage, cancellationToken)
            : await query.Select(selector).ToPagedListAsync(pageIndex, itemsPerPage, cancellationToken);
    }

    public async Task<TResult> MaxAsync<TResult>(
		Expression<Func<TEntity, TResult>> selector,
		Expression<Func<TEntity, bool>>? predicate = null,
		CancellationToken cancellationToken = default) =>
		predicate is null
			? await _dbSet.MaxAsync(selector, cancellationToken)
			: await _dbSet.Where(predicate).MaxAsync(selector, cancellationToken);

    public async Task<TResult> MinAsync<TResult>(
		Expression<Func<TEntity, TResult>> selector,
		Expression<Func<TEntity, bool>>? predicate = null,
		CancellationToken cancellationToken = default) =>
		predicate is null
			? await _dbSet.MinAsync(selector, cancellationToken)
			: await _dbSet.Where(predicate).MinAsync(selector, cancellationToken);

    public async Task<int> CountAsync(
        Expression<Func<TEntity, bool>>? predicate = null,
        CancellationToken cancellationToken = default) =>
        predicate is null
            ? await _dbSet.CountAsync(cancellationToken)
            : await _dbSet.CountAsync(predicate, cancellationToken);
}
