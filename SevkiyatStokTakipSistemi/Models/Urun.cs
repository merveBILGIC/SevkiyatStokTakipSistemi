using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SevkiyatStokTakipSistemi.Models
{
    public class Urun
    {
        public int UrunId { get; set; }

       
        
        public string UrunName { get; set; }
       
       
        public string UrunKodu { get; set; }
       

       
        public string UrunBirimi { get; set; }

        public string Resimyolu { get; set; }
        [NotMapped]
        public IFormFile Resim { get; set; }

        public Stok Stok { get; set; }

        public ICollection<SipUrun> UrunSiparisleri { get; set; }
     

    }
}
