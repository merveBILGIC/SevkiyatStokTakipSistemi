using SevkiyatStokTakipSistemi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SevkiyatStokTakipSistemi.ViewModel
{
	public class FirmaSiparisiViewModel
	{
		public string SeciliFirma { get; set; }
		public List<Firma> FirmalarinListesi = new List<Firma>();
		
	}
}
