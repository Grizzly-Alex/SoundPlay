using SoundPlay.DAL.Models;

namespace SoundPlay.DAL.Repository.Interfaces
{
	public interface IUnitOfWork
	{
        public IRepository<Category> Category { get; }
        public IRepository<Brand> Brand { get; }
        public IRepository<GuitarShape> GuitarShape { get; }
        public IRepository<Material> Material { get; }
        public IRepository<TremoloType> TremoloType { get; }

        public Task SaveChangesAsync();
	}
}