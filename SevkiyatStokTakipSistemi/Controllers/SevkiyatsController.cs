using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SevkiyatStokTakipSistemi.Data;
using SevkiyatStokTakipSistemi.Models;

namespace SevkiyatStokTakipSistemi.Controllers
{
    public class SevkiyatsController : Controller
    {
        private readonly AppDbContext _context;

        public SevkiyatsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Sevkiyats
        public async Task<IActionResult> Index()
        {
            return View(await _context.Sevkiyatlar.ToListAsync());
        }

        // GET: Sevkiyats/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sevkiyat = await _context.Sevkiyatlar
                .FirstOrDefaultAsync(m => m.SevkiyatId == id);
            if (sevkiyat == null)
            {
                return NotFound();
            }

            return View(sevkiyat);
        }

        // GET: Sevkiyats/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sevkiyats/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SevkiyatId,DurumBildir,TeslimAlcakKisi,TeslimKisiTelNo,SevkAdresi,SevkYuklemeyiyapanKisi,YuklemeYardimi")] Sevkiyat sevkiyat)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sevkiyat);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sevkiyat);
        }

        // GET: Sevkiyats/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sevkiyat = await _context.Sevkiyatlar.FindAsync(id);
            if (sevkiyat == null)
            {
                return NotFound();
            }
            return View(sevkiyat);
        }

        // POST: Sevkiyats/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SevkiyatId,DurumBildir,TeslimAlcakKisi,TeslimKisiTelNo,SevkAdresi,SevkYuklemeyiyapanKisi,YuklemeYardimi")] Sevkiyat sevkiyat)
        {
            if (id != sevkiyat.SevkiyatId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sevkiyat);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SevkiyatExists(sevkiyat.SevkiyatId))
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
            return View(sevkiyat);
        }

        // GET: Sevkiyats/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sevkiyat = await _context.Sevkiyatlar
                .FirstOrDefaultAsync(m => m.SevkiyatId == id);
            if (sevkiyat == null)
            {
                return NotFound();
            }

            return View(sevkiyat);
        }

        // POST: Sevkiyats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sevkiyat = await _context.Sevkiyatlar.FindAsync(id);
            _context.Sevkiyatlar.Remove(sevkiyat);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SevkiyatExists(int id)
        {
            return _context.Sevkiyatlar.Any(e => e.SevkiyatId == id);
        }
    }
}
