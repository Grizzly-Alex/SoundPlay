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
        { 
            options.UseSqlServer(configuration.GetConnectionString("CatalogConnection")); 
            options.EnableSensitiveDataLogging();
        });

        services.AddDbContext<IdentityAppDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("IdentityConnection")));

        services.AddIdentity<AppUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = false)
            .AddDefaultTokenProviders()
            .AddDefaultUI()
            .AddEntityFrameworkStores<IdentityAppDbContext>();
    }


    public static void SetServices(IServiceCollection services)
    {
        services.AddHttpContextAccessor();
        services.AddTransient<ExceptionHandlingMiddleware>();
        services.AddControllersWithViews();
        services.AddScoped<IContentManager, ContentManager>();
        services.AddSingleton<IEmailSender, EmailSender>();
        services.AddAutoMapper(typeof(MappingProfile));
        services.AddSession(options => {
            options.IdleTimeout = TimeSpan.FromMinutes(10);
            options.Cookie.HttpOnly = true;
            options.Cookie.IsEssential = true;
        });

        #region Model CRUD services
        services.AddTransient<IUnitOfWork, UnitOfWork>();
        services.AddTransient<IViewModelService<Guitar, GuitarViewModel>, GuitarViewModelService>();
        services.AddTransient(typeof(IViewModelService<,>), typeof(ViewModelService<,>));
        services.AddTransient<ICatalogService, CatalogService>();
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

        app.UseRequestLocalization("en-US", "en-US");
        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseRouting();
        app.UseAuthentication();
        app.UseAuthorization();
        app.MapRazorPages();

        app.MapAreaControllerRoute(
            name: "CustomerDefault",
            areaName: "Customer",
            pattern: "{controller=Home}/{action=Index}/{id?}");
        app.MapAreaControllerRoute(
            name: "AdminDefault",
            areaName: "Admin",
            pattern: "{area=Admin}/{controller=Home}/{action=Index}/{id?}");

        app.UseMiddleware<ExceptionHandlingMiddleware>();

        #endregion
    }
}