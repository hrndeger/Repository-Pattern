using System.Collections.Generic;
using RepositoryPattern.Dto;

namespace RepositoryPattern.Manager
{
    public interface IShoppingManager
    {
        /// <summary>
        /// Saves the product.
        /// </summary>
        /// <param name="productDto">The product dto.</param>
        bool SaveProduct(ProductDto productDto);

        /// <summary>
        /// Gets the product.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        ProductDto GetProduct(int id);

        /// <summary>
        /// Gets the products.
        /// </summary>
        /// <returns></returns>
        IList<ProductDto> GetProducts();


        /// <summary>
        /// Deletes the product.
        /// </summary>
        /// <param name="id">The identifier.</param>
        bool DeleteProduct(int id);

        /// <summary>
        /// Saves the category.
        /// </summary>
        /// <param name="categoryDto">The category dto.</param>
        bool SaveCategory(CategoryDto categoryDto);

        /// <summary>
        /// Gets the category.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        CategoryDto GetCategory(int id);

        /// <summary>
        /// Gets the categories.
        /// </summary>
        /// <returns></returns>
        IList<CategoryDto> GetCategories();

        /// <summary>
        /// Deletes the category.
        /// </summary>
        /// <param name="id">The identifier.</param>
        bool DeleteCategory(int id);

    }
}