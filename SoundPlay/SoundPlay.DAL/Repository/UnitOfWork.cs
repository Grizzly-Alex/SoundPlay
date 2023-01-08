using SoundPlay.DAL.Data;
using SoundPlay.DAL.Repository.Interfaces;
using SoundPlay.DTO.Models;

namespace SoundPlay.DAL.Repository
{
	public sealed class UnitOfWork : IUnitOfWork
	{
		public Repository<Category> Category { get; private set; }
		public Repository<Brand> Brand { get; private set; }
		public Repository<GuitarShape> GuitarShape { get; private set; }
		public Repository<Material> Material { get; private set; }
		public Repository<TremoloType> TremoloType { get; private set; }

		private ApplicationDbContext _db;

		public UnitOfWork(ApplicationDbContext db)
		{
			_db = db;
			Category = new Repository<Category>(_db);
			Brand = new Repository<Brand>(_db);
			GuitarShape = new Repository<GuitarShape>(_db);
			Material = new Repository<Material>(_db);
			TremoloType = new Repository<TremoloType>(_db);
		}

		public async Task SaveChangesAsync() => await _db.SaveChangesAsync();
	}
}