using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RepositoryPattern.Data.Entity
{
    public class Product
    {
        [Required]
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }
        
        public decimal UnitPrice { get; set; }
        
        public int Quantity { get; set; }
        
        [Required]
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        
        public virtual Category Category { get; set; }
    }
}