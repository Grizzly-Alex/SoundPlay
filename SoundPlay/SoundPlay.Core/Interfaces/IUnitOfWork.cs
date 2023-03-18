namespace SoundPlay.Core.Interfaces;

public interface IUnitOfWork<TDbContext> where TDbContext : DbContext
{
    public Task SaveChangesAsync();
    public IRepository<TDbContext, TEntity> GetRepository<TEntity>() where TEntity : Entity;
}