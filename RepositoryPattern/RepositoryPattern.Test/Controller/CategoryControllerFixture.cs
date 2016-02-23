using System.Collections.Generic;
using System.Web.Mvc;
using NSubstitute;
using NUnit.Framework;
using RepositoryPattern.ControllerHandler.Interface;
using RepositoryPattern.Controllers;
using RepositoryPattern.Dto;
using RepositoryPattern.Models;

namespace RepositoryPattern.Test.Controller
{
    [TestFixture]
    public sealed class CategoryControllerFixture
    {
        private ICategoryControllerHandler m_CategoryControllerHandlerMock;

        [Test]
        public void Index()
        {
            Init();

            IList<CategoryDto> categoryDtos = new List<CategoryDto>
            {
                new CategoryDto
                {
                    Id = 1,
                    Title = "Book"
                }
            };

            m_CategoryControllerHandlerMock.GetCategories().Returns(categoryDtos);
            
            CategoryViewModel m_CategoryViewModelMock = new CategoryViewModel
            {
                Id = 1,
                Title = "Book", 
                Categories = categoryDtos
            };

            CategoryController categoryController = new CategoryController(m_CategoryControllerHandlerMock);

            ActionResult result = categoryController.Index() as ActionResult;

            Assert.IsNotNull(result);

        }

        private void Init()
        {
            m_CategoryControllerHandlerMock = Substitute.For<ICategoryControllerHandler>();
        }
    }
}