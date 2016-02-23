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
    public sealed class CategoryControllerHandlerFixture
    {
        private IShoppingManager m_ShoppingManagerMock;

        CategoryDto m_CategoryDtoMock = new CategoryDto
        {
            Id = 1,
            Title = "Book"
        };

        [Test]
        public void SaveWhenParamIsValid()
        {
            Init();

            m_ShoppingManagerMock.SaveCategory(m_CategoryDtoMock).Returns(true);

            CategoryControllerHandler categoryControllerHandler = new CategoryControllerHandler(m_ShoppingManagerMock);
            categoryControllerHandler.Save(m_CategoryDtoMock).ShouldBeEquivalentTo(true);
        }

        [Test]
        public void SaveWhenParamIsNullOrDefault()
        {
            Init();

            CategoryDto categoryDto = null;

            m_ShoppingManagerMock.SaveCategory(categoryDto).Returns(default(bool));

            CategoryControllerHandler categoryControllerHandler = new CategoryControllerHandler(m_ShoppingManagerMock);
            categoryControllerHandler.Save(m_CategoryDtoMock).ShouldBeEquivalentTo(default(bool));
        }

        [Test]
        public void GetCategoryWhenParamIsValid()
        {
            Init();
            int id = 1;

            m_ShoppingManagerMock.GetCategory(id).Returns(m_CategoryDtoMock);

            CategoryControllerHandler categoryControllerHandler = new CategoryControllerHandler(m_ShoppingManagerMock);
            categoryControllerHandler.GetCategory(id).ShouldBeEquivalentTo(m_CategoryDtoMock);
        }

        [Test]
        public void GetCategoryWhenParamIsNullOrDefault()
        {
            Init();
            int id = default(int);

            m_ShoppingManagerMock.GetCategory(id).Returns(m_CategoryDtoMock);

            CategoryControllerHandler categoryControllerHandler = new CategoryControllerHandler(m_ShoppingManagerMock);
            categoryControllerHandler.GetCategory(id).ShouldBeEquivalentTo(default(CategoryDto));
        }

        [Test]
        public void GetCategoriesWhenParamIsValid()
        {
            Init();
           
            IList<CategoryDto> categoryList = new List<CategoryDto>
            {
                new CategoryDto
                {
                    Id = 1,
                    Title = "Book"
                }
            };

            m_ShoppingManagerMock.GetCategories().Returns(categoryList);

            CategoryControllerHandler categoryControllerHandler = new CategoryControllerHandler(m_ShoppingManagerMock);
            categoryControllerHandler.GetCategories().ShouldBeEquivalentTo(categoryList);
        }

        [Test]
        public void GetCategoriesWhenManagerReturnIsNullOrDefault()
        {
            Init();

            IList<CategoryDto> categoryList = null;

            m_ShoppingManagerMock.GetCategories().Returns(categoryList);

            CategoryControllerHandler categoryControllerHandler = new CategoryControllerHandler(m_ShoppingManagerMock);
            categoryControllerHandler.GetCategories().ShouldBeEquivalentTo(default(List<CategoryDto>));
        }

        [Test]
        public void DeleteWhenParamIsValid()
        {
            Init();
            int id = 1;

            m_ShoppingManagerMock.DeleteCategory(id).Returns(true);

            CategoryControllerHandler categoryControllerHandler = new CategoryControllerHandler(m_ShoppingManagerMock);
            categoryControllerHandler.Delete(id).ShouldBeEquivalentTo(true);
        }

        [Test]
        public void DeleteWhenParamIsNullOrDefault()
        {
            Init();
            int id = default(int);

            m_ShoppingManagerMock.DeleteCategory(id).Returns(default(bool));

            CategoryControllerHandler categoryControllerHandler = new CategoryControllerHandler(m_ShoppingManagerMock);
            categoryControllerHandler.Delete(id).ShouldBeEquivalentTo(default(bool));
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