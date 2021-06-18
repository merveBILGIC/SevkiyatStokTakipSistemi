using Microsoft.AspNetCore.Mvc.Rendering;
using SevkiyatStokTakipSistemi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SevkiyatStokTakipSistemi.ViewModel
{
    public class IndexSiparisViewModel
    {
        public IEnumerable<Siparis> Siparisler { get; set; }

        public IEnumerable<Firma> FirmaSiparisleriData { get; set; }

        public IEnumerable<Urun> SiparislerUrunData { get; set; } 

        public int FirmaId { get; set; }
       
    }
}
