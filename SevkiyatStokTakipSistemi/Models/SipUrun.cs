using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SevkiyatStokTakipSistemi.Models
{
    public class SipUrun
    {
        public int UrunId { get; set; }
        public int SiparisId { get; set; }
        public Siparis Siparis { get; set; }
        public Urun Urun { get; set; }
    }
}
