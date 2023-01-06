using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SoundPlay.DAL.Data;


namespace SoundPlay.DAL
{
	public static class Dependencies
	{
		public static void ConfigureServices(IConfiguration configuration, IServiceCollection services)
		{
			services.AddDbContext<ApplicationDbContext>(context =>
			context.UseSqlServer(configuration.GetConnectionString("CatalogConnection")));
		}
	}
}
