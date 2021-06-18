using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SevkiyatStokTakipSistemi.Models
{
    public class Sevkiyat
    {
        public int SevkiyatId { get; set; }
        public string DurumBildir { get; set; }

        [Required(ErrorMessage ="Bu Alan Gereklidir!")]
        public string TeslimAlcakKisi { get; set; }

        [Range(0,15)]
        [Required(ErrorMessage = "Bu Alan Gereklidir!")]
        public int TeslimKisiTelNo { get; set; }

        [Required(ErrorMessage = "Bu Alan Gereklidir!")]
        public string SevkYuklemeyiyapanKisi { get; set; }

        public string YuklemeYardimi { get; set; }

        //public bool DuzenlemeTalebi { get; set; }
        public ICollection<SevkiyatAraci> SevkiyatAraclari { get; set; }
        public ICollection<SipSevkiyat> SipSevkiyats { get; set; }
       

    }
}
