using Microsoft.EntityFrameworkCore;
using SoundPlay.DAL.Data;
using SoundPlay.DAL.Repository.Interfaces;
using SoundPlay.DAL.Repository;
using SoundPlay.BLL.Interfaces;
using SoundPlay.BLL.Services;
using SoundPlay.BLL.ViewModels;
using SoundPlay.BLL.Utility;

namespace SoundPlay.WEB.Configuration
{
    public static class Dependencies
    {
        public static void ConfigureServices(IConfiguration configuration, IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddSingleton(typeof(ILoggerAdapter<>), typeof(LoggerAdapter<>));
            services.AddAutoMapper(typeof(MappingProfile));
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("CatalogConnection")));

            #region Model CRUD services
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IItemGenericService<CategoryViewModel>, CategoryService>();
            services.AddTransient<IItemGenericService<BrandViewModel>, BrandService>();
            services.AddTransient<IItemGenericService<GuitarShapeViewModel>, GuitarShapeService>();
            services.AddTransient<IItemGenericService<MaterialViewModel>, MaterialService>();
            services.AddTransient<IItemGenericService<TremoloTypeViewModel>, TremoloTypeService>();
            services.AddTransient<IItemGenericService<ColorViewModel>, ColorService>();
            services.AddTransient<IItemGenericService<PickupSetViewModel>, PickupSetService>();
            #endregion
        }
    }
}