using System;
using System.Web.Mvc;
using System.Web.Routing;
using Microsoft.Practices.Unity;

namespace RepositoryPattern
{
    public sealed class CustomControllerFactory : DefaultControllerFactory
    {
        /// <summary>
        /// Retrieves the controller instance for the specified request context and controller type.
        /// </summary>
        /// <param name="requestContext">The context of the HTTP request, which includes the HTTP context and route data.</param>
        /// <param name="controllerType">The type of the controller.</param>
        /// <returns>
        /// The controller instance.
        /// </returns>
        /// <exception cref="System.ArgumentNullException"></exception>
        /// <exception cref="System.ArgumentException">controllerType</exception>
        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            try
            {
                if (controllerType == null)
                {
                    throw new ArgumentNullException();
                }

                if (!typeof(IController).IsAssignableFrom(controllerType))
                    throw new ArgumentException(string.Format("Type requested is not a controller:{0}", controllerType.Name),
                        "controllerType");

                return MvcUnityContainer.Container.Resolve(controllerType) as IController;
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// The MvcUnityContainer static class
        /// </summary>
        public static class MvcUnityContainer
        {
            public static UnityContainer Container { get; set; }
        }
    }
}