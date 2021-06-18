using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SevkiyatStokTakipSistemi.Models
{
    public class Siparis
    {
        public int SiparisId { get; set; }

        public string  SiparisAcıklama { get; set; } 

        public DateTime SiparisTarihi { get; set; }

        
        public DateTime TeslimTarihi { get; set; }

      
        public string UrunMiktari { get; set; }

        public string Durum { get; set; }

       
        public string SevkAdresi { get; set; }

        public ICollection<SipFirma> FirmaSiparisleri { get; set; }
        public ICollection<SipUrun> UrunSiparisleri { get; set; }
        public ICollection<SipSevkiyat> SipSevkiyats { get; set; }
      

    }
}
