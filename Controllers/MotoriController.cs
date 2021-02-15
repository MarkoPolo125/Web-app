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
    public class MotoriController : Controller
    {
        private readonly TablicaContext _context;

        public MotoriController(TablicaContext context)
        {
            _context = context;
        }

        // GET: Motori
        public async Task<IActionResult> Index()
        {
            return View(await _context.Motori.ToListAsync());
        }

        // GET: Motori/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var motori = await _context.Motori
                .FirstOrDefaultAsync(m => m.Id == id);
            if (motori == null)
            {
                return NotFound();
            }

            return View(motori);
        }

        // GET: Motori/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Motori/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Godina,Boja,Cijena")] Motori motori)
        {
            if (ModelState.IsValid)
            {
                _context.Add(motori);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(motori);
        }

        // GET: Motori/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var motori = await _context.Motori.FindAsync(id);
            if (motori == null)
            {
                return NotFound();
            }
            return View(motori);
        }

        // POST: Motori/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Godina,Boja,Cijena")] Motori motori)
        {
            if (id != motori.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(motori);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MotoriExists(motori.Id))
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
            return View(motori);
        }

        // GET: Motori/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var motori = await _context.Motori
                .FirstOrDefaultAsync(m => m.Id == id);
            if (motori == null)
            {
                return NotFound();
            }

            return View(motori);
        }

        // POST: Motori/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var motori = await _context.Motori.FindAsync(id);
            _context.Motori.Remove(motori);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MotoriExists(int id)
        {
            return _context.Motori.Any(e => e.Id == id);
        }
    }
}
