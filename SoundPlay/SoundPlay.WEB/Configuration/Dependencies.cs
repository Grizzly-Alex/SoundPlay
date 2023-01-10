using Microsoft.EntityFrameworkCore;
using SoundPlay.DAL.Data;
using SoundPlay.DAL.Repository.Interfaces;
using SoundPlay.DAL.Repository;
using SoundPlay.BLL.Models;
using SoundPlay.BLL.Interfaces;
using SoundPlay.BLL.Services;
using SoundPlay.BLL.ViewModels;

namespace SoundPlay.WEB.Configuration
{
    public static class Dependencies
    {
        public static void ConfigureServices(IConfiguration configuration, IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddAutoMapper(typeof(MappingProfile));
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("CatalogConnection")));

            #region Model CRUD services
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IItemService<BrandViewModel>, BrandService>();
            services.AddTransient<IItemService<CategoryViewModel>, CategoryService>();
            services.AddTransient<IItemService<GuitarShapeViewModel>, GuitarShapeService>();
            services.AddTransient<IItemService<MaterialViewModel>, MaterialService>();
            services.AddTransient<IItemService<TremoloTypeViewModel>, TremoloTypeService>();
            #endregion
        }
    }
}