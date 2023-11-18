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
    public class ProcedimientoController : Controller
    {
        private readonly PROGRAMContext _context;

        public ProcedimientoController(PROGRAMContext context)
        {
            _context = context;
        }

        // GET: Procedimiento
        public async Task<IActionResult> Index()
        {
              return _context.Procedimiento != null ? 
                          View(await _context.Procedimiento.ToListAsync()) :
                          Problem("Entity set 'PROGRAMContext.Procedimiento'  is null.");
        }

        // GET: Procedimiento/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Procedimiento == null)
            {
                return NotFound();
            }

            var procedimiento = await _context.Procedimiento
                .FirstOrDefaultAsync(m => m.ID == id);
            if (procedimiento == null)
            {
                return NotFound();
            }

            return View(procedimiento);
        }

        // GET: Procedimiento/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Procedimiento/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Nombre")] Procedimiento procedimiento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(procedimiento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(procedimiento);
        }

        // GET: Procedimiento/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Procedimiento == null)
            {
                return NotFound();
            }

            var procedimiento = await _context.Procedimiento.FindAsync(id);
            if (procedimiento == null)
            {
                return NotFound();
            }
            return View(procedimiento);
        }

        // POST: Procedimiento/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Nombre")] Procedimiento procedimiento)
        {
            if (id != procedimiento.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(procedimiento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProcedimientoExists(procedimiento.ID))
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
            return View(procedimiento);
        }

        // GET: Procedimiento/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Procedimiento == null)
            {
                return NotFound();
            }

            var procedimiento = await _context.Procedimiento
                .FirstOrDefaultAsync(m => m.ID == id);
            if (procedimiento == null)
            {
                return NotFound();
            }

            return View(procedimiento);
        }

        // POST: Procedimiento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Procedimiento == null)
            {
                return Problem("Entity set 'PROGRAMContext.Procedimiento'  is null.");
            }
            var procedimiento = await _context.Procedimiento.FindAsync(id);
            if (procedimiento != null)
            {
                _context.Procedimiento.Remove(procedimiento);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProcedimientoExists(int id)
        {
          return (_context.Procedimiento?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
