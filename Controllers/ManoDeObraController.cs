using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PROGRAM.Models;
using PROGRAM.Repos;

namespace PROGRAM.Controllers
{
    public class ManoDeObraController : Controller
    {
        private readonly PROGRAMContext _context;

        public ManoDeObraController(PROGRAMContext context)
        {
            _context = context;
        }

        // GET: ManoDeObra
        public async Task<IActionResult> Index()
        {
            var PROGRAMContext = _context.ManoDeObra.Include(m => m.Categoria);
            return View(await PROGRAMContext.ToListAsync());
        }

        // GET: ManoDeObra/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ManoDeObra == null)
            {
                return NotFound();
            }

            var manoDeObra = await _context.ManoDeObra
                .Include(m => m.Categoria)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (manoDeObra == null)
            {
                return NotFound();
            }

            return View(manoDeObra);
        }

        // GET: ManoDeObra/Create
        public IActionResult Create()
        {
            ViewData["CategoriaRefId"] = new SelectList(_context.Categoria, "Id", "Id");
            return View();
        }

        // POST: ManoDeObra/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Nombre,CategoriaRefId")] ManoDeObra manoDeObra)
        {
            if (ModelState.IsValid)
            {
                _context.Add(manoDeObra);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoriaRefId"] = new SelectList(_context.Categoria, "Id", "Id", manoDeObra.CategoriaRefId);
            return View(manoDeObra);
        }

        // GET: ManoDeObra/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ManoDeObra == null)
            {
                return NotFound();
            }

            var manoDeObra = await _context.ManoDeObra.FindAsync(id);
            if (manoDeObra == null)
            {
                return NotFound();
            }
            ViewData["CategoriaRefId"] = new SelectList(_context.Categoria, "Id", "Id", manoDeObra.CategoriaRefId);
            return View(manoDeObra);
        }

        // POST: ManoDeObra/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Nombre,CategoriaRefId")] ManoDeObra manoDeObra)
        {
            if (id != manoDeObra.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(manoDeObra);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ManoDeObraExists(manoDeObra.ID))
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
            ViewData["CategoriaRefId"] = new SelectList(_context.Categoria, "Id", "Id", manoDeObra.CategoriaRefId);
            return View(manoDeObra);
        }

        // GET: ManoDeObra/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ManoDeObra == null)
            {
                return NotFound();
            }

            var manoDeObra = await _context.ManoDeObra
                .Include(m => m.Categoria)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (manoDeObra == null)
            {
                return NotFound();
            }

            return View(manoDeObra);
        }

        // POST: ManoDeObra/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ManoDeObra == null)
            {
                return Problem("Entity set 'PROGRAMContext.ManoDeObra'  is null.");
            }
            var manoDeObra = await _context.ManoDeObra.FindAsync(id);
            if (manoDeObra != null)
            {
                _context.ManoDeObra.Remove(manoDeObra);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ManoDeObraExists(int id)
        {
          return (_context.ManoDeObra?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
