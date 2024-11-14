using AProduct.Web.Entities;
using Microsoft.EntityFrameworkCore;

namespace AProduct.Web.Data;

public class AppDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }
}