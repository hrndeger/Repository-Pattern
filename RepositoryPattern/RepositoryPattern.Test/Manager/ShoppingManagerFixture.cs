using System;
using System.Collections.Generic;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using RepositoryPattern.Core.Exceptions;
using RepositoryPattern.Data.Dao;
using RepositoryPattern.Data.Entity;
using RepositoryPattern.Data.Response;
using RepositoryPattern.Dto;
using RepositoryPattern.Manager;
using RepositoryPattern.Mapping;

namespace RepositoryPattern.Test.Manager
{
    [TestFixture]
    public sealed class ShoppingManagerFixture
    {
        private IShopDao m_ShopDaoMock;
        private IMapper m_MapperMock;

        ProductDto m_ProductDtoMock = new ProductDto
        {
            Id = 1,
            CategoryId = 1,
            Title = "Kürk Mantolu Madonna",
            Quantity = 1,
            UnitPrice = (decimal)9.99,
        };

        Product m_ProductMock = new Product
        {
            Id = 1,
            CategoryId = 1,
            Title = "Kürk Mantolu Madonna",
            Quantity = 1,
            UnitPrice = (decimal)9.99,
        };

        ResultBase<Product> m_ProductResultBase = new ResultBase<Product>
        {
            Result = new Product
            {
                Id = 1,
                CategoryId = 1,
                Title = "Kürk Mantolu Madonna",
                Quantity = 1,
                UnitPrice = (decimal)9.99
            }
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

        ResultBase<Category> m_CategoryResultBase = new ResultBase<Category>
        {
            Result = new Category
            {
                Id = 1,
                Title = "Book"
            }
        };

        #region Product

        [Test]
        public void SaveProductWhenParamIsValid()
        {
            Init();

            ResultBase<SaveResponse> saveResponse = new ResultBase<SaveResponse>
            {
                Result = new SaveResponse { IsSuccess = true }
            };

            m_MapperMock.MapToProduct(m_ProductDtoMock).Returns(m_ProductMock);

            m_ShopDaoMock.SaveProduct(m_ProductMock).Returns(saveResponse);

            ShoppingManager shoppingManager = new ShoppingManager(m_ShopDaoMock, m_MapperMock);
            shoppingManager.SaveProduct(m_ProductDtoMock).ShouldBeEquivalentTo(true);
        }

        [Test]
        public void SaveProductWhenParamIsNullOrDefault()
        {
            Init();

            ProductDto productDto = null;

            ShoppingManager shoppingManager = new ShoppingManager(m_ShopDaoMock, m_MapperMock);
            shoppingManager.SaveProduct(productDto).ShouldBeEquivalentTo(false);
        }

        [Test]
        public void SaveProductWhenMapperReturnNullOrDefault()
        {
            Init();

            Product product = default(Product);

            m_MapperMock.MapToProduct(m_ProductDtoMock).Returns(product);

            ShoppingManager shoppingManager = new ShoppingManager(m_ShopDaoMock, m_MapperMock);
            Assert.Throws<CustomException>(() => shoppingManager.SaveProduct(m_ProductDtoMock));
        }

        [Test]
        public void SaveProductWhenSaveResponseReturnNullOrDefault()
        {
            Init();

            ResultBase<SaveResponse> saveResponse = null;

            m_MapperMock.MapToProduct(m_ProductDtoMock).Returns(m_ProductMock);

            m_ShopDaoMock.SaveProduct(m_ProductMock).Returns(saveResponse);

            ShoppingManager shoppingManager = new ShoppingManager(m_ShopDaoMock, m_MapperMock);
            shoppingManager.SaveProduct(m_ProductDtoMock).ShouldBeEquivalentTo(default(bool));
        }

        [Test]
        public void GetProductWhenParamIsValid()
        {
            Init();

            int id = 1;

            m_ShopDaoMock.GetProduct(id).Returns(m_ProductResultBase);
            m_MapperMock.MapToProductDto(m_ProductResultBase.Result).Returns(m_ProductDtoMock);

            ShoppingManager shoppingManager = new ShoppingManager(m_ShopDaoMock, m_MapperMock);
            shoppingManager.GetProduct(id).ShouldBeEquivalentTo(m_ProductDtoMock);
        }

        [Test]
        public void GetProductWhenParamIsNotValid()
        {
            Init();

            int id = default(int);

            ShoppingManager shoppingManager = new ShoppingManager(m_ShopDaoMock, m_MapperMock);
            shoppingManager.GetProduct(id).ShouldBeEquivalentTo(default(ProductDto));
        }

        [Test]
        public void GetProductWhenResultBaseHasException()
        {
            Init();

            int id = 1;

            m_ShopDaoMock.GetProduct(id).Returns(m_ProductResultBase);
            m_ProductResultBase.Exception = new Exception();

            ShoppingManager shoppingManager = new ShoppingManager(m_ShopDaoMock, m_MapperMock);
            shoppingManager.GetProduct(id).ShouldBeEquivalentTo(default(ProductDto));
        }

        [Test]
        public void GetProductWhenResultBaseIsNullOrDefault()
        {
            Init();

            int id = 1;
            ResultBase<Product> productBase = null;

            m_ShopDaoMock.GetProduct(id).Returns(productBase);

            ShoppingManager shoppingManager = new ShoppingManager(m_ShopDaoMock, m_MapperMock);
            shoppingManager.GetProduct(id).ShouldBeEquivalentTo(default(ProductDto));
        }

        [Test]
        public void GetProductsWhenResultBaseIsValid()
        {
            Init();

            List<ProductDto> result = new List<ProductDto>
            {
                new ProductDto
                {
                    Id = 1,
                    CategoryId = 1,
                    Title = "Kürk Mantolu Madonna",
                    Quantity = 1,
                    UnitPrice = (decimal) 9.99,
                }
            };

            ResultBase<IList<Product>> products = new ResultBase<IList<Product>>
            {
                Result = new[]
                {
                    new Product
                    {
                        Id = 1,
                        CategoryId = 1,
                        Title = "Kürk Mantolu Madonna",
                        Quantity = 1,
                        UnitPrice = (decimal) 9.99
                    }
                }
            };

            m_ShopDaoMock.GetProducts().Returns(products);
            m_MapperMock.MapToProductDtos(products.Result).Returns(result);

            ShoppingManager shoppingManager = new ShoppingManager(m_ShopDaoMock, m_MapperMock);
            shoppingManager.GetProducts().ShouldBeEquivalentTo(result);
        }

        [Test]
        public void GetProductsWhenResultBaseIsNullOrDefault()
        {
            Init();
            List<ProductDto> result = new List<ProductDto>();

            ResultBase<IList<Product>> products = null;

            m_ShopDaoMock.GetProducts().Returns(products);

            ShoppingManager shoppingManager = new ShoppingManager(m_ShopDaoMock, m_MapperMock);
            shoppingManager.GetProducts().ShouldBeEquivalentTo(result);

        }

        [Test]
        public void DeleteProductWhenParamIsValid()
        {
            Init();
            int id = 1;

            ResultBase<DeleteResponse> deleteResponseBase = new ResultBase<DeleteResponse>
            {
                Result = new DeleteResponse { IsDeleted = true }
            };

            m_ShopDaoMock.DeleteProduct(id).Returns(deleteResponseBase);

            ShoppingManager shoppingManager = new ShoppingManager(m_ShopDaoMock, m_MapperMock);
            shoppingManager.DeleteProduct(id).ShouldBeEquivalentTo(true);
        }

        [Test]
        public void DeleteProductWhenParamIsNullOrDefault()
        {
            Init();
            int id = default(int);

            ShoppingManager shoppingManager = new ShoppingManager(m_ShopDaoMock, m_MapperMock);
            shoppingManager.DeleteProduct(id).ShouldBeEquivalentTo(default(bool));
        }

        [Test]
        public void DeleteProductWhenDeleteResponseIsNullOrDefault()
        {
            Init();
            int id = 1;

            ResultBase<DeleteResponse> deleteResponseBase = null;

            m_ShopDaoMock.DeleteProduct(id).Returns(deleteResponseBase);

            ShoppingManager shoppingManager = new ShoppingManager(m_ShopDaoMock, m_MapperMock);
            shoppingManager.DeleteProduct(id).ShouldBeEquivalentTo(default(bool));
        }

        #endregion

        #region Category

        [Test]
        public void SaveCategoryWhenParamIsValid()
        {
            Init();

            ResultBase<SaveResponse> saveResponse = new ResultBase<SaveResponse>
            {
                Result = new SaveResponse { IsSuccess = true }
            };

            m_MapperMock.MapToCategory(m_CategoryDtoMock).Returns(m_CategoryMock);

            m_ShopDaoMock.SaveCategory(m_CategoryMock).Returns(saveResponse);

            ShoppingManager shoppingManager = new ShoppingManager(m_ShopDaoMock, m_MapperMock);
            shoppingManager.SaveCategory(m_CategoryDtoMock).ShouldBeEquivalentTo(true);
        }

        [Test]
        public void SaveCategoryWhenParamIsNullOrDefault()
        {
            Init();

            CategoryDto categoryDto = null;

            ShoppingManager shoppingManager = new ShoppingManager(m_ShopDaoMock, m_MapperMock);
            shoppingManager.SaveCategory(categoryDto).ShouldBeEquivalentTo(false);
        }

        [Test]
        public void SaveCategoryWhenMapperReturnNullOrDefault()
        {
            Init();

            Category category = default(Category);

            m_MapperMock.MapToCategory(m_CategoryDtoMock).Returns(category);

            ShoppingManager shoppingManager = new ShoppingManager(m_ShopDaoMock, m_MapperMock);
            Assert.Throws<CustomException>(() => shoppingManager.SaveCategory(m_CategoryDtoMock));
        }

        [Test]
        public void SaveCategoryWhenSaveResponseReturnNullOrDefault()
        {
            Init();

            ResultBase<SaveResponse> saveResponse = null;

            m_MapperMock.MapToCategory(m_CategoryDtoMock).Returns(m_CategoryMock);

            m_ShopDaoMock.SaveCategory(m_CategoryMock).Returns(saveResponse);

            ShoppingManager shoppingManager = new ShoppingManager(m_ShopDaoMock, m_MapperMock);
            shoppingManager.SaveCategory(m_CategoryDtoMock).ShouldBeEquivalentTo(default(bool));
        }

        [Test]
        public void GetCategoryWhenParamIsValid()
        {
            Init();

            int id = 1;

            m_ShopDaoMock.GetCategory(id).Returns(m_CategoryResultBase);
            m_MapperMock.MapToCategoryDto(m_CategoryResultBase.Result).Returns(m_CategoryDtoMock);

            ShoppingManager shoppingManager = new ShoppingManager(m_ShopDaoMock, m_MapperMock);
            shoppingManager.GetCategory(id).ShouldBeEquivalentTo(m_CategoryDtoMock);
        }

        [Test]
        public void GetCategoryWhenParamIsNotValid()
        {
            Init();

            int id = default(int);

            ShoppingManager shoppingManager = new ShoppingManager(m_ShopDaoMock, m_MapperMock);
            shoppingManager.GetCategory(id).ShouldBeEquivalentTo(default(CategoryDto));
        }

        [Test]
        public void GetCategoryWhenResultBaseHasException()
        {
            Init();

            int id = 1;

            m_ShopDaoMock.GetCategory(id).Returns(m_CategoryResultBase);
            m_ProductResultBase.Exception = new Exception();

            ShoppingManager shoppingManager = new ShoppingManager(m_ShopDaoMock, m_MapperMock);
            shoppingManager.GetCategory(id).ShouldBeEquivalentTo(default(CategoryDto));
        }

        [Test]
        public void GetCategoryWhenResultBaseIsNullOrDefault()
        {
            Init();

            int id = 1;
            ResultBase<Category> categoryBase = null;

            m_ShopDaoMock.GetCategory(id).Returns(categoryBase);

            ShoppingManager shoppingManager = new ShoppingManager(m_ShopDaoMock, m_MapperMock);
            shoppingManager.GetCategory(id).ShouldBeEquivalentTo(default(CategoryDto));
        }

        [Test]
        public void GetCategoriesWhenResultBaseIsValid()
        {
            Init();

            List<CategoryDto> result = new List<CategoryDto>
            {
                new CategoryDto
                {
                    Id = 1,
                    Title = "Book"
                }
            };

            ResultBase<IList<Category>> categories = new ResultBase<IList<Category>>
            {
                Result = new[]
                {
                    new Category
                    {
                       Id = 1,
                       Title = "Book"
                    }
                }
            };

            m_ShopDaoMock.GetCategories().Returns(categories);
            m_MapperMock.MapToCategoryDtos(categories.Result).Returns(result);

            ShoppingManager shoppingManager = new ShoppingManager(m_ShopDaoMock, m_MapperMock);
            shoppingManager.GetCategories().ShouldBeEquivalentTo(result);
        }

        [Test]
        public void GetCategoriesWhenResultBaseIsNullOrDefault()
        {
            Init();
            List<CategoryDto> result = new List<CategoryDto>();

            ResultBase<IList<Category>> categories = null;

            m_ShopDaoMock.GetCategories().Returns(categories);

            ShoppingManager shoppingManager = new ShoppingManager(m_ShopDaoMock, m_MapperMock);
            shoppingManager.GetCategories().ShouldBeEquivalentTo(result);
        }

        [Test]
        public void DeleteCategoryWhenParamIsValid()
        {
            Init();
            int id = 1;

            ResultBase<DeleteResponse> deleteResponseBase = new ResultBase<DeleteResponse>
            {
                Result = new DeleteResponse { IsDeleted = true }
            };

            m_ShopDaoMock.DeleteCategory(id).Returns(deleteResponseBase);

            ShoppingManager shoppingManager = new ShoppingManager(m_ShopDaoMock, m_MapperMock);
            shoppingManager.DeleteCategory(id).ShouldBeEquivalentTo(true);
        }

        [Test]
        public void DeleteCategoryWhenParamIsNullOrDefault()
        {
            Init();
            int id = default(int);

            ShoppingManager shoppingManager = new ShoppingManager(m_ShopDaoMock, m_MapperMock);
            shoppingManager.DeleteCategory(id).ShouldBeEquivalentTo(default(bool));
        }

        [Test]
        public void DeleteCategoryWhenDeleteResponseIsNullOrDefault()
        {
            Init();
            int id = 1;

            ResultBase<DeleteResponse> deleteResponseBase = null;

            m_ShopDaoMock.DeleteCategory(id).Returns(deleteResponseBase);

            ShoppingManager shoppingManager = new ShoppingManager(m_ShopDaoMock, m_MapperMock);
            shoppingManager.DeleteCategory(id).ShouldBeEquivalentTo(default(bool));
        }


        #endregion

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        private void Init()
        {
            m_MapperMock = Substitute.For<IMapper>();
            m_ShopDaoMock = Substitute.For<IShopDao>();
        }
    }
}