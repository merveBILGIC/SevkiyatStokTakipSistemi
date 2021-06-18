using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SevkiyatStokTakipSistemi.Models
{
    public class SevkiyatAraci
    {
        public int SevkiyatId { get; set; }
        public int AracBilgisiId { get; set; }
        public Sevkiyat Sevkiyat { get; set; }
        public AracBilgisi AracBilgisi { get; set; }
    }
}
