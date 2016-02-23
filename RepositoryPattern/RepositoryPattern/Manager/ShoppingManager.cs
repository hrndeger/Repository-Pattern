using System;
using System.Collections.Generic;
using System.Linq;
using RepositoryPattern.Core.Exceptions;
using RepositoryPattern.Data.Dao;
using RepositoryPattern.Data.Entity;
using RepositoryPattern.Dto;
using RepositoryPattern.Core.Extension;
using RepositoryPattern.Data.Response;
using RepositoryPattern.Mapping;

namespace RepositoryPattern.Manager
{
    /// <summary>
    /// The ShoppingManager class implementation
    /// </summary>
    public sealed class ShoppingManager : IShoppingManager
    {
        #region Fields

        private readonly IShopDao m_ShopDao;
        private readonly IMapper m_Mapper;

        #endregion

        #region Ctor

        /// <summary>
        /// Initializes a new instance of the <see cref="ShoppingManager"/> class.
        /// </summary>
        /// <param name="shopDao">The shop DAO.</param>
        /// <param name="shoppingManager">The shopping manager.</param>
        /// <exception cref="System.ArgumentNullException">
        /// shoppingManager
        /// or
        /// shopDao
        /// </exception>
        public ShoppingManager(IShopDao shopDao, IMapper shoppingManager)
        {
            if (shoppingManager.IsNullOrDefault())
            {
                throw new ArgumentNullException("shoppingManager");
            }

            if (shopDao.IsNullOrDefault())
            {
                throw new ArgumentNullException("shopDao");
            }

            m_ShopDao = shopDao;
            m_Mapper = shoppingManager;
        }

        #endregion

        /// <summary>
        /// Saves the product.
        /// </summary>
        /// <param name="productDto">The product dto.</param>
        public bool SaveProduct(ProductDto productDto)
        {
            bool result = default(bool);

            if (!productDto.IsNullOrDefault())
            {
                Product product = m_Mapper.MapToProduct(productDto);

                if (product.IsNullOrDefault())
                {
                    throw new CustomException(string.Format("Argument should not be null.{0}", product));
                }

                ResultBase<SaveResponse> saveResponse = m_ShopDao.SaveProduct(product);

                if (!saveResponse.IsNullOrDefault() && !saveResponse.Result.IsNullOrDefault())
                {
                    result = saveResponse.Result.IsSuccess;
                }
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
                ResultBase<Product> productBase = m_ShopDao.GetProduct(id);

                if (!productBase.IsNullOrDefault() && !productBase.HasException)
                {
                    if (!productBase.Result.IsNullOrDefault())
                    {
                        result = m_Mapper.MapToProductDto(productBase.Result);
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Gets the products.
        /// </summary>
        /// <returns></returns>
        public IList<ProductDto> GetProducts()
        {
            List<ProductDto> result = new List<ProductDto>();

            ResultBase<IList<Product>> products = m_ShopDao.GetProducts();

            if (!products.IsNullOrDefault() && !products.HasException)
            {
                if (!products.Result.IsNullOrDefault() && products.Result.Any())
                {
                    result = m_Mapper.MapToProductDtos(products.Result);
                }
            }

            return result;
        }

        /// <summary>
        /// Saves the category.
        /// </summary>
        /// <param name="categoryDto">The category dto.</param>
        public bool SaveCategory(CategoryDto categoryDto)
        {
            bool result = default(bool);

            if (!categoryDto.IsNullOrDefault())
            {
                Category category = m_Mapper.MapToCategory(categoryDto);

                if (category.IsNullOrDefault())
                {
                    throw new CustomException(string.Format("Argument should not be null.{0}", category));
                }

                ResultBase<SaveResponse> saveResponse = m_ShopDao.SaveCategory(category);

                if (!saveResponse.IsNullOrDefault() && !saveResponse.Result.IsNullOrDefault())
                {
                    result = saveResponse.Result.IsSuccess;
                }
            }

            return result;
        }

        /// <summary>
        /// Gets the category.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public CategoryDto GetCategory(int id)
        {
            CategoryDto result = default(CategoryDto);

            if (id > default(int))
            {
                ResultBase<Category> categoryBase = m_ShopDao.GetCategory(id);

                if (!categoryBase.IsNullOrDefault() && !categoryBase.HasException)
                {
                    if (!categoryBase.Result.IsNullOrDefault())
                    {
                        result = m_Mapper.MapToCategoryDto(categoryBase.Result);
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Gets the categories.
        /// </summary>
        /// <returns></returns>
        public IList<CategoryDto> GetCategories()
        {
            List<CategoryDto> result = new List<CategoryDto>();

            ResultBase<IList<Category>> categories = m_ShopDao.GetCategories();

            if (!categories.IsNullOrDefault() && !categories.HasException)
            {
                if (!categories.Result.IsNullOrDefault() && categories.Result.Any())
                {
                    result = m_Mapper.MapToCategoryDtos(categories.Result);
                }
            }

            return result;
        }

        /// <summary>
        /// Deletes the category.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public bool DeleteCategory(int id)
        {
            bool result = default(bool);

            if (id > default(int))
            {
                ResultBase<DeleteResponse> deleteResponse = m_ShopDao.DeleteCategory(id);

                if (!deleteResponse.IsNullOrDefault() && !deleteResponse.HasException)
                {
                    if (!deleteResponse.Result.IsNullOrDefault())
                    {
                        result = deleteResponse.Result.IsDeleted;
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// Deletes the product.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public bool DeleteProduct(int id)
        {
            bool result = default(bool);
            
            if (id > default(int))
            {
                ResultBase<DeleteResponse> deleteResponse = m_ShopDao.DeleteProduct(id);

                if (!deleteResponse.IsNullOrDefault() && !deleteResponse.HasException)
                {
                    if (!deleteResponse.Result.IsNullOrDefault())
                    {
                        result = deleteResponse.Result.IsDeleted;
                    }    
                }
            }

            return result;
        }
    }
}