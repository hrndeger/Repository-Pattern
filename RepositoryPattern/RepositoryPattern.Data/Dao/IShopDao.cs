using System.Collections.Generic;
using RepositoryPattern.Data.Entity;
using RepositoryPattern.Data.Response;

namespace RepositoryPattern.Data.Dao
{
    public interface IShopDao
    {
        /// <summary>
        /// Saves the product.
        /// </summary>
        /// <param name="productDto">The product dto.</param>
        ResultBase<SaveResponse> SaveProduct(Product productDto);

        /// <summary>
        /// Gets the product.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        ResultBase<Product> GetProduct(int id);

        /// <summary>
        /// Gets the products.
        /// </summary>
        /// <returns></returns>
        ResultBase<IList<Product>> GetProducts();

        /// <summary>
        /// Saves the category.
        /// </summary>
        /// <param name="categoryDto">The category dto.</param>
        ResultBase<SaveResponse> SaveCategory(Category categoryDto);

        /// <summary>
        /// Gets the category.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        ResultBase<Category> GetCategory(int id);

        /// <summary>
        /// Gets the categories.
        /// </summary>
        /// <returns></returns>
        ResultBase<IList<Category>> GetCategories();

        /// <summary>
        /// Deletes the product.
        /// </summary>
        /// <param name="id">The identifier.</param>
        ResultBase<DeleteResponse> DeleteProduct(int id);

        /// <summary>
        /// Deletes the category.
        /// </summary>
        /// <param name="id">The identifier.</param>
        ResultBase<DeleteResponse> DeleteCategory(int id);
    }
}