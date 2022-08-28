using Microsoft.Extensions.Caching.Memory;
using CTeleport.Persistence.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMemoryCache();
builder.Services.AddPersistenceServices(builder.Configuration);

var cacheEntryOptions = new MemoryCacheEntryOptions()
        .SetSlidingExpiration(TimeSpan.FromSeconds(60))
        .SetAbsoluteExpiration(TimeSpan.FromSeconds(3600))
        .SetPriority(CacheItemPriority.Normal);
cacheEntryOptions.SetSize(2048);


var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
