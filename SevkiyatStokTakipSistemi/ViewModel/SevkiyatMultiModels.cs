using SevkiyatStokTakipSistemi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SevkiyatStokTakipSistemi.ViewModel
{
	public class SevkiyatMultiModels
	{
		public Tuple<List<Sevkiyat>,List<Siparis>,List<AracBilgisi>,List<AracSurucusu>> Tuple { get; set; }
	}
}
