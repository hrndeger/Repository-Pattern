using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using RepositoryPattern.Data.Entity;

namespace RepositoryPattern.Data
{
    public class ShopContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ShopContext"/> class.
        /// </summary>
        public ShopContext()
        {
            Database.SetInitializer<ShopContext>(null);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ShopContext"/> class.
        /// </summary>
        /// <param name="connectionString">The connection string.</param>
        public ShopContext(string connectionString)
            : base(connectionString)
        {
            
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ShopContext"/> class.
        /// </summary>
        /// <param name="connectionString">The connection string.</param>
        /// <param name="model">The model.</param>
        public ShopContext(string connectionString, DbCompiledModel model)
            : base(connectionString, model)
        {
            
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
            modelBuilder.HasDefaultSchema("dbo");


            modelBuilder.Entity<Category>().Map(m =>
            {
                m.Properties(p => new {p.Id,p.Title});
                m.ToTable("Category");
            });

            modelBuilder.Entity<Product>().Map(m =>
            {
                m.Properties(p => new {p.Id,p.Quantity,p.Title,p.UnitPrice,p.CategoryId});
                m.ToTable("Product");
               
            }).HasRequired(x =>x.Category).WithMany(l =>l.Products).HasForeignKey(x =>x.CategoryId);

        }
    }
}