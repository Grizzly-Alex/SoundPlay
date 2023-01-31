namespace SoundPlay.DAL.Repository;

public sealed class UnitOfWork : IUnitOfWork 
{
    private ApplicationDbContext _db;

	public IRepository<Category> Category { get; }
	public IRepository<Brand> Brand { get; }
	public IRepository<GuitarShape> GuitarShape { get; }
	public IRepository<Material> Material { get; }
	public IRepository<TremoloType> TremoloType { get; }
	public IRepository<Color> Color { get; }
	public IRepository<PickupSet> PickupSet { get; }
	public IRepository<Guitar> Guitar { get; }

	public UnitOfWork(ApplicationDbContext db)
	{
		_db = db;
		Category = new Repository<Category>(_db);
		Brand = new Repository<Brand>(_db);
		GuitarShape = new Repository<GuitarShape>(_db);
		Material = new Repository<Material>(_db);
		TremoloType = new Repository<TremoloType>(_db);
		Color = new Repository<Color>(_db);
		PickupSet = new Repository<PickupSet>(_db);
		Guitar = new Repository<Guitar>(_db);
	}

	public async Task SaveChangesAsync() => await _db.SaveChangesAsync();

	public  IRepository<T> GetRepository<T>() where T : Entity => new Repository<T>(_db);
}