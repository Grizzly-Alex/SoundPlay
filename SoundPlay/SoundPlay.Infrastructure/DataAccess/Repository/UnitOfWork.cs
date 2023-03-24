namespace SoundPlay.Infrastructure.DataAccess.Repository;

public sealed class UnitOfWork : IUnitOfWork 
{
    private CatalogDbContext _db;

	public UnitOfWork(CatalogDbContext db) => _db = db;

	public async Task SaveChangesAsync() => await _db.SaveChangesAsync();

	public  IRepository<T> GetRepository<T>() where T : Entity => new Repository<T>(_db);
}