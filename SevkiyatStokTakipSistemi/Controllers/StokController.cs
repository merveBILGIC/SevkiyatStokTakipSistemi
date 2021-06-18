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
    public class StokController : Controller
    {
        private readonly AppDbContext _context;

        public StokController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Stok
        public async Task<IActionResult> Index()
        {
            return View(await _context.Stoklar.ToListAsync());
        }

        // GET: Stok/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stok = await _context.Stoklar
                .FirstOrDefaultAsync(m => m.StokId == id);
            if (stok == null)
            {
                return NotFound();
            }

            return View(stok);
        }

        // GET: Stok/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StokId,StokAdedi,StokBirimi")] Stok stok)
        {
            if (ModelState.IsValid)
            {
                _context.Add(stok);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(stok);
        }

        // GET: Stok/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stok = await _context.Stoklar.FindAsync(id);
            if (stok == null)
            {
                return NotFound();
            }
            return View(stok);
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StokId,StokAdedi,StokBirimi")] Stok stok)
        {
            if (id != stok.StokId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(stok);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StokExists(stok.StokId))
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
            return View(stok);
        }

        // GET: Stok/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stok = await _context.Stoklar
                .FirstOrDefaultAsync(m => m.StokId == id);
            if (stok == null)
            {
                return NotFound();
            }

            return View(stok);
        }

        // POST: Stok/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var stok = await _context.Stoklar.FindAsync(id);
            _context.Stoklar.Remove(stok);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StokExists(int id)
        {
            return _context.Stoklar.Any(e => e.StokId == id);
        }
    }
}
