using SevkiyatStokTakipSistemi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SevkiyatStokTakipSistemi.ViewModel
{
	public class MultipleModels
	{
		public Tuple<List<Firma>, List<Urun>, List<Siparis>> Tub { get; set; }
	}
}
