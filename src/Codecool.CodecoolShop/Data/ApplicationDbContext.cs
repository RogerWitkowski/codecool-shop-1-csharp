using Codecool.CodecoolShop.Models;
using Microsoft.EntityFrameworkCore;

namespace Codecool.CodecoolShop.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<BaseModel> BaseModels { get; set; }

    }
}
