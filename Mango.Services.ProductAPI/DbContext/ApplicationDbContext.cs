namespace Mango.Services.ProductAPI.DbContext;
using Microsoft.EntityFrameworkCore;
using Mango.Services.ProductAPI. Models;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }

    public DbSet<Product> Products { get; set; }
}