using System.ComponentModel.DataAnnotations;

namespace Galeriden_com.Models
{
    public class SatinAlma
    {
        [Key]
        public int Id { get; set; }

        public int MusteriID { get; set; }
        public virtual Musteri musteri { get; set; }

        public int AracID { get; set; }
        public virtual Arac arac { get; set; }

        public double AlimFiyati { get; set; }
        public DateTime AlimFiyatiDate { get; set; }


    }
}
