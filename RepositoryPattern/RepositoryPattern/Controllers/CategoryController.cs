using System;
using System.Collections.Generic;
using System.Threading;
using System.Web.Mvc;
using RepositoryPattern.ControllerHandler.Interface;
using RepositoryPattern.Core.Exceptions;
using RepositoryPattern.Core.Extension;
using RepositoryPattern.Dto;
using RepositoryPattern.Models;

namespace RepositoryPattern.Controllers
{
    public class CategoryController : Controller
    {
        #region Fields

        private readonly ICategoryControllerHandler m_CategoryControllerHandler;

        #endregion

        #region Ctor

        /// <summary>
        /// Initializes a new instance of the <see cref="CategoryController"/> class.
        /// </summary>
        /// <param name="categoryControllerHandler">The category controller handler.</param>
        /// <exception cref="System.ArgumentNullException"></exception>
        public CategoryController(ICategoryControllerHandler categoryControllerHandler)
        {
            if (categoryControllerHandler == null)
            {
                throw new ArgumentNullException(string.Format("ICategoryControllerHandler should not be empty."));
            }

            m_CategoryControllerHandler = categoryControllerHandler;
        }

        #endregion

        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            IList<CategoryDto> categoryDtos = m_CategoryControllerHandler.GetCategories();

            CategoryViewModel categoryViewModel = new CategoryViewModel
            {
                Categories = categoryDtos
            };

            return View(categoryViewModel);
        }

        /// <summary>
        /// Creates this instance.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Create()
        {
            return View(new CategoryViewModel());
        }

        /// <summary>
        /// Creates the specified category view model.
        /// </summary>
        /// <param name="categoryViewModel">The category view model.</param>
        /// <returns></returns>
        /// <exception cref="CustomException"></exception>
        [HttpPost]
        public ActionResult Create(CategoryViewModel categoryViewModel)
        {
            if (categoryViewModel.IsNullOrDefault())
            {
                throw new CustomException(string.Format("Argument should not be null. {0}", categoryViewModel));
            }

            bool result = m_CategoryControllerHandler.Save(new CategoryDto
            {
                Id = categoryViewModel.Id,
                Title = categoryViewModel.Title
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
            CategoryDto category = m_CategoryControllerHandler.GetCategory(id);

            if (!category.IsNullOrDefault())
            {
                CategoryEditViewModel categoryEditViewModel = new CategoryEditViewModel
                {
                    Id = category.Id,
                    Title = category.Title
                };

                return View(categoryEditViewModel);
            }

            return RedirectToRoute("Error");
        }

        /// <summary>
        /// Edits the specified category view model.
        /// </summary>
        /// <param name="categoryViewModel">The category view model.</param>
        /// <returns></returns>
        /// <exception cref="RepositoryPattern.Core.Exceptions.CustomException"></exception>
        [HttpPost]
        public ActionResult Edit(CategoryEditViewModel categoryViewModel)
        {
            if (categoryViewModel.IsNullOrDefault())
            {
                throw new CustomException(string.Format("Argument should not be null. {0}", categoryViewModel));
            }


            bool result = m_CategoryControllerHandler.Save(new CategoryDto
             {
                 Id = categoryViewModel.Id,
                 Title = categoryViewModel.Title
             });

            return result ? RedirectToAction("Index") : RedirectToRoute("Error");

        }

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="RepositoryPattern.Core.Exceptions.CustomException"></exception>
        [HttpGet]
        public ActionResult Delete(int id)
        {
            if (id == default(int))
            {
                throw new CustomException(string.Format("Argument should not be null. {0}", id));
            }

            CategoryDto categoryDto = m_CategoryControllerHandler.GetCategory(id);

            return View(new CategoryDeleteViewModel
            {
                Id = categoryDto.Id,
                Title = categoryDto.Title
            });
        }

        /// <summary>
        /// Deletes the specified category delete view model.
        /// </summary>
        /// <param name="categoryDeleteViewModel">The category delete view model.</param>
        /// <returns></returns>
        /// <exception cref="CustomException"></exception>
        [HttpPost]
        public JsonResult Delete(CategoryDeleteViewModel categoryDeleteViewModel)
        {
            Thread.Sleep(3000);

            JsonResultModel jsonResultModel = new JsonResultModel();

            if (categoryDeleteViewModel.IsNullOrDefault())
            {
                throw new CustomException(string.Format("Argument should not be null. {0}", categoryDeleteViewModel));
            }

            bool isSuccess = m_CategoryControllerHandler.Delete(categoryDeleteViewModel.Id);

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

            return Json(jsonResultModel, JsonRequestBehavior.AllowGet);
        }
    }
}
