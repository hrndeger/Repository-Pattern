using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using RepositoryPattern.Dto;

namespace RepositoryPattern.Models
{
    [Serializable]
    public sealed class ProductViewModel
    {
        private IList<SelectListItem> m_CategorySelectedListItems;
        private IList<ProductDto> m_ProductDtos;


        [Required]
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Title")]
        public string Title { get; set; }

        [Display(Name = "UnitPrice")]
        public decimal UnitPrice { get; set; }

        [Display(Name = "Quantity")]
        public int Quantity { get; set; }

        [Required]
        [Display(Name = "CategoryId")]
        public int CategoryId { get; set; }

        [Display(Name = "Category Name")]
        public string CategoryName { get; set; }

        public IList<SelectListItem> Categories
        {
            get { return m_CategorySelectedListItems ?? (m_CategorySelectedListItems = new List<SelectListItem>()); }
            set { m_CategorySelectedListItems = value; }
        }

        public IList<ProductDto> ProductDtos
        {
            get { return m_ProductDtos ?? (m_ProductDtos = new List<ProductDto>()); }
            set { m_ProductDtos = value; }
        } 
    }
}