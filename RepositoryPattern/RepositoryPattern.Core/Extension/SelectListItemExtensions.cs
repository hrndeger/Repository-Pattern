using System;
using System.Collections.Generic;
using System.Web.Mvc;
using RepositoryPattern.Core.Exceptions;

namespace RepositoryPattern.Core.Extension
{
    public static class SelectListItemExtensions
    {
        /// <summary>
        /// To the select list items.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <param name="items">The items.</param>
        /// <param name="valueSelector">The value selector.</param>
        /// <param name="textSelector">The text selector.</param>
        /// <returns></returns>
        /// <exception cref="CustomException">
        /// </exception>
        public static IList<SelectListItem> ToSelectListItems<TModel>(this IList<TModel> items, Func<TModel, string> valueSelector, Func<TModel, string> textSelector)
        {
           
            if (items.IsNullOrDefault())
            {
                throw new CustomException(String.Format("Argument should not be null. {0}",items));
            }

            if (valueSelector.IsNullOrDefault())
            {
                throw new CustomException(String.Format("Argument should not be null. {0}", valueSelector));
            }

            if (textSelector.IsNullOrDefault())
            {
                throw new CustomException(String.Format("Argument should not be null. {0}", textSelector));
            }

            IList<SelectListItem> result = new List<SelectListItem>(items.Count);

            //IList<SelectListItem> result = new List<SelectListItem>(addSelectListChooseItem ? items.Count + 1 : items.Count);
            //if (addSelectListChooseItem)
            //{
            //    result.Add(new SelectListItem
            //    {
            //        Text = Strings.SelectListChooseItemText,
            //        Value = selectListChooseItemValue ?? string.Empty
            //    });
            //}

            foreach (TModel item in items)
            {
                result.Add(new SelectListItem
                {
                    Text = textSelector(item),
                    Value = valueSelector(item)
                });
            }

            return result;
        }
    }
}