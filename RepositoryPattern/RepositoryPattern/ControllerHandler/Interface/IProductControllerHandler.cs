using System.Collections.Generic;
using RepositoryPattern.Dto;

namespace RepositoryPattern.ControllerHandler.Interface
{
    public interface IProductControllerHandler
    {
        /// <summary>
        /// Saves the product.
        /// </summary>
        /// <param name="productDto">The product dto.</param>
        bool Save(ProductDto productDto);

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
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        bool Delete(int id);
    }
}