using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SevkiyatStokTakipSistemi.Data;
using SevkiyatStokTakipSistemi.Models;
using SevkiyatStokTakipSistemi.ViewModel;

namespace SevkiyatStokTakipSistemi.Controllers
{
    public class FirmaController : Controller
    {
        private readonly AppDbContext _context;

        public FirmaController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Firma
        public async Task<IActionResult> Index()
        {
            return View(await _context.Firmalar.ToListAsync());
        }

        // GET: Firma/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var firma = await _context.Firmalar
                .FirstOrDefaultAsync(m => m.FirmaId == id);
            if (firma == null)
            {
                return NotFound();
            }

            return View(firma);
        }

        // GET: Firma/Create
        public IActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int? id,[Bind("MusteriKodu,Telnon,CariIsim,FirmaAdresi,FirmaVergiNum,FirmaVergiDairesi,FirmaİlgiliKisi,İlgiliKisiTel")] Firma firma)
        {
            if (id != null)
            {
                firma.FirmaSiparisleri.Add(new SipFirma { SiparisId = (int)id });
                
            }
            if (ModelState.IsValid)
            {
                _context.Add(firma);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
           if(id!=null)
           { return RedirectToAction(nameof(SiparisFirma), new {id}); }
            return View(firma);
        }

        // GET: Firma/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var firma = await _context.Firmalar.FindAsync(id);
            if (firma == null)
            {
                return NotFound();
            }
            return View(firma);
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FirmaId,MusteriKodu,Telnon,CariIsim,FirmaAdresi,FirmaVergiNum,FirmaVergiDairesi,FirmaİlgiliKisi,İlgiliKisiTel")] Firma firma)
        {
            if (id != firma.FirmaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(firma);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FirmaExists(firma.FirmaId))
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
            return View(firma);
        }

        // GET: Firma/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var firma = await _context.Firmalar
                .FirstOrDefaultAsync(m => m.FirmaId == id);
            if (firma == null)
            {
                return NotFound();
            }

            return View(firma);
        }

        // POST: Firma/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var firma = await _context.Firmalar.FindAsync(id);
            _context.Firmalar.Remove(firma);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FirmaExists(int id)
        {
            return _context.Firmalar.Any(e => e.FirmaId == id);
        }

        [HttpGet]
        public IActionResult SiparisFirma()
		{
            List<Firma> FirmaListesi = new List<Firma>();
            FirmaListesi = (from firma in _context.Firmalar
                            select firma).ToList();
            FirmaSiparisiViewModel FSModel = new FirmaSiparisiViewModel();
            FSModel.FirmalarinListesi = FirmaListesi;
            FSModel.SeciliFirma = string.Empty;
            return View(FSModel);
		}


        [HttpPost]
		public IActionResult SiparisFirma(FirmaSiparisiViewModel model)
		{
            /*var siparis = _context.Siparisler
				.Include(x => x.FirmaSiparisleri)
				.ThenInclude(x => x.Firma)
				.SingleOrDefault(x => x.SiparisId == id);
            var siparisinUrunleri = siparis.FirmaSiparisleri.Select(z => z.Firma);*/
              string SelectedValue = model.SeciliFirma;
                List<Firma> FirmaListesi = new List<Firma>();
                FirmaListesi = (from firma in _context.Firmalar
                                select firma).ToList();

                model.FirmalarinListesi = FirmaListesi;

                List<SipFirma> Firmas = new List<SipFirma>();
                //Firmas.Add(new SipFirma{SiparisId=(int)id});

                Firma firma1 = new Firma();
                ViewBag.firmaadi = firma1.CariIsim;
           
           return RedirectToAction("Create","Siparis",new {model});
            
        }
	}
}
