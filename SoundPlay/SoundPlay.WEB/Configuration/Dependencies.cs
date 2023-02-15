using ILogger = Serilog.ILogger;

namespace SoundPlay.WEB.Configuration;

public static class Dependencies
{
    public static ILogger SetLogger(IConfiguration configuration, ILoggingBuilder logging)
    {
        var logger = new LoggerConfiguration()
            .ReadFrom.Configuration(configuration)
            .CreateLogger();
        logging.ClearProviders();
        logging.AddSerilog(logger);

        return logger;
    }

    public static void SetDbContext(IConfiguration configuration, IServiceCollection services)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("CatalogConnection")));
    }

    public static void SetServices(IServiceCollection services)
    {
        services.AddHttpContextAccessor();
        services.AddTransient<ExceptionHandlingMiddleware>();
        services.AddControllersWithViews();
        services.AddScoped<IContentManager, ContentManager>();
        services.AddAutoMapper(typeof(MappingProfile));
        services.AddSession(options => {
            options.IdleTimeout = TimeSpan.FromMinutes(10);
            options.Cookie.HttpOnly = true;
            options.Cookie.IsEssential = true;
        });


        #region Model CRUD services

        services.AddTransient<IUnitOfWork, UnitOfWork>();
        services.AddTransient(typeof(IEntityService<,>), typeof(EntityService<,>));
        services.AddTransient<IEntityService<Guitar, GuitarViewModel>, GuitarService>();
        services.AddTransient<ICatalogService, CatalogService>();
        services.AddTransient<IRepresentationService, RepresentationService>();

        #endregion
    }

    public static void SetMiddleware(WebApplication app)
    {
        #region Middleware

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseRouting();
        app.UseAuthorization();
        app.UseAuthorization();
        app.MapRazorPages();
        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.UseMiddleware<ExceptionHandlingMiddleware>();

        #endregion
    }
}