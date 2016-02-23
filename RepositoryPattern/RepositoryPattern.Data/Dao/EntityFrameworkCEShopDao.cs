using System;
using System.Collections.Generic;
using System.Linq;
using RepositoryPattern.Data.Entity;
using RepositoryPattern.Data.Response;
using RepositoryPattern.Data.UOW;

namespace RepositoryPattern.Data.Dao
{
    public sealed class EntityFrameworkCEShopDao : IShopDao
    {
        private readonly ShopCEUnitOfWork m_ShopCeUnitOfWork;

        #region Ctor

        public EntityFrameworkCEShopDao(ShopCEUnitOfWork shopCeUnitOfWork)
        {
            m_ShopCeUnitOfWork = shopCeUnitOfWork;
        }

        #endregion

        /// <summary>
        /// Saves the product.
        /// </summary>
        /// <param name="product">The product.</param>
        public ResultBase<SaveResponse> SaveProduct(Product product)
        {
            ResultBase<SaveResponse> resultBase = new ResultBase<SaveResponse>
            {
                Result = new SaveResponse
                {
                    IsSuccess = default(bool)
                }
            };

            try
            {
                using (m_ShopCeUnitOfWork)
                {
                    if (product.Id == default (int))
                    {
                        m_ShopCeUnitOfWork.ProductRepository.Insert(product);    
                    }
                    else
                    {
                        m_ShopCeUnitOfWork.ProductRepository.Update(product);
                    }
                    m_ShopCeUnitOfWork.Save();
                    resultBase.Result.IsSuccess = true;
                }
            }
            catch (Exception exception)
            {
                resultBase.Exception = exception;
            }

            return resultBase;
        }

        /// <summary>
        /// Gets the product.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public ResultBase<Product> GetProduct(int id)
        {
            ResultBase<Product> resultBase = new ResultBase<Product>
            {
                Result = new Product()
            };

            try
            {
                using (m_ShopCeUnitOfWork)
                {
                    resultBase.Result = m_ShopCeUnitOfWork.ProductRepository.FindById(id);
                }
            }
            catch (Exception exception)
            {
                resultBase.Exception = exception;
            }

            return resultBase;
        }

        /// <summary>
        /// Gets the products.
        /// </summary>
        /// <returns></returns>
        public ResultBase<IList<Product>> GetProducts()
        {
            ResultBase<IList<Product>> resultBase = new ResultBase<IList<Product>>{Result = new List<Product>()};

            try
            {
                using (m_ShopCeUnitOfWork)
                {
                    resultBase.Result = m_ShopCeUnitOfWork.ProductRepository.Select().ToList();
                }
            }
            catch (Exception exception)
            {
                resultBase.Exception = exception;
            }

            return resultBase;
        }

        /// <summary>
        /// Saves the category.
        /// </summary>
        /// <param name="category">The category.</param>
        public ResultBase<SaveResponse> SaveCategory(Category category)
        {
            ResultBase<SaveResponse> resultBase = new ResultBase<SaveResponse>
            {
                Result = new SaveResponse
                {
                    IsSuccess = default(bool)
                }
            };

            try
            {
                using (m_ShopCeUnitOfWork)
                {
                    if (category.Id == default(int))
                    {
                        m_ShopCeUnitOfWork.CategoryRepository.Insert(category);    
                    }
                    else
                    {
                        m_ShopCeUnitOfWork.CategoryRepository.Update(category);
                    }

                    m_ShopCeUnitOfWork.Save();
                    resultBase.Result.IsSuccess = true;
                }
            }
            catch (Exception exception)
            {
                resultBase.Exception = exception;
            }

            return resultBase;
        }

        /// <summary>
        /// Gets the category.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public ResultBase<Category> GetCategory(int id)
        {
            ResultBase<Category> resultBase = new ResultBase<Category>{Result = new Category()};

            try
            {
                using (m_ShopCeUnitOfWork)
                {
                    resultBase.Result = m_ShopCeUnitOfWork.CategoryRepository.FindById(id);
                }
            }
            catch (Exception exception)
            {
                resultBase.Exception = exception;
            }

            return resultBase;
        }

        /// <summary>
        /// Gets the categories.
        /// </summary>
        /// <returns></returns>
        public ResultBase<IList<Category>> GetCategories()
        {
            ResultBase<IList<Category>> resultBase = new ResultBase<IList<Category>>
            {
                Result = new List<Category>()
            };

            try
            {
                using (m_ShopCeUnitOfWork)
                {
                    resultBase.Result = m_ShopCeUnitOfWork.CategoryRepository.Select().ToList();
                }
            }
            catch (Exception exception)
            {
                resultBase.Exception = exception;
            }

            return resultBase;
        }

        /// <summary>
        /// Deletes the product.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public ResultBase<DeleteResponse> DeleteProduct(int id)
        {
            ResultBase<DeleteResponse> resultBase = new ResultBase<DeleteResponse>
            {
                Result = new DeleteResponse
                {
                    IsDeleted = default(bool)
                }
            };

            try
            {
                using (m_ShopCeUnitOfWork)
                {
                    m_ShopCeUnitOfWork.ProductRepository.Delete(id);
                    resultBase.Result.IsDeleted = true;
                }
            }
            catch (Exception exception)
            {
                resultBase.Exception = exception;
            }

            return resultBase;
        }

        /// <summary>
        /// Deletes the category.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public ResultBase<DeleteResponse> DeleteCategory(int id)
        {
            ResultBase<DeleteResponse> resultBase = new ResultBase<DeleteResponse>
            {
                Result = new DeleteResponse
                {
                    IsDeleted = default(bool)
                }
            };

            try
            {
                using (m_ShopCeUnitOfWork)
                {
                    m_ShopCeUnitOfWork.CategoryRepository.Delete(id);
                    resultBase.Result.IsDeleted = true;
                }
            }
            catch (Exception exception)
            {
                resultBase.Exception = exception;
            }

            return resultBase;
        }
    }
}