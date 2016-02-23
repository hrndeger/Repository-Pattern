using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RepositoryPattern.Data.Entity
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }
        
        public virtual ICollection<Product> Products { get; set; }
    }
}