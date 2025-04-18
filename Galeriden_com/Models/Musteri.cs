﻿using System.ComponentModel.DataAnnotations;

namespace Galeriden_com.Models
{
    public class Musteri
    {
        [Key]
        public int Id { get; set; }
        public string? Adi { get; set; }
        public string? Soyadi { get; set; }
        public string? Adres { get; set; }
        public string? Telefon { get; set; }
        public string? Type { get; set; }
        public string? ResimYolu { get; set; }
        public ICollection<SatinAlma> SatinAlma { get; set; }
    }
}
