using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;
using RepositoryPattern.Core.Exceptions;
using RepositoryPattern.Data.Entity;
using RepositoryPattern.Dto;
using RepositoryPattern.Mapping;

namespace RepositoryPattern.Test.Mapper
{
    [TestFixture]
    public sealed class ShoppingMapperFixture
    {
        Product m_ProductMock = new Product
        {
            Id = 1,
            Title = "Kürk Mantolu Madonna",
            CategoryId = 1,
            Quantity = 1,
            UnitPrice = (decimal)9.99
        };

        ProductDto m_ProductDtoMock = new ProductDto
        {
            Id = 1,
            Title = "Kürk Mantolu Madonna",
            CategoryId = 1,
            Quantity = 1,
            UnitPrice = (decimal)9.99
        };
       
        Category m_CategoryMock = new Category
        {
           Id = 1,
           Title = "Book"
        };

        CategoryDto m_CategoryDtoMock = new CategoryDto
        {
            Id = 1,
            Title = "Book"
        };

        [Test]
        public void MapToProductDtoWhenParamIsValid()
        {
            ShoppingMapper shoppingMapper = new ShoppingMapper();
            shoppingMapper.MapToProductDto(m_ProductMock).ShouldBeEquivalentTo(m_ProductDtoMock);
        }

        [Test]
        public void MapToProductDtoWhenParamIsNullOrDefault()
        {
            ShoppingMapper shoppingMapper = new ShoppingMapper();
            Assert.Throws<CustomException>(() => shoppingMapper.MapToProductDto(null));
        }

        [Test]
        public void MapToProductWhenParamIsValid()
        {
            ShoppingMapper shoppingMapper = new ShoppingMapper();
            shoppingMapper.MapToProduct(m_ProductDtoMock).ShouldBeEquivalentTo(m_ProductMock);
        }

        [Test]
        public void MapToProductWhenParamIsNullOrDefault()
        {
            ShoppingMapper shoppingMapper = new ShoppingMapper();
            Assert.Throws<CustomException>(() => shoppingMapper.MapToProduct(null));
        }

        [Test]
        public void MapToCategoryWhenParamIsValid()
        {
            ShoppingMapper shoppingMapper = new ShoppingMapper();
            shoppingMapper.MapToCategory(m_CategoryDtoMock).ShouldBeEquivalentTo(m_CategoryMock);
        }

        [Test]
        public void MapToCategoryWhenParamIsNullOrDefault()
        {
            ShoppingMapper shoppingMapper = new ShoppingMapper();
            Assert.Throws<CustomException>(() => shoppingMapper.MapToCategory(null));
        }

        [Test]
        public void MapToCategoryDtoWhenParamIsValid()
        {
            ShoppingMapper shoppingMapper = new ShoppingMapper();
            shoppingMapper.MapToCategoryDto(m_CategoryMock).ShouldBeEquivalentTo(m_CategoryDtoMock);
        }

        [Test]
        public void MapToCategoryDtoWhenParamIsNullOrDefault()
        {
            ShoppingMapper shoppingMapper = new ShoppingMapper();
            Assert.Throws<CustomException>(() => shoppingMapper.MapToCategoryDto(null));
        }

        [Test]
        public void MapToProductDtosWhenParamIsValid()
        {
            IList<Product> products = new List<Product>
            {
                new Product
                {
                     Id = 1,
                     Title = "Kürk Mantolu Madonna",
                     CategoryId = 1,
                     Quantity = 1,
                     UnitPrice = (decimal)9.99,
                    
                }
            };

            List<ProductDto> productDtos = new List<ProductDto>
            {
                new ProductDto
                {
                     Id = 1,
                     Title = "Kürk Mantolu Madonna",
                     CategoryId = 1,
                     Quantity = 1,
                     UnitPrice = (decimal)9.99,
                }
            };

            ShoppingMapper shoppingMapper = new ShoppingMapper();
            shoppingMapper.MapToProductDtos(products).ShouldBeEquivalentTo(productDtos);
        }

        [Test]
        public void MapToProductDtosWhenParamIsNullOrDefault()
        {
            ShoppingMapper shoppingMapper = new ShoppingMapper();
            Assert.Throws<CustomException>(() => shoppingMapper.MapToProductDtos(null));
        }

        [Test]
        public void MapToCategoryDtosWhenParamIsValid()
        {
            List<Category> categories = new List<Category>
            {
                new Category
                {
                     Id = 1,
                     Title = "Kürk Mantolu Madonna"
                }
            };

            List<CategoryDto> categoryDtos = new List<CategoryDto>
            {
                new CategoryDto
                {
                     Id = 1,
                     Title = "Kürk Mantolu Madonna"
                }
            };

            ShoppingMapper shoppingMapper = new ShoppingMapper();
            shoppingMapper.MapToCategoryDtos(categories).ShouldBeEquivalentTo(categoryDtos);
        }

        [Test]
        public void MapToCategoryDtosWhenParamIsNullOrDefault()
        {
            ShoppingMapper shoppingMapper = new ShoppingMapper();
            Assert.Throws<CustomException>(() => shoppingMapper.MapToCategoryDtos(null));
        }
    }
}