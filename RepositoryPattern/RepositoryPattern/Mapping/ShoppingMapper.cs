using System.Collections.Generic;
using System.Linq;
using RepositoryPattern.Core.Exceptions;
using RepositoryPattern.Core.Extension;
using RepositoryPattern.Data.Entity;
using RepositoryPattern.Dto;

namespace RepositoryPattern.Mapping
{
    public sealed class ShoppingMapper : IMapper
    {
        /// <summary>
        /// Maps to product dto.
        /// </summary>
        /// <param name="product">The product.</param>
        /// <returns></returns>
        /// <exception cref="RepositoryPattern.Core.Exceptions.CustomException"></exception>
        public ProductDto MapToProductDto(Product product)
        {
            if (product.IsNullOrDefault())
            {
                throw new CustomException(string.Format("Argument product should not be null"));
            }

            ProductDto result = new ProductDto
            {
                Id = product.Id,
                Title = product.Title,
                CategoryId = product.CategoryId,
                Quantity = product.Quantity,
                UnitPrice = product.UnitPrice
            };

            return result;
        }

        /// <summary>
        /// Maps to product.
        /// </summary>
        /// <param name="productDto">The product dto.</param>
        /// <returns></returns>
        /// <exception cref="RepositoryPattern.Core.Exceptions.CustomException"></exception>
        public Product MapToProduct(ProductDto productDto)
        {
            if (productDto.IsNullOrDefault())
            {
                throw new CustomException(string.Format("Argument productDto should not be null"));
            }

            Product result = new Product
            {
                Id = productDto.Id,
                Title = productDto.Title,
                CategoryId = productDto.CategoryId,
                Quantity = productDto.Quantity,
                UnitPrice = productDto.UnitPrice
            };

            return result;
        }

        /// <summary>
        /// Maps to category.
        /// </summary>
        /// <param name="categoryDto">The category dto.</param>
        /// <returns></returns>
        /// <exception cref="RepositoryPattern.Core.Exceptions.CustomException"></exception>
        public Category MapToCategory(CategoryDto categoryDto)
        {
            if (categoryDto.IsNullOrDefault())
            {
                throw new CustomException(string.Format("Argument categoryDto should not be null"));
            }

            Category result = new Category
            {
                Id = categoryDto.Id,
                Title = categoryDto.Title,
            };

            return result;
        }

        /// <summary>
        /// Maps to category dto.
        /// </summary>
        /// <param name="category">The category.</param>
        /// <returns></returns>
        /// <exception cref="RepositoryPattern.Core.Exceptions.CustomException"></exception>
        public CategoryDto MapToCategoryDto(Category category)
        {
            if (category.IsNullOrDefault())
            {
                throw new CustomException(string.Format("Argument category should not be null"));
            }

            CategoryDto result = new CategoryDto
            {
                Id = category.Id,
                Title = category.Title,
            };

            return result;
        }

        /// <summary>
        /// Maps to product dtos.
        /// </summary>
        /// <param name="products">The products.</param>
        /// <returns></returns>
        /// <exception cref="RepositoryPattern.Core.Exceptions.CustomException"></exception>
        public List<ProductDto> MapToProductDtos(IList<Product> products)
        {
            if (products.IsNullOrDefault() || !products.Any())
            {
                throw new CustomException(string.Format("Argument products should not be null"));
            }

            List<ProductDto> result = products.Select(product => new ProductDto
            {
                Id = product.Id, 
                Title = product.Title, 
                CategoryId = product.CategoryId, 
                Quantity = product.Quantity, 
                UnitPrice = product.UnitPrice,
                
            }).ToList();

            return result;
        }

        /// <summary>
        /// Maps to category dtos.
        /// </summary>
        /// <param name="categories">The categories.</param>
        /// <returns></returns>
        /// <exception cref="RepositoryPattern.Core.Exceptions.CustomException"></exception>
        public List<CategoryDto> MapToCategoryDtos(IList<Category> categories)
        {
            if (categories.IsNullOrDefault() || !categories.Any())
            {
                throw new CustomException(string.Format("Argument categories should not be null"));
            }

            List<CategoryDto> result = categories.Select(category => new CategoryDto
            {
                Id = category.Id, Title = category.Title
            }).ToList();

            return result;
        }
    }
}