<<<<<<< HEAD
=======
using Microsoft.AspNetCore.Builder;
using SoundPlay.WEB.Configuration;


>>>>>>> 0953c78 (Update Models Configuration)
var builder = WebApplication.CreateBuilder(args);
var logger = Dependencies.SetLogger(builder.Configuration, builder.Logging);

Dependencies.SetDbContext(builder.Configuration, builder.Services);
Dependencies.SetServices(builder.Services);

var app = builder.Build();

Dependencies.SetMiddleware(app);

logger.Information("Application started");

app.Run();