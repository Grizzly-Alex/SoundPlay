namespace SoundPlay.Infrastructure.DataAccess.DbContexts;

public class IdentityAppDbContext : IdentityDbContext
{
    public IdentityAppDbContext(DbContextOptions<IdentityAppDbContext> options) : base(options) { }

}
