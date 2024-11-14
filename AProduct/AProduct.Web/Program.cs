using AProduct.Web.Data;
using AProduct.Web.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo{ Title = "Product", Version = "v1" });
});

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.Development.json")
    .Build();

builder.Services.AddControllers();

builder.Services.AddScoped<IProductRepository, ProductRepository>();

bool inMemory = false;

if (inMemory)
{
    Console.WriteLine("Mock data");
    
    builder.Services.AddDbContext<AppDbContext>(opt => opt.UseInMemoryDatabase("InMemoryDatabase"));
}
else
{
    Console.WriteLine("SQL Database");
    
    builder.Services.AddDbContext<AppDbContext>(opt => 
    opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
}

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

DbInitialization.PrepDb(app);

app.UseHttpsRedirection();

app.Run();
