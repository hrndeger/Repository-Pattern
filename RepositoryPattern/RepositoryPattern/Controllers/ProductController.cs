using System;
using System.Collections.Generic;
using System.Web.Mvc;
using RepositoryPattern.ControllerHandler.Interface;
using RepositoryPattern.Core.Exceptions;
using RepositoryPattern.Core.Extension;
using RepositoryPattern.Dto;
using RepositoryPattern.Models;

namespace RepositoryPattern.Controllers
{
    public class ProductController : Controller
    {
        #region Fields

        private readonly ICategoryControllerHandler m_CategoryControllerHandler;
        private readonly IProductControllerHandler m_ProductControllerHandler;

        #endregion

        #region Ctor

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductController"/> class.
        /// </summary>
        /// <param name="productControllerHandler">The product controller handler.</param>
        /// <param name="categoryControllerHandler">The category controller handler.</param>
        /// <exception cref="System.ArgumentNullException">
        /// </exception>
        public ProductController(IProductControllerHandler productControllerHandler,
            ICategoryControllerHandler categoryControllerHandler)
        {
            if (productControllerHandler == null)
            {
                throw new ArgumentNullException(string.Format("IProductControllerHandler should not be empty."));
            }
            if (categoryControllerHandler == null)
            {
                throw new ArgumentNullException(string.Format("ICategoryControllerHandler should not be empty."));
            }

            m_ProductControllerHandler = productControllerHandler;
            m_CategoryControllerHandler = categoryControllerHandler;
        }

        #endregion

        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            IList<ProductDto> products = m_ProductControllerHandler.GetProducts();

            ProductViewModel productViewModel = new ProductViewModel
            {
                ProductDtos = products
            };

            return View(productViewModel);
        }

        /// <summary>
        /// Creates this instance.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Create()
        {
            IList<CategoryDto> categories = m_CategoryControllerHandler.GetCategories();

            ProductViewModel productViewModel = new ProductViewModel();

            if (!categories.IsNullOrDefault())
            {
                productViewModel.Categories = categories.ToSelectListItems(x => x.Id.ToString(), x => x.Title);
            }

            return View(productViewModel);
        }

        /// <summary>
        /// Creates the specified product view model.
        /// </summary>
        /// <param name="productViewModel">The product view model.</param>
        /// <returns></returns>
        /// <exception cref="RepositoryPattern.Core.Exceptions.CustomException"></exception>
        [HttpPost]
        public ActionResult Create(ProductViewModel productViewModel)
        {
            if (productViewModel.IsNullOrDefault())
            {
                throw new CustomException(string.Format("Argument should not be null. {0}", productViewModel));
            }

            bool result = m_ProductControllerHandler.Save(new ProductDto
              {
                  Id = productViewModel.Id,
                  Title = productViewModel.Title,
                  Quantity = productViewModel.Quantity,
                  UnitPrice = productViewModel.UnitPrice,
                  CategoryId = productViewModel.CategoryId
              });

            return result ? RedirectToAction("Index") : RedirectToRoute("Error");

        }

        /// <summary>
        /// Edits the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Edit(int id)
        {
            ProductDto product = m_ProductControllerHandler.GetProduct(id);

            IList<CategoryDto> categories = m_CategoryControllerHandler.GetCategories();

            if (!product.IsNullOrDefault())
            {
                ProductEditViewModel productEditViewModel = new ProductEditViewModel
                {
                    Id = product.Id,
                    Title = product.Title,
                    Quantity = product.Quantity,
                    UnitPrice = product.UnitPrice,
                    CategoryId = product.CategoryId,
                    Categories = categories.ToSelectListItems(x => x.Id.ToString(), x => x.Title)
                };

                return View(productEditViewModel);
            }

            return RedirectToRoute("Error");
        }

        /// <summary>
        /// Edits the specified product edit view model.
        /// </summary>
        /// <param name="productEditViewModel">The product edit view model.</param>
        /// <returns></returns>
        /// <exception cref="RepositoryPattern.Core.Exceptions.CustomException"></exception>
        [HttpPost]
        public ActionResult Edit(ProductEditViewModel productEditViewModel)
        {
            if (productEditViewModel.IsNullOrDefault())
            {
                throw new CustomException(string.Format("Argument should not be null. {0}", productEditViewModel));
            }

            try
            {
                m_ProductControllerHandler.Save(new ProductDto
                {
                    Id = productEditViewModel.Id,
                    Title = productEditViewModel.Title,
                    Quantity = productEditViewModel.Quantity,
                    UnitPrice = productEditViewModel.UnitPrice,
                    CategoryId = productEditViewModel.CategoryId
                });

                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return RedirectToRoute("Error");
            }
        }

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="RepositoryPattern.Core.Exceptions.CustomException"></exception>
        public ActionResult Delete(int id)
        {
            if (id == default(int))
            {
                throw new CustomException(string.Format("Argument should not be null. {0}", id));
            }

            ProductDto productDto = m_ProductControllerHandler.GetProduct(id);

            return View(new ProductEditViewModel
            {
                Id = productDto.Id,
                Title = productDto.Title,
                CategoryId = productDto.CategoryId,
                Quantity = productDto.Quantity,
                UnitPrice = productDto.UnitPrice,
            });
        }

        /// <summary>
        /// Deletes the specified product edit view model.
        /// </summary>
        /// <param name="productEditViewModel">The product edit view model.</param>
        /// <returns></returns>
        /// <exception cref="CustomException"></exception>
        [HttpPost]
        public JsonResult Delete(ProductEditViewModel productEditViewModel)
        {
            JsonResultModel jsonResultModel = new JsonResultModel();

            if (productEditViewModel.IsNullOrDefault())
            {
                throw new CustomException(string.Format("Argument should not be null. {0}", productEditViewModel));
            }

            bool isSuccess = m_ProductControllerHandler.Delete(productEditViewModel.Id);

            if (isSuccess)
            {
                jsonResultModel.IsSuccess = true;
                jsonResultModel.Message = "Silme işlemi başarılı";
            }
            else
            {
                jsonResultModel.IsSuccess = default(bool);
                jsonResultModel.Message = "Error!!!";
            }

            return Json(jsonResultModel,JsonRequestBehavior.AllowGet);
        }
    }
}
