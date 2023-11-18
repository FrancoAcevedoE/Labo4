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
    public class EquipoController : Controller
    {
        private readonly PROGRAMContext _context;

        public EquipoController(PROGRAMContext context)
        {
            _context = context;
        }

        // GET: Equipo
        public async Task<IActionResult> Index()
        {
            var PROGRAMContext = _context.Equipo.Include(e => e.Contador).Include(e => e.Procedimiento);
            return View(await PROGRAMContext.ToListAsync());
        }

        // GET: Equipo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Equipo == null)
            {
                return NotFound();
            }

            var equipo = await _context.Equipo
                .Include(e => e.Contador)
                .Include(e => e.Procedimiento)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (equipo == null)
            {
                return NotFound();
            }

            return View(equipo);
        }

        // GET: Equipo/Create
        public IActionResult Create()
        {
            ViewData["ContadorRefId"] = new SelectList(_context.Contador, "ID", "ID");
            ViewData["ProcedimientoRefId"] = new SelectList(_context.Procedimiento, "ID", "ID");
            return View();
        }

        // POST: Equipo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Nombre,ContadorRefId,ProcedimientoRefId")] Equipo equipo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(equipo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ContadorRefId"] = new SelectList(_context.Contador, "ID", "ID", equipo.ContadorRefId);
            ViewData["ProcedimientoRefId"] = new SelectList(_context.Procedimiento, "ID", "ID", equipo.ProcedimientoRefId);
            return View(equipo);
        }

        // GET: Equipo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Equipo == null)
            {
                return NotFound();
            }

            var equipo = await _context.Equipo.FindAsync(id);
            if (equipo == null)
            {
                return NotFound();
            }
            ViewData["ContadorRefId"] = new SelectList(_context.Contador, "ID", "ID", equipo.ContadorRefId);
            ViewData["ProcedimientoRefId"] = new SelectList(_context.Procedimiento, "ID", "ID", equipo.ProcedimientoRefId);
            return View(equipo);
        }

        // POST: Equipo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Nombre,ContadorRefId,ProcedimientoRefId")] Equipo equipo)
        {
            if (id != equipo.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(equipo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EquipoExists(equipo.ID))
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
            ViewData["ContadorRefId"] = new SelectList(_context.Contador, "ID", "ID", equipo.ContadorRefId);
            ViewData["ProcedimientoRefId"] = new SelectList(_context.Procedimiento, "ID", "ID", equipo.ProcedimientoRefId);
            return View(equipo);
        }

        // GET: Equipo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Equipo == null)
            {
                return NotFound();
            }

            var equipo = await _context.Equipo
                .Include(e => e.Contador)
                .Include(e => e.Procedimiento)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (equipo == null)
            {
                return NotFound();
            }

            return View(equipo);
        }

        // POST: Equipo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Equipo == null)
            {
                return Problem("Entity set 'PROGRAMContext.Equipo'  is null.");
            }
            var equipo = await _context.Equipo.FindAsync(id);
            if (equipo != null)
            {
                _context.Equipo.Remove(equipo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EquipoExists(int id)
        {
          return (_context.Equipo?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
