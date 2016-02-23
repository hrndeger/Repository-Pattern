using System;
using System.Transactions;
using RepositoryPattern.Core.Extension;
using RepositoryPattern.Core.UOW;
using RepositoryPattern.Data.Entity;
using RepositoryPattern.Data.Repository.Shop;

namespace RepositoryPattern.Data.UOW
{
    public class ShopCEUnitOfWork : IUnitOfWork
    {
        private readonly ShopCompactContext m_Context = new ShopCompactContext();
        private ShopCERepository<Category> m_CategoryRepository;
        private ShopCERepository<Product> m_ProductRepository;
        private bool m_Disposed = default(bool);

        /// <summary>
        /// Gets the category repository.
        /// </summary>
        /// <value>
        /// The category repository.
        /// </value>
        public ShopCERepository<Category> CategoryRepository
        {
            get
            {
                if (m_CategoryRepository.IsNullOrDefault())
                {
                    m_CategoryRepository = new ShopCERepository<Category>(m_Context);
                }

                return m_CategoryRepository;
            }
        }

        /// <summary>
        /// Gets the product repository.
        /// </summary>
        /// <value>
        /// The product repository.
        /// </value>
        public ShopCERepository<Product> ProductRepository
        {
            get
            {
                if (m_ProductRepository.IsNullOrDefault())
                {
                    m_ProductRepository = new ShopCERepository<Product>(m_Context);
                }

                return m_ProductRepository;
            }
        }

        /// <summary>
        /// Saves this instance.
        /// </summary>
        public void Save()
        {
            using (TransactionScope tScope = new TransactionScope())
            {
                m_Context.SaveChanges();
                tScope.Complete();
            }
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!m_Disposed)
            {
                if (disposing)
                {
                    m_Context.Dispose();
                }
            }
            m_Disposed = true;
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Opens the transaction.
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public void OpenTransaction()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Closes the transaction.
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public void CloseTransaction()
        {
            throw new NotImplementedException();
        }
    }
}