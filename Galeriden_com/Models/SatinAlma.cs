using System.ComponentModel.DataAnnotations;

namespace Galeriden_com.Models
{
    public class SatinAlma
    {
        [Key]
        public int Id { get; set; }

        public int MID { get; set; }
        public Musteri musteri { get; set; }

        public int AID { get; set; }
        public Arac arac { get; set; }

        public double AlimFiyati { get; set; }
        public DateTime AlimFiyatiDate { get; set; }


    }
}
