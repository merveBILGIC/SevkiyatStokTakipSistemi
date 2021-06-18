using SevkiyatStokTakipSistemi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SevkiyatStokTakipSistemi.ViewModel
{
	public class FirmaDoldur
	{
		public int FirmaId { get; set; }
		public Firma Firmadoldur { get; set; }
		public string Selectedfirma { get; set; }
	}
}
