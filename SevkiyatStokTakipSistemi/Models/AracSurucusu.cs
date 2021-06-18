using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SevkiyatStokTakipSistemi.Models
{
    public class AracSurucusu
    {
        public int AracBilgisiId { get; set; }
        public AracBilgisi AracBilgisi { get; set; }
        public int SurucuId { get; set; }
        public Surucu Surucu { get; set; }
    }
}
