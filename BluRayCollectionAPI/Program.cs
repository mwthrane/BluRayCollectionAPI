using BluRayCollectionAPI.Models;
using BluRayCollectionAPI.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<DatabaseSettings>(
       builder.Configuration.GetSection(nameof(DatabaseSettings)));

builder.Services.AddSingleton<BluRayService>();