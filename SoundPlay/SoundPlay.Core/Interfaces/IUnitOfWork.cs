namespace SoundPlay.Core.Interfaces;

public interface IUnitOfWork
{
    public Task SaveChangesAsync();
    public IRepository<T> GetRepository<T>() where T : Entity;
}