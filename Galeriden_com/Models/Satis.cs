using System.ComponentModel.DataAnnotations;

namespace Galeriden_com.Models
{
    public class Satis
    {
        [Key]
        public int Id { get; set; }

        public int MusteriID { get; set; }
        public virtual Musteri musteri { get; set; }

        public int AracID { get; set; }
        public virtual Arac arac { get; set; }

        public double SatisFiyati { get; set; }
        public DateTime SatisFiyatiDate { get; set; }
    }
}
