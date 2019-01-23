using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Fakturisanje.Models;

namespace Fakturisanje.Controllers
{
    public class StavkaController : Controller
    {
        private readonly FakturisanjeContext _context;

        public StavkaController(FakturisanjeContext context)
        {
            _context = context;
        }

        // GET: Stavka
        public async Task<IActionResult> Index()
        {
            var fakturisanjeContext = _context.Stavke.Include(s => s.Faktura);
            return View(await fakturisanjeContext.ToListAsync());
        }

        // GET: Stavka/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stavka = await _context.Stavke
                .Include(s => s.Faktura)
                .SingleOrDefaultAsync(m => m.StavkaId == id);
            if (stavka == null)
            {
                return NotFound();
            }

            return View(stavka);
        }

        // GET: Stavka/Create
        public IActionResult Create()
        {
            ViewData["FakturaId"] = new SelectList(_context.Fakture, "FakturaId", "BrojFakture");
            return View();
        }

        // POST: Stavka/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StavkaId,FakturaId,RedniBroj,Kolicina,Cena,Ukupno")] Stavka stavka)
        {
            if (ModelState.IsValid)
            {
                _context.Add(stavka);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FakturaId"] = new SelectList(_context.Fakture, "FakturaId", "BrojFakture", stavka.FakturaId);
            return View(stavka);
        }

        // GET: Stavka/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stavka = await _context.Stavke.SingleOrDefaultAsync(m => m.StavkaId == id);
            if (stavka == null)
            {
                return NotFound();
            }
            ViewData["FakturaId"] = new SelectList(_context.Fakture, "FakturaId", "BrojFakture", stavka.FakturaId);
            return View(stavka);
        }

        // POST: Stavka/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StavkaId,FakturaId,RedniBroj,Kolicina,Cena,Ukupno")] Stavka stavka)
        {
            if (id != stavka.StavkaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(stavka);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StavkaExists(stavka.StavkaId))
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
            ViewData["FakturaId"] = new SelectList(_context.Fakture, "FakturaId", "BrojFakture", stavka.FakturaId);
            return View(stavka);
        }

        // GET: Stavka/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stavka = await _context.Stavke
                .Include(s => s.Faktura)
                .SingleOrDefaultAsync(m => m.StavkaId == id);
            if (stavka == null)
            {
                return NotFound();
            }

            return View(stavka);
        }

        // POST: Stavka/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var stavka = await _context.Stavke.SingleOrDefaultAsync(m => m.StavkaId == id);
            _context.Stavke.Remove(stavka);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StavkaExists(int id)
        {
            return _context.Stavke.Any(e => e.StavkaId == id);
        }
    }
}
