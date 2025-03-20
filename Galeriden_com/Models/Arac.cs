using System.ComponentModel.DataAnnotations;

namespace Galeriden_com.Models
{
    public class Arac
    {
        [Key]
        public int Id { get; set; }
        public int Model { get; set; }

        [Required]
        [StringLength(50)]
        public string Marka { get; set; }

        [Required]
        [StringLength(20)]
        public string Plaka { get; set; }

        public double Fiyat { get; set; }

    }
}
