using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SoundPlay.Infrastructure.DataAccess.DbContexts;
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("IdentityAppDbContextConnection") ?? throw new InvalidOperationException("Connection string 'IdentityAppDbContextConnection' not found.");

builder.Services.AddDbContext<IdentityAppDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<IdentityAppDbContext>();
var logger = Dependencies.SetLogger(builder.Configuration, builder.Logging);

Dependencies.SetDbContext(builder.Configuration, builder.Services);
Dependencies.SetServices(builder.Services);

var app = builder.Build();

Dependencies.SetMiddleware(app);

logger.Information("Application started");

app.Run();