using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SevkiyatStokTakipSistemi.Models
{
    public class Surucu
    {
        public int SurucuId { get; set; }
        [Required(ErrorMessage ="Bu Alan Gereklidir!")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Bu Alan Gereklidir!")]
        public string LastName { get; set; }
       
        [Required(ErrorMessage = "Bu Alan Gereklidir!")]
        public int Telno { get; set; }
      
        
       
    }
}
