namespace SoundPlay.DAL.Data;

public sealed class ApplicationDbContext : DbContext
{
	public DbSet<Category> Categories { get; set; }
	public DbSet<Brand> Brands { get; set; }
	public DbSet<GuitarShape> GuitarShapes { get; set; }
	public DbSet<Material> Materials { get; set; }
	public DbSet<TremoloType> TremoloTypes { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<PickupSet> PickupSets { get; set; }
        public DbSet<Guitar> Guitars { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);

		foreach (var foreignKey in modelBuilder.Model.GetEntityTypes()
			.SelectMany(e => e.GetForeignKeys()))
		{
			foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
		}
	}
}
