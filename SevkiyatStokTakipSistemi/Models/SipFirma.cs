using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SevkiyatStokTakipSistemi.Models
{
    public class SipFirma
    {
        public int SiparisId { get; set; }
        public int FirmaId { get; set; }

        public Siparis Siparis { get; set; }
        public Firma Firma { get; set; }
    }
}
