using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using SevkiyatStokTakipSistemi.Data;
using SevkiyatStokTakipSistemi.Models;
using SevkiyatStokTakipSistemi.ViewModel;

namespace SevkiyatStokTakipSistemi.Controllers
{
    public class SiparisController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IHubContext<SignalrServer> _signalrHub;

        public SiparisController(AppDbContext context, IHubContext<SignalrServer> signalrHub)
        {
            _context = context;
            _signalrHub = signalrHub;
        }

        // GET: Siparis
        public async Task<IActionResult> Index()
        {
			FSUViewModel viewModel = new FSUViewModel
			{
				Siparisler = await _context.Siparisler
				 .Include(t => t.FirmaSiparisleri)
                      .ThenInclude(t => t.Firma)
               .Include(x => x.UrunSiparisleri)
                       .ThenInclude(x => x.Urun)
                .ToListAsync()
                
			};
          
			return View(viewModel);
           
        }

		#region
		public IActionResult GetProducts()
        {
            var res = _context.Siparisler
                .Include(c=>c.FirmaSiparisleri).ThenInclude(c=>c.Firma)
                .Include(t=>t.UrunSiparisleri).ThenInclude(t=>t.Urun)
                .ToListAsync();
                
            return Json(res);
        }
		#endregion

		// GET: Siparis/Details/5
		public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var siparis = await _context.Siparisler
                .FirstOrDefaultAsync(m => m.SiparisId == id);
            if (siparis == null)
            {
                return NotFound();
            }

            return View(siparis);
        }

        // GET: Siparis/Create
        public IActionResult Create()
        {
            DDL_Urun();
            DDl_Firma();
            return View();
           
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(FSUViewModel model)
        {
            var firmaEkle = model.Frm1.FirmaId;
            var urunEkle = model.Urun1.UrunId;
            Firma firma = new Firma()
            {
                FirmaId = model.Frm1.FirmaId,
                FirmaAdresi = model.Frm1.FirmaAdresi,
                CariIsim = model.Frm1.CariIsim,
                MusteriKodu = model.Frm1.MusteriKodu,
                Telnon = model.Frm1.Telnon,
                İlgiliKisiTel = model.Frm1.İlgiliKisiTel,
                FirmaVergiDairesi = model.Frm1.FirmaVergiDairesi,
                FirmaVergiNum = model.Frm1.FirmaVergiNum,
                FirmaİlgiliKisi = model.Frm1.FirmaİlgiliKisi,

            };
            Urun urun = new Urun()
            {
                UrunId = model.Urun1.UrunId,
                UrunBirimi = model.Urun1.UrunBirimi,
                UrunName = model.Urun1.UrunName,
                Resimyolu = model.Urun1.Resimyolu,
            };
            Siparis siparis = new Siparis()
            {
                SiparisId = model.Spr1.SiparisId,
                SiparisAcıklama = model.Spr1.SiparisAcıklama,
                SiparisTarihi = DateTime.Now,
                TeslimTarihi=model.Spr1.TeslimTarihi,
                SevkAdresi = model.Spr1.SevkAdresi,
                Durum = model.Spr1.Durum,
                UrunMiktari = model.Spr1.UrunMiktari,


            };
            model = new FSUViewModel()
            {
                Spr1 = siparis,
                Frm1 = firma,
                Urun1 = urun,
            };

            
            if (ModelState.IsValid)
            {
                _context.Siparisler.Add(siparis);
                await _context.SaveChangesAsync();
              

                if (firmaEkle != 0)
                {

                    var AddToFirma = new SipFirma { SiparisId=siparis.SiparisId, FirmaId = model.Frm1.FirmaId ,Firma=model.Frm1, Siparis=siparis};
                    model.Spr1.FirmaSiparisleri.Add(AddToFirma);

                    _context.FirmaSiparisleri.Add(AddToFirma);
                    await _context.SaveChangesAsync();
                }
                if (urunEkle != 0)
                {

                    var AddToUrun = new SipUrun { SiparisId = siparis.SiparisId, UrunId = model.Urun1.UrunId };
                    model.Spr1.UrunSiparisleri.Add(AddToUrun);
                    _context.UrunSiparisler.Add(AddToUrun);
                    await _context.SaveChangesAsync();

                }
               
                await _signalrHub.Clients.All.SendAsync("LoadProducts");
                RedirectToAction(nameof(Index));
            }
            

            //ChechBoxUrunDoldur(model);
            DDL_Urun(urunEkle);
            DDl_Firma(firmaEkle);

            return View(model);
        }

        // GET: Siparis/Edit/5
        /// <summary>
        /// bu fonksiyon düzenleme yetkisi olanlar tarafından görünecek 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var siparis = await _context.Siparisler
                .Include(c => c.FirmaSiparisleri)
                .ThenInclude(c => c.Firma)
                .Include(x => x.UrunSiparisleri)
                .ThenInclude(x => x.Urun)
                .FirstOrDefaultAsync(m => m.SiparisId == id);
            //.FindAsync(id);
            if (siparis == null)
            {
                return NotFound();
            }
           
            return View(siparis);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int SiparisId, [Bind("SiparisId,SiparisAcıklama,SiparisTarihi,TeslimTarihi")] Siparis siparis, string[] selectedUrunler)
        {
            if (SiparisId != siparis.SiparisId)
            {
                return NotFound();
            }

            var SiparisDüzenle=await _context.Siparisler
                 .Include(c => c.FirmaSiparisleri)
                .ThenInclude(c => c.Firma)
                .Include(x => x.UrunSiparisleri)
                .ThenInclude(x => x.Urun)
                .FirstOrDefaultAsync(m => m.SiparisId == SiparisId);

           
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(siparis);
                    await _context.SaveChangesAsync();
                    await _signalrHub.Clients.All.SendAsync("LoadProducts");
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SiparisExists(siparis.SiparisId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(siparis);
        }



        private void SiparisDüzenleme(string[] selectedUrunler,Siparis siparisDüzenle)
        {
            if (selectedUrunler==null)
            { 
                siparisDüzenle.UrunSiparisleri= new List<SipUrun>();
                return;
            }

            var selectedUrunlerHS = new HashSet<string>(selectedUrunler);
            var urunsip = new HashSet<int>
                (siparisDüzenle.UrunSiparisleri.Select(c => c.UrunId));
            foreach(var urun in _context.Urunler)
            {
                if(selectedUrunlerHS.Contains(urun.UrunId.ToString()))
                {
                    if(!urunsip.Contains(urun.UrunId))
                    {
                        siparisDüzenle.UrunSiparisleri.Add(new SipUrun { SiparisId = siparisDüzenle.SiparisId, UrunId = urun.UrunId });

                    }
                }
                else
                {
                    if(urunsip.Contains(urun.UrunId))
                    {
                        SipUrun removeToUrun = siparisDüzenle.UrunSiparisleri.FirstOrDefault(i => i.UrunId == urun.UrunId);
                        _context.Remove(removeToUrun);
                    }
                }
            }
        }

        // GET: Siparis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var siparis = await _context.Siparisler
                .FirstOrDefaultAsync(m => m.SiparisId == id);
            if (siparis == null)
            {
                return NotFound();
            }

            return View(siparis);
        }

        // POST: Siparis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int SiparisId)
        {
            Siparis siparis = await _context.Siparisler
                 .Include(i => i.UrunSiparisleri)
                 .Include(i=>i.FirmaSiparisleri)
                 .SingleAsync(i => i.SiparisId == SiparisId);
                
          
            _context.Siparisler.Remove(siparis);
            await _context.SaveChangesAsync();
            await _signalrHub.Clients.All.SendAsync("LoadProducts");
            return RedirectToAction(nameof(Index));
        }

        private bool SiparisExists(int id)
        {
            return _context.Siparisler.Any(e => e.SiparisId == id);
        }


        
        public void DDl_Firma(object selectedFirma=null)
		{
             var departmentsQuery = from d in _context.Firmalar
                                    orderby d.CariIsim
                                    select d;
             ViewBag.Firma = new SelectList(departmentsQuery.AsNoTracking(), "FirmaId", "CariIsim", selectedFirma);
            

        }
        public void DDL_Urun(object seletedUrun=null)
		{
            var urunquery = from t in _context.Urunler
                            orderby t.UrunName
                            select t;
            ViewBag.Urun = new SelectList(urunquery.AsNoTracking(), "UrunId", "UrunName", seletedUrun);
		}


    }   
}
