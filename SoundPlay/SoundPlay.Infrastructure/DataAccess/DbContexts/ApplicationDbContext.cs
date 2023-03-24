namespace SoundPlay.Infrastructure.DataAccess.DbContexts;

public sealed class ApplicationDbContext : DbContext
{
    public DbSet<Brand> Brands { get; set; }
    public DbSet<GuitarShape> GuitarShapes { get; set; }
    public DbSet<Material> Materials { get; set; }
    public DbSet<TremoloType> TremoloTypes { get; set; }
    public DbSet<Color> Colors { get; set; }
    public DbSet<PickupSet> PickupSets { get; set; }
    public DbSet<Guitar> Guitars { get; set; }
    public DbSet<GuitarCategory> GuitarCategories { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

        modelBuilder.SeedEnumValues<GuitarTag, GuitarCategory>(value => value);
    }
}
