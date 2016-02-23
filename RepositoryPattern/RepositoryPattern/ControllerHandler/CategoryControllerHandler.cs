using System.Collections.Generic;
using RepositoryPattern.ControllerHandler.Interface;
using RepositoryPattern.Core.Extension;
using RepositoryPattern.Dto;
using RepositoryPattern.Manager;

namespace RepositoryPattern.ControllerHandler
{
    public class CategoryControllerHandler : ICategoryControllerHandler
    {
        private readonly IShoppingManager m_ShoppingManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="CategoryControllerHandler"/> class.
        /// </summary>
        /// <param name="shoppingManager">The shopping manager.</param>
        public CategoryControllerHandler(IShoppingManager shoppingManager)
        {
            m_ShoppingManager = shoppingManager;
        }

        /// <summary>
        /// Saves the category.
        /// </summary>
        /// <param name="categoryDto">The category dto.</param>
        public bool Save(CategoryDto categoryDto)
        {
            bool result = default (bool);

            if (!categoryDto.IsNullOrDefault())
            {
               result = m_ShoppingManager.SaveCategory(categoryDto);
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
                result = m_ShoppingManager.GetCategory(id);
            }

            return result;
        }

        /// <summary>
        /// Gets the categories.
        /// </summary>
        /// <returns></returns>
        public IList<CategoryDto> GetCategories()
        {
            IList<CategoryDto> result = m_ShoppingManager.GetCategories();
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
                result = m_ShoppingManager.DeleteCategory(id);
            }
            return result;
        }
    }
}