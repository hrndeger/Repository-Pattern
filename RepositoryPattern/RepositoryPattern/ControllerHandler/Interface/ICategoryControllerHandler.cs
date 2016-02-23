using System.Collections.Generic;
using RepositoryPattern.Dto;

namespace RepositoryPattern.ControllerHandler.Interface
{
    public interface ICategoryControllerHandler
    {
        
        /// <summary>
        /// Saves the category.
        /// </summary>
        /// <param name="categoryDto">The category dto.</param>
        bool Save(CategoryDto categoryDto);

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
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        bool Delete(int id);
    }
}