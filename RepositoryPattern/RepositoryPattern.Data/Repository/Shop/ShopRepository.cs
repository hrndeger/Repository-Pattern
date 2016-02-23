using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using RepositoryPattern.Core.Exceptions;
using RepositoryPattern.Core.Extension;
using RepositoryPattern.Core.Repository;

namespace RepositoryPattern.Data.Repository.Shop
{

    public sealed class ShopRepository<T> : IGenericRepository<T> where T : class
    {
        #region Fields

        private readonly ShopContext m_Context;
        private readonly DbSet<T> m_DbSet;

        #endregion

        #region Ctor

        /// <summary>
        /// Initializes a new instance of the <see cref="ShopRepository{T}"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public ShopRepository(ShopContext context)
        {
            m_Context = context;
            m_DbSet = m_Context.Set<T>();
        }

        #endregion

        /// <summary>
        /// Finds the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public T FindById(object id)
        {
            T findById = m_DbSet.Find(id);
            return findById;
        }

        /// <summary>
        /// Selects the specified filter.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns></returns>
        public IEnumerable<T> Select(Expression<Func<T, bool>> filter = null)
        {
            if (!filter.IsNullOrDefault())
            {
                return m_DbSet.Where(filter).ToList();
            }

            return m_DbSet;
        }

        /// <summary>
        /// Selects this instance.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<T> Select()
        {
            return m_DbSet.ToList();
        }

        /// <summary>
        /// Inserts the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Insert(T entity)
        {
            try
            {
                m_DbSet.Add(entity);
            }
            catch (Exception e)
            {
                throw new CustomException(string.Format(e.Message));
            }
        }

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Update(T entity)
        {
            m_DbSet.Attach(entity);
            m_Context.Entry(entity).State = EntityState.Modified;
        }

        /// <summary>
        /// Deletes the specified entity identifier.
        /// </summary>
        /// <param name="entityId">The entity identifier.</param>
        public void Delete(object entityId)
        {
            T entityToDelete = m_DbSet.Find(entityId);
            Delete(entityToDelete);
        }

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Delete(T entity)
        {
            if (m_Context.Entry(entity).State == EntityState.Detached) // for Concurrency 
            {
                m_DbSet.Attach(entity);
            }

            m_DbSet.Remove(entity);
        }
    }
}