using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using RepositoryPattern.Dto;

namespace RepositoryPattern.Models
{
    [Serializable]
    public sealed class CategoryViewModel
    {
        private IList<CategoryDto> m_CategoryDtos;

        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Title")]
        public string Title { get; set; }

        public IList<CategoryDto> Categories
        {
            get { return m_CategoryDtos ?? (m_CategoryDtos = new List<CategoryDto>()); }
            set { m_CategoryDtos = value; }
        } 
    }
}