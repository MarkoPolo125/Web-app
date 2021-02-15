using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Projekt_01.Data;
using Projekt_01.Models;
using Microsoft.AspNetCore.Authorization;

namespace Projekt_01.Controllers
{
    [Authorize]
    public class VrsteController : Controller
    {
        private readonly TablicaContext _context;

        public VrsteController(TablicaContext context)
        {
            _context = context;
        }

        // GET: Vrste
        public async Task<IActionResult> Index(string search)
        {
            if (!String.IsNullOrEmpty(search))
            {
                var vrsta = from Vrsta in _context.Vrsta
                                select Vrsta;
                vrsta = vrsta.Where(Vrsta => Vrsta.TipVozila.Contains(search));
                return View(vrsta.ToList());
            }
            return View(await _context.Vrsta.ToListAsync());
        }

        // GET: Vrste/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vrsta = await _context.Vrsta
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vrsta == null)
            {
                return NotFound();
            }

            return View(vrsta);
        }

        // GET: Vrste/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Vrste/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Ime,TipVozila")] Vrsta vrsta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vrsta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vrsta);
        }

        // GET: Vrste/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vrsta = await _context.Vrsta.FindAsync(id);
            if (vrsta == null)
            {
                return NotFound();
            }
            return View(vrsta);
        }

        // POST: Vrste/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Ime,TipVozila")] Vrsta vrsta)
        {
            if (id != vrsta.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vrsta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VrstaExists(vrsta.Id))
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
            return View(vrsta);
        }

        // GET: Vrste/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vrsta = await _context.Vrsta
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vrsta == null)
            {
                return NotFound();
            }

            return View(vrsta);
        }

        // POST: Vrste/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vrsta = await _context.Vrsta.FindAsync(id);
            _context.Vrsta.Remove(vrsta);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VrstaExists(int id)
        {
            return _context.Vrsta.Any(e => e.Id == id);
        }
    }
}
