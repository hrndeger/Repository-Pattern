﻿using System;
using System.ComponentModel.DataAnnotations;

namespace RepositoryPattern.Models
{
    [Serializable]
    public sealed class CategoryEditViewModel
    {        
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Title")]
        public string Title { get; set; }
    }
}