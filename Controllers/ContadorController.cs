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
    public class ContadorController : Controller
    {
        private readonly PROGRAMContext _context;

        public ContadorController(PROGRAMContext context)
        {
            _context = context;
        }

        // GET: Contador
        public async Task<IActionResult> Index()
        {
            var PROGRAMContext = _context.Contador.Include(c => c.Equipo);
            return View(await PROGRAMContext.ToListAsync());
        }

        // GET: Contador/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Contador == null)
            {
                return NotFound();
            }

            var contador = await _context.Contador
                .Include(c => c.Equipo)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (contador == null)
            {
                return NotFound();
            }

            return View(contador);
        }

        // GET: Contador/Create
        public IActionResult Create()
        {
            ViewData["EquipoRefId"] = new SelectList(_context.Equipo, "ID", "ID");
            return View();
        }

        // POST: Contador/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,EquipoRefId,Tipo,Valor")] Contador contador)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contador);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EquipoRefId"] = new SelectList(_context.Equipo, "ID", "ID", contador.EquipoRefId);
            return View(contador);
        }

        // GET: Contador/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Contador == null)
            {
                return NotFound();
            }

            var contador = await _context.Contador.FindAsync(id);
            if (contador == null)
            {
                return NotFound();
            }
            ViewData["EquipoRefId"] = new SelectList(_context.Equipo, "ID", "ID", contador.EquipoRefId);
            return View(contador);
        }

        // POST: Contador/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,EquipoRefId,Tipo,Valor")] Contador contador)
        {
            if (id != contador.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contador);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContadorExists(contador.ID))
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
            ViewData["EquipoRefId"] = new SelectList(_context.Equipo, "ID", "ID", contador.EquipoRefId);
            return View(contador);
        }

        // GET: Contador/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Contador == null)
            {
                return NotFound();
            }

            var contador = await _context.Contador
                .Include(c => c.Equipo)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (contador == null)
            {
                return NotFound();
            }

            return View(contador);
        }

        // POST: Contador/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Contador == null)
            {
                return Problem("Entity set 'PROGRAMContext.Contador'  is null.");
            }
            var contador = await _context.Contador.FindAsync(id);
            if (contador != null)
            {
                _context.Contador.Remove(contador);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContadorExists(int id)
        {
          return (_context.Contador?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
