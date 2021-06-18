using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SevkiyatStokTakipSistemi.Models
{
    public class AtananUrunVerileri
    {
        public int UrunId { get; set; }
        public string UrunName { get; set; }
        public string UrunKodu { get; set; }
        public string UrunBirimi { get; set; }
        public string Resimyolu { get; set; }
        public bool Assigned { get; set; }
    }
}
