using Microsoft.EntityFrameworkCore;

namespace ProductMicroservicesProject.Models
{
    public class ProductDBContext:DbContext
    {
        public DbSet<Product> Products { get; set; }
        public ProductDBContext(DbContextOptions<ProductDBContext> options):base(options) { }   
    }
}
