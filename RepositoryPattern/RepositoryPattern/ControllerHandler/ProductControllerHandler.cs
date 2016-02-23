using System.Collections.Generic;
using RepositoryPattern.ControllerHandler.Interface;
using RepositoryPattern.Core.Extension;
using RepositoryPattern.Dto;
using RepositoryPattern.Manager;

namespace RepositoryPattern.ControllerHandler
{
    public sealed class ProductControllerHandler : IProductControllerHandler
    {
        private readonly IShoppingManager m_ShoppingManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductControllerHandler"/> class.
        /// </summary>
        /// <param name="shoppingManager">The shopping manager.</param>
        public ProductControllerHandler(IShoppingManager shoppingManager)
        {
            m_ShoppingManager = shoppingManager;
        }

        /// <summary>
        /// Saves the product.
        /// </summary>
        /// <param name="productDto">The product dto.</param>
        public bool Save(ProductDto productDto)
        {
            bool result = default(bool);

            if (!productDto.IsNullOrDefault())
            {
                result = m_ShoppingManager.SaveProduct(productDto);
            }

            return result;
        }

        /// <summary>
        /// Gets the product.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public ProductDto GetProduct(int id)
        {
            ProductDto result = default(ProductDto);

            if (id > default(int))
            {
                result = m_ShoppingManager.GetProduct(id);
            }

            return result;
        }

        /// <summary>
        /// Gets the products.
        /// </summary>
        /// <returns></returns>
        public IList<ProductDto> GetProducts()
        {
            IList<ProductDto> result = m_ShoppingManager.GetProducts();
            return result;
        }

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public bool Delete(int id)
        {
            bool result = default(bool);
            if (id > default(int))
            {
                result = m_ShoppingManager.DeleteProduct(id);
            }
            return result;
        }
    }
}