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
    
    public class FakturaController : Controller
    {
        private readonly FakturisanjeContext _context;

        public FakturaController(FakturisanjeContext context)
        {
            _context = context;
        }

        // GET: Faktura
        public async Task<IActionResult> Index()
        {
            var fakturisanjeContext = _context.Fakture.Include(f => f.Kupac);
            return View(await fakturisanjeContext.ToListAsync());
        }

        // GET: Faktura/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var faktura = await _context.Fakture
                .Include(f => f.Kupac)
                .SingleOrDefaultAsync(m => m.FakturaId == id);
            if (faktura == null)
            {
                return NotFound();
            }

            return View(faktura);
        }

        // GET: Faktura/Create
        public IActionResult Create()
        {
            ViewData["KupacId"] = new SelectList(_context.Kupci, "KupacId", "KupacId");
            return View();
        }

        // POST: Faktura/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FakturaId,KupacId,DatumFakture,BrojFakture,UkupnoFaktura")] Faktura faktura)
        {
            if (ModelState.IsValid)
            {
                _context.Add(faktura);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["KupacId"] = new SelectList(_context.Kupci, "KupacId", "KupacId", faktura.KupacId);
            return View(faktura);
        }

        // GET: Faktura/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var faktura = await _context.Fakture.SingleOrDefaultAsync(m => m.FakturaId == id);
            if (faktura == null)
            {
                return NotFound();
            }
            ViewData["KupacId"] = new SelectList(_context.Kupci, "KupacId", "KupacId", faktura.KupacId);
            return View(faktura);
        }

        // POST: Faktura/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FakturaId,KupacId,DatumFakture,BrojFakture,UkupnoFaktura")] Faktura faktura)
        {
            if (id != faktura.FakturaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(faktura);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FakturaExists(faktura.FakturaId))
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
            ViewData["KupacId"] = new SelectList(_context.Kupci, "KupacId", "KupacId", faktura.KupacId);
            return View(faktura);
        }

        // GET: Faktura/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var faktura = await _context.Fakture
                .Include(f => f.Kupac)
                .SingleOrDefaultAsync(m => m.FakturaId == id);
            if (faktura == null)
            {
                return NotFound();
            }

            return View(faktura);
        }

        // POST: Faktura/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var faktura = await _context.Fakture.SingleOrDefaultAsync(m => m.FakturaId == id);
            _context.Fakture.Remove(faktura);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FakturaExists(int id)
        {
            return _context.Fakture.Any(e => e.FakturaId == id);
        }
    }
}
