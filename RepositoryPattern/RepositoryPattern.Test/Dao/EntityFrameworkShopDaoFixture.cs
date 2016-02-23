using System;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using RepositoryPattern.Data.Dao;
using RepositoryPattern.Data.Entity;
using RepositoryPattern.Data.Response;
using RepositoryPattern.Data.UOW;

namespace RepositoryPattern.Test.Dao
{
    [TestFixture]
    public sealed class EntityFrameworkShopDaoFixture
    {
        private ShopUnitOfWork m_ShopUnitOfWorkMock;

        readonly ResultBase<SaveResponse> m_SaveResponse = new ResultBase<SaveResponse>
            {
                Result = new SaveResponse
                {
                    IsSuccess = default(bool)
                }
            };

        [Test]
        public void SaveProductWhenParamIsValid()
        {
            Product product = new Product
            {
                Id = 1,
                Title = "Kürk Mantolu Madonna",
                CategoryId = 1,
                Quantity = 1,
                UnitPrice =(decimal)9.99 
            };

            using (m_ShopUnitOfWorkMock)
            {
                m_ShopUnitOfWorkMock.ProductRepository.Insert(product);
                m_ShopUnitOfWorkMock.Save();
                m_SaveResponse.Result.IsSuccess = true;
            }

            EntityFrameworkShopDao entityFrameworkShopDao = new EntityFrameworkShopDao(m_ShopUnitOfWorkMock);
            entityFrameworkShopDao.SaveProduct(product).ShouldBeEquivalentTo(m_SaveResponse);
        }

        [Test]
        public void SaveProductWhenResultBase()
        {
            Product product = new Product
            {
                Id = 1,
                Title = "Kürk Mantolu Madonna",
                CategoryId = 1,
                Quantity = 1,
                UnitPrice = (decimal)9.99
            };

            using (m_ShopUnitOfWorkMock)
            {
                m_SaveResponse.Exception = new Exception();

                m_SaveResponse.Result.IsSuccess = default(bool);
            }

            EntityFrameworkShopDao entityFrameworkShopDao = new EntityFrameworkShopDao(m_ShopUnitOfWorkMock);
            entityFrameworkShopDao.SaveProduct(product).ShouldBeEquivalentTo(m_SaveResponse);
        }

        private void Init()
        {
            m_ShopUnitOfWorkMock = Substitute.For<ShopUnitOfWork>();
        }
    }
}