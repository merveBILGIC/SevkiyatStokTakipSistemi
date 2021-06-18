using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SevkiyatStokTakipSistemi.Models
{
    public class Firma
    {
        public int FirmaId { get; set; }
       

        
        public int MusteriKodu { get; set; }

       
        
        public int Telnon { get; set; }

       
        public string CariIsim { get; set; }

        
        public string FirmaAdresi { get; set; }

       
        public int FirmaVergiNum { get; set; }

        
        
        public string FirmaVergiDairesi { get; set; }

        
        public string FirmaİlgiliKisi { get; set; }

        
        
        public int İlgiliKisiTel { get; set; }


        public ICollection<SipFirma> FirmaSiparisleri { get; set; }

    }
}
