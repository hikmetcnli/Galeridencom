using System.ComponentModel.DataAnnotations;

namespace Galeriden_com.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

         
        [StringLength(250)]
        public string ?SurName { get; set; }

        public double Price { get; set; }

    }
}
