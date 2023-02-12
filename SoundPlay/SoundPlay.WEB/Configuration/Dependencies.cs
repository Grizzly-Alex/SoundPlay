﻿namespace SoundPlay.WEB.Configuration;

public static class Dependencies
{
    public static void ConfigureServices(IConfiguration configuration, IServiceCollection services)
    {
		services.AddHttpContextAccessor();
        services.AddTransient<ExceptionHandlingMiddleware>();
        services.AddControllersWithViews();
        services.AddSingleton(typeof(ILoggerAdapter<>), typeof(LoggerAdapter<>));
        services.AddScoped<IContentManager, ContentManager>();
        services.AddAutoMapper(typeof(MappingProfile));
		services.AddSession(options => { options.IdleTimeout = TimeSpan.FromMinutes(10);
            options.Cookie.HttpOnly = true;
            options.Cookie.IsEssential = true; });
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("CatalogConnection")));

        #region Model CRUD services
        services.AddTransient<IUnitOfWork, UnitOfWork>();
        services.AddTransient(typeof(IEntityService<,>), typeof(EntityService<,>));
		services.AddTransient<IEntityService <Guitar, GuitarViewModel>, GuitarService>();
		services.AddTransient<ICatalogService, CatalogService>();
        services.AddTransient<IRepresentationService, RepresentationService>();
        #endregion
    }
}