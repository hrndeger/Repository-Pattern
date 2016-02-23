using System.Collections.Generic;
using RepositoryPattern.Data.Entity;
using RepositoryPattern.Dto;

namespace RepositoryPattern.Mapping
{
    public interface IMapper
    {
        /// <summary>
        /// Maps to product dto.
        /// </summary>
        /// <param name="product">The product.</param>
        /// <returns></returns>
        ProductDto MapToProductDto(Product product);

        /// <summary>
        /// Maps to product.
        /// </summary>
        /// <param name="productDto">The product dto.</param>
        /// <returns></returns>
        Product MapToProduct(ProductDto productDto);

        /// <summary>
        /// Maps to category.
        /// </summary>
        /// <param name="categoryDto">The category dto.</param>
        /// <returns></returns>
        Category MapToCategory(CategoryDto categoryDto);

        /// <summary>
        /// Maps to category dto.
        /// </summary>
        /// <param name="category">The category.</param>
        /// <returns></returns>
        CategoryDto MapToCategoryDto(Category category);

        /// <summary>
        /// Maps to product dtos.
        /// </summary>
        /// <param name="products">The products.</param>
        /// <returns></returns>
        List<ProductDto> MapToProductDtos(IList<Product> products);

        /// <summary>
        /// Maps to category dtos.
        /// </summary>
        /// <param name="categories">The categories.</param>
        /// <returns></returns>
        List<CategoryDto> MapToCategoryDtos(IList<Category> categories);
    }
}