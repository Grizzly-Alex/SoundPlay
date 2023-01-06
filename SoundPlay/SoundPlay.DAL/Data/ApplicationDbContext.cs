using Microsoft.EntityFrameworkCore;

namespace SoundPlay.DAL.Data
{
	public sealed class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{
		}
	}
}
