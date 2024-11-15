using AProduct.Web.Data;
using AProduct.Web.Interfaces;
using Asp.Versioning;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo{ Title = "Product - v1", Version = "v1" });
    c.SwaggerDoc("v2", new OpenApiInfo{ Title = "Product - v2", Version = "v2" });
});

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddApiVersioning(o =>
{
    o.AssumeDefaultVersionWhenUnspecified = true;
    o.DefaultApiVersion = ApiVersion.Default; 
    o.ReportApiVersions = true;
    o.ApiVersionReader = ApiVersionReader.Combine(
        new QueryStringApiVersionReader("api-version"),
        new HeaderApiVersionReader("api-version"),
        new UrlSegmentApiVersionReader());
}).AddApiExplorer(options =>
{
    options.GroupNameFormat = "'v'V";
    options.SubstituteApiVersionInUrl = true;
        
});

var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.Development.json")
    .Build();

builder.Services.AddControllers();

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductRepositoryV2, ProductRepositoryV2>();


bool inMemory = true;
foreach (var arg in args)
{
    if (arg == "-sql")
    {
        inMemory = false;
    }
}

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
