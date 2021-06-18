using SevkiyatStokTakipSistemi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SevkiyatStokTakipSistemi.ViewModel
{
	public class FSUViewModel
	{

		public Urun Urun1 { get; set; }
		public Firma Frm1 { get; set; }
		public Siparis Spr1 { get; set; }

		public IEnumerable<Siparis> Siparisler { get; set; }

		public IEnumerable<Firma> FirmaSiparisleriData { get; set; }

		public IEnumerable<Urun> SiparislerUrunData { get; set; }


	}
}
