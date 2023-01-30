namespace SoundPlay.DAL.Repository.Interfaces;

	public interface IUnitOfWork
	{
    public IRepository<Category> Category { get; }
    public IRepository<Brand> Brand { get; }
    public IRepository<GuitarShape> GuitarShape { get; }
    public IRepository<Material> Material { get; }
    public IRepository<TremoloType> TremoloType { get; }
    public IRepository<Color> Color { get; }
    public IRepository<PickupSet> PickupSet { get; }
    public IRepository<Guitar> Guitar { get; }


    public Task SaveChangesAsync();
}