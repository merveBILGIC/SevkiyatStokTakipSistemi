using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SevkiyatStokTakipSistemi.Models
{
    public class AracBilgisi
    {
        public int AracBilgisiId { get; set; }

        [Required(ErrorMessage = "Bu Alan Gereklidir!")]
        public string  AracPlakasi { get; set; }

        [Required(ErrorMessage = "Bu Alan Gereklidir!")]
        public string AracKapasitesi { get; set; }

        [Required(ErrorMessage = "Bu Alan Gereklidir!")]
        public string AracTipi { get; set; }
      
       
    }
}
