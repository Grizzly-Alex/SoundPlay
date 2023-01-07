using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SoundPlay.DAL.Data;
using SoundPlay.DAL.Repository.Interfaces;
using SoundPlay.DAL.Repository;

namespace SoundPlay.DAL
{
	public static class Dependencies
	{
		public static void ConfigureServices(IConfiguration configuration, IServiceCollection services)
		{
			services.AddDbContext<ApplicationDbContext>(options =>
				options.UseSqlServer(configuration.GetConnectionString("CatalogConnection")));

			services.AddTransient<IUnitOfWork, UnitOfWork>();
		}
	}
}
