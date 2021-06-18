using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SevkiyatStokTakipSistemi.Models
{
    public class SipSevkiyat
    {
        public int SiparisId { get; set; }
        public int SevkiyatId { get; set; }
        public Siparis Siparis { get; set; }
        public Sevkiyat Sevkiyat { get; set; }
    }
}
