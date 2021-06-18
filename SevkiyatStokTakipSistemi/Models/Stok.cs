using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SevkiyatStokTakipSistemi.Models
{
    public class Stok
    {
        public int StokId { get; set; }
        [Required(ErrorMessage = "Bu Alan Gereklidir")]
        
        public int StokAdedi { get; set; }
        [Required(ErrorMessage = "Bu Alan Gereklidir")]
        public int StokBirimi { get; set; }

       
        public  int UrunForeingKey { get; set; }
        public Urun Urunler { get; set; }
    }
}
