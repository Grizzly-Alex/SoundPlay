namespace SoundPlay.Infrastructure.DataAccess.DbContexts;

public sealed class ShoppingDbContext : DbContext
{

    public ShoppingDbContext(DbContextOptions<ShoppingDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ShoppingDbContext).Assembly);
    }
}
