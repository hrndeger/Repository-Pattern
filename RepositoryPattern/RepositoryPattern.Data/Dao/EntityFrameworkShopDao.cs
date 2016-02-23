using System;
using System.Collections.Generic;
using System.Linq;
using RepositoryPattern.Data.Entity;
using RepositoryPattern.Data.Response;
using RepositoryPattern.Data.UOW;

namespace RepositoryPattern.Data.Dao
{
    public sealed class EntityFrameworkShopDao : IShopDao
    {
        private readonly ShopUnitOfWork m_ShopUnitOfWork;

        #region Ctor

        public EntityFrameworkShopDao(ShopUnitOfWork shopUnitOfWork)
        {
            m_ShopUnitOfWork = shopUnitOfWork;
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
                using (m_ShopUnitOfWork)
                {
                    if (product.Id == default (int))
                    {
                        m_ShopUnitOfWork.ProductRepository.Insert(product);    
                    }
                    else
                    {
                        m_ShopUnitOfWork.ProductRepository.Update(product);
                    }
                    m_ShopUnitOfWork.Save();
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
                using (m_ShopUnitOfWork)
                {
                    resultBase.Result = m_ShopUnitOfWork.ProductRepository.FindById(id);
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
                using (m_ShopUnitOfWork)
                {
                    resultBase.Result = m_ShopUnitOfWork.ProductRepository.Select().ToList();
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
                using (m_ShopUnitOfWork)
                {
                    if (category.Id == default(int))
                    {
                        m_ShopUnitOfWork.CategoryRepository.Insert(category);    
                    }
                    else
                    {
                        m_ShopUnitOfWork.CategoryRepository.Update(category);
                    }
                    
                    m_ShopUnitOfWork.Save();
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
                using (m_ShopUnitOfWork)
                {
                    resultBase.Result = m_ShopUnitOfWork.CategoryRepository.FindById(id);
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
                using (m_ShopUnitOfWork)
                {
                    resultBase.Result = m_ShopUnitOfWork.CategoryRepository.Select().ToList();
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
                using (m_ShopUnitOfWork)
                {
                    m_ShopUnitOfWork.ProductRepository.Delete(id);
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
                using (m_ShopUnitOfWork)
                {
                    m_ShopUnitOfWork.CategoryRepository.Delete(id);
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