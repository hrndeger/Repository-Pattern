using System.Data.Entity;
using RepositoryPattern.Data.Entity;

namespace RepositoryPattern.Data
{
    public class ShopCompactContext : DbContext
    {
        public ShopCompactContext()
        {
            Database.SetInitializer<ShopCompactContext>(new CreateDatabaseIfNotExists<ShopCompactContext>());
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}