using AProduct.Web.Entities;

namespace AProduct.Web.Data;

public static class DbInitialization
{
    public static void PrepDb(IApplicationBuilder app)
    {
        using (var serviceScope = app.ApplicationServices.CreateScope())
        {
            var context = serviceScope.ServiceProvider.GetService<AppDbContext>();
            
            context.Database.EnsureCreated();
            
            SeedData(context);
        }
    }

    public static void SeedData(AppDbContext context)
    {
        if (!context.Products.Any())
        {
            Console.WriteLine("Seeding data");

            context.Products.AddRange(
                new Product { Name = "Product 1", ImgUri = "data:image/png;base64,iVBORw0KGgoAAAANSUh1", Price = 20, Description = "Descp1" },
                new Product { Name = "Product 2", ImgUri = "data:image/png;base64,iVBORw0KGgoAAAANSUh2", Price = 10, },
                new Product { Name = "Product 3", ImgUri = "data:image/png;base64,iVBORw0KGgoAAAANSUh3", Price = 30, Description = "Descp3" },
                new Product { Name = "Product 4", ImgUri = "data:image/png;base64,iVBORw0KGgoAAAANSUh4", Price = 50, Description = "Descp4" }, 
                new Product { Name = "Product 5", ImgUri = "data:image/png;base64,iVBORw0KGgoAAAANSUh5", Price = 30 },
                new Product { Name = "Product 6", ImgUri = "data:image/png;base64,iVBORw0KGgoAAAANSUh6", Price = 70, Description = "Descp6" },
                new Product { Name = "Product 7", ImgUri = "data:image/png;base64,iVBORw0KGgoAAAANSUh7", Price = 30, Description = "Descp7" }
            );
            
            context.SaveChanges();
        }
    }
}