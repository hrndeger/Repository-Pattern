using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Mvc;
using RepositoryPattern.ControllerHandler;
using RepositoryPattern.ControllerHandler.Interface;
using RepositoryPattern.Controllers;
using RepositoryPattern.Core.UOW;
using RepositoryPattern.Data.Dao;
using RepositoryPattern.Data.UOW;
using RepositoryPattern.Manager;
using RepositoryPattern.Mapping;

namespace RepositoryPattern
{
    public sealed class Bootstrapper
    {
        public static IUnityContainer Initialise()
        {
            IUnityContainer container = BuildUnityContainer();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
            return container;
        }

        /// <summary>
        /// Builds the unity container.
        /// </summary>
        /// <returns></returns>
        private static IUnityContainer BuildUnityContainer()
        {
            UnityContainer container = new UnityContainer();

            #region  Category

            container.RegisterType<IMapper, ShoppingMapper>();
            //container.RegisterType<IShopDao, EntityFrameworkShopDao>();
            container.RegisterType<IShopDao, EntityFrameworkCEShopDao>();
          //  container.RegisterType<IUnitOfWork, ShopUnitOfWork>();
            container.RegisterType<IUnitOfWork, ShopCEUnitOfWork>();
            container.RegisterType<IShoppingManager, ShoppingManager>();
            container.RegisterType<ICategoryControllerHandler, CategoryControllerHandler>();
            container.RegisterType<IController, CategoryController>("Category");

            #endregion

            #region Product

            container.RegisterType<IProductControllerHandler, ProductControllerHandler>();
            container.RegisterType<IController, ProductController>("Product");

            #endregion

            CustomControllerFactory.MvcUnityContainer.Container = container;
            return container;
        }
    }
}