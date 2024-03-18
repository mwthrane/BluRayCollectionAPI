using BluRayCollectionAPI.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<DatabaseSettings>(
       builder.Configuration.GetSection(nameof(DatabaseSettings)));

