namespace SoundPlay.Infrastructure.DataAccess.Repository;

public sealed class UnitOfWork : IUnitOfWork 
{
    private ApplicationDbContext _db;

	public UnitOfWork(ApplicationDbContext db) => _db = db;

	public async Task SaveChangesAsync() => await _db.SaveChangesAsync();

	public  IRepository<T> GetRepository<T>() where T : Entity => new Repository<T>(_db);
}