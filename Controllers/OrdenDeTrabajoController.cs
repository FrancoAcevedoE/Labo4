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
    public class OrdenDeTrabajoController : Controller
    {
        private readonly PROGRAMContext _context;

        public OrdenDeTrabajoController(PROGRAMContext context)
        {
            _context = context;
        }

        // GET: OrdenDeTrabajo
        public async Task<IActionResult> Index()
        {
            var PROGRAMContext = _context.OrdenDeTrabajo.Include(o => o.Equipo).Include(o => o.ManoDeObra).Include(o => o.Material).Include(o => o.Procedimiento);
            return View(await PROGRAMContext.ToListAsync());
        }

        // GET: OrdenDeTrabajo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.OrdenDeTrabajo == null)
            {
                return NotFound();
            }

            var ordenDeTrabajo = await _context.OrdenDeTrabajo
                .Include(o => o.Equipo)
                .Include(o => o.ManoDeObra)
                .Include(o => o.Material)
                .Include(o => o.Procedimiento)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (ordenDeTrabajo == null)
            {
                return NotFound();
            }

            return View(ordenDeTrabajo);
        }

        // GET: OrdenDeTrabajo/Create
        public IActionResult Create()
        {
            ViewData["EquipoRefId"] = new SelectList(_context.Equipo, "ID", "ID");
            ViewData["ManoDeObraRefId"] = new SelectList(_context.ManoDeObra, "ID", "ID");
            ViewData["MaterialesRefId"] = new SelectList(_context.Material, "ID", "ID");
            ViewData["ProcedimientoRefId"] = new SelectList(_context.Procedimiento, "ID", "ID");
            return View();
        }

        // POST: OrdenDeTrabajo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,TipoOT,ManoDeObraRefId,EquipoRefId,ProcedimientoRefId,MaterialesRefId")] OrdenDeTrabajo ordenDeTrabajo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ordenDeTrabajo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EquipoRefId"] = new SelectList(_context.Equipo, "ID", "ID", ordenDeTrabajo.EquipoRefId);
            ViewData["ManoDeObraRefId"] = new SelectList(_context.ManoDeObra, "ID", "ID", ordenDeTrabajo.ManoDeObraRefId);
            ViewData["MaterialesRefId"] = new SelectList(_context.Material, "ID", "ID", ordenDeTrabajo.MaterialesRefId);
            ViewData["ProcedimientoRefId"] = new SelectList(_context.Procedimiento, "ID", "ID", ordenDeTrabajo.ProcedimientoRefId);
            return View(ordenDeTrabajo);
        }

        // GET: OrdenDeTrabajo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.OrdenDeTrabajo == null)
            {
                return NotFound();
            }

            var ordenDeTrabajo = await _context.OrdenDeTrabajo.FindAsync(id);
            if (ordenDeTrabajo == null)
            {
                return NotFound();
            }
            ViewData["EquipoRefId"] = new SelectList(_context.Equipo, "ID", "ID", ordenDeTrabajo.EquipoRefId);
            ViewData["ManoDeObraRefId"] = new SelectList(_context.ManoDeObra, "ID", "ID", ordenDeTrabajo.ManoDeObraRefId);
            ViewData["MaterialesRefId"] = new SelectList(_context.Material, "ID", "ID", ordenDeTrabajo.MaterialesRefId);
            ViewData["ProcedimientoRefId"] = new SelectList(_context.Procedimiento, "ID", "ID", ordenDeTrabajo.ProcedimientoRefId);
            return View(ordenDeTrabajo);
        }

        // POST: OrdenDeTrabajo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,TipoOT,ManoDeObraRefId,EquipoRefId,ProcedimientoRefId,MaterialesRefId")] OrdenDeTrabajo ordenDeTrabajo)
        {
            if (id != ordenDeTrabajo.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ordenDeTrabajo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrdenDeTrabajoExists(ordenDeTrabajo.ID))
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
            ViewData["EquipoRefId"] = new SelectList(_context.Equipo, "ID", "ID", ordenDeTrabajo.EquipoRefId);
            ViewData["ManoDeObraRefId"] = new SelectList(_context.ManoDeObra, "ID", "ID", ordenDeTrabajo.ManoDeObraRefId);
            ViewData["MaterialesRefId"] = new SelectList(_context.Material, "ID", "ID", ordenDeTrabajo.MaterialesRefId);
            ViewData["ProcedimientoRefId"] = new SelectList(_context.Procedimiento, "ID", "ID", ordenDeTrabajo.ProcedimientoRefId);
            return View(ordenDeTrabajo);
        }

        // GET: OrdenDeTrabajo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.OrdenDeTrabajo == null)
            {
                return NotFound();
            }

            var ordenDeTrabajo = await _context.OrdenDeTrabajo
                .Include(o => o.Equipo)
                .Include(o => o.ManoDeObra)
                .Include(o => o.Material)
                .Include(o => o.Procedimiento)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (ordenDeTrabajo == null)
            {
                return NotFound();
            }

            return View(ordenDeTrabajo);
        }

        // POST: OrdenDeTrabajo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.OrdenDeTrabajo == null)
            {
                return Problem("Entity set 'PROGRAMContext.OrdenDeTrabajo'  is null.");
            }
            var ordenDeTrabajo = await _context.OrdenDeTrabajo.FindAsync(id);
            if (ordenDeTrabajo != null)
            {
                _context.OrdenDeTrabajo.Remove(ordenDeTrabajo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrdenDeTrabajoExists(int id)
        {
          return (_context.OrdenDeTrabajo?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
