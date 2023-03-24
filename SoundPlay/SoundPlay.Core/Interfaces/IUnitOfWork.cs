using SoundPlay.Core.Models.Entities;

namespace SoundPlay.Core.Interfaces;

public interface IUnitOfWork
{
    public Task SaveChangesAsync();
    public IRepository<TModel> GetRepository<TModel>() where TModel : Entity;
}