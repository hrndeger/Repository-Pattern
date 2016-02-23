using System.Collections.Generic;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using RepositoryPattern.ControllerHandler;
using RepositoryPattern.Dto;
using RepositoryPattern.Manager;

namespace RepositoryPattern.Test.ControllerHandler
{
    [TestFixture]
    public sealed class ProductControllerHandlerFixture
    {
        private IShoppingManager m_ShoppingManagerMock;

        readonly ProductDto m_ProductDtoMock = new ProductDto
        {
            Id = 1,
            Title = "Book",
            Quantity = 1,
            CategoryId = 1,
            UnitPrice = (decimal)9.99
        };

        [Test]
        public void SaveWhenParamIsValid()
        {
            Init();

            m_ShoppingManagerMock.SaveProduct(m_ProductDtoMock).Returns(true);

            ProductControllerHandler productControllerHandler = new ProductControllerHandler(m_ShoppingManagerMock);
            productControllerHandler.Save(m_ProductDtoMock).ShouldBeEquivalentTo(true);
        }

        [Test]
        public void SaveWhenParamIsNullOrDefault()
        {
            Init();

            ProductDto productDto = null;

            m_ShoppingManagerMock.SaveProduct(productDto).Returns(default(bool));

            ProductControllerHandler productControllerHandler = new ProductControllerHandler(m_ShoppingManagerMock);
            productControllerHandler.Save(m_ProductDtoMock).ShouldBeEquivalentTo(default(bool));
        }

        [Test]
        public void GetProductWhenParamIsValid()
        {
            Init();
            int id = 1;

            m_ShoppingManagerMock.GetProduct(id).Returns(m_ProductDtoMock);

            ProductControllerHandler productControllerHandler = new ProductControllerHandler(m_ShoppingManagerMock);
            productControllerHandler.GetProduct(id).ShouldBeEquivalentTo(m_ProductDtoMock);
        }

        [Test]
        public void GetProductWhenParamIsNullOrDefault()
        {
            Init();
            int id = default(int);

            m_ShoppingManagerMock.GetProduct(id).Returns(m_ProductDtoMock);

            ProductControllerHandler productControllerHandler = new ProductControllerHandler(m_ShoppingManagerMock);
            productControllerHandler.GetProduct(id).ShouldBeEquivalentTo(default(ProductDto));
        }

        [Test]
        public void GetProductsWhenParamIsValid()
        {
            Init();

            IList<ProductDto> productDtos = new List<ProductDto>
            {
                new ProductDto
                {
                    Id = 1,
                    Title = "Book",
                    Quantity = 1,
                    CategoryId = 1,
                    UnitPrice = (decimal)9.99
                }
            };

            m_ShoppingManagerMock.GetProducts().Returns(productDtos);

            ProductControllerHandler productControllerHandler = new ProductControllerHandler(m_ShoppingManagerMock);
            productControllerHandler.GetProducts().ShouldBeEquivalentTo(productDtos);
        }

        [Test]
        public void GetProductsWhenManagerReturnIsNullOrDefault()
        {
            Init();

            IList<ProductDto> productDtos = null;

            m_ShoppingManagerMock.GetProducts().Returns(productDtos);

            ProductControllerHandler productControllerHandler = new ProductControllerHandler(m_ShoppingManagerMock);
            productControllerHandler.GetProducts().ShouldBeEquivalentTo(default(List<ProductDto>));
        }

        [Test]
        public void DeleteWhenParamIsValid()
        {
            Init();
            int id = 1;

            m_ShoppingManagerMock.DeleteProduct(id).Returns(true);

            ProductControllerHandler productControllerHandler = new ProductControllerHandler(m_ShoppingManagerMock);
            productControllerHandler.Delete(id).ShouldBeEquivalentTo(true);
        }

        [Test]
        public void DeleteWhenParamIsNullOrDefault()
        {
            Init();
            int id = default(int);

            m_ShoppingManagerMock.DeleteProduct(id).Returns(default(bool));

            ProductControllerHandler productControllerHandler = new ProductControllerHandler(m_ShoppingManagerMock);
            productControllerHandler.Delete(id).ShouldBeEquivalentTo(default(bool));
        }

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        private void Init()
        {
            m_ShoppingManagerMock = Substitute.For<IShoppingManager>();
        }

    }
}