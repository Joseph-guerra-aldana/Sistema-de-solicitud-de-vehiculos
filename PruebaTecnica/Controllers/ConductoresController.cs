using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PruebaTecnica.Models;

namespace PruebaTecnica.Controllers
{
    public class ConductoresController : Controller
    {
        private readonly ExamenAnalistaProgramdorContext _context;

        public ConductoresController(ExamenAnalistaProgramdorContext context)
        {
            _context = context;
        }

        // GET: Conductores
        public async Task<IActionResult> Index()
        {
            var examenAnalistaProgramdorContext = _context.Conductores.Include(c => c.IdVehiculoNavigation);
            return View(await examenAnalistaProgramdorContext.ToListAsync());
        }

        // GET: Conductores/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.Conductores == null)
            {
                return NotFound();
            }

            var conductore = await _context.Conductores
                .Include(c => c.IdVehiculoNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (conductore == null)
            {
                return NotFound();
            }

            return View(conductore);
        }

        // GET: Conductores/Create
        public IActionResult Create()
        {
            ViewData["IdVehiculo"] = new SelectList(_context.Vehiculos, "Id", "Id");
            return View();
        }

        // POST: Conductores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Dpi,LicenciaVigente,NoLicencia,Disponibilidad,TiempoRequerido,TiempoAyudantes,ViaticosEquipo,GastosRequeridos,IdVehiculo")] Conductore conductore)
        {
            if (ModelState.IsValid)
            {
                _context.Add(conductore);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdVehiculo"] = new SelectList(_context.Vehiculos, "Id", "Id", conductore.IdVehiculo);
            return View(conductore);
        }

        // GET: Conductores/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.Conductores == null)
            {
                return NotFound();
            }

            var conductore = await _context.Conductores.FindAsync(id);
            if (conductore == null)
            {
                return NotFound();
            }
            ViewData["IdVehiculo"] = new SelectList(_context.Vehiculos, "Id", "Id", conductore.IdVehiculo);
            return View(conductore);
        }

        // POST: Conductores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Nombre,Dpi,LicenciaVigente,NoLicencia,Disponibilidad,TiempoRequerido,TiempoAyudantes,ViaticosEquipo,GastosRequeridos,IdVehiculo")] Conductore conductore)
        {
            if (id != conductore.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(conductore);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConductoreExists(conductore.Id))
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
            ViewData["IdVehiculo"] = new SelectList(_context.Vehiculos, "Id", "Id", conductore.IdVehiculo);
            return View(conductore);
        }

        // GET: Conductores/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.Conductores == null)
            {
                return NotFound();
            }

            var conductore = await _context.Conductores
                .Include(c => c.IdVehiculoNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (conductore == null)
            {
                return NotFound();
            }

            return View(conductore);
        }

        // POST: Conductores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.Conductores == null)
            {
                return Problem("Entity set 'ExamenAnalistaProgramdorContext.Conductores'  is null.");
            }
            var conductore = await _context.Conductores.FindAsync(id);
            if (conductore != null)
            {
                _context.Conductores.Remove(conductore);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConductoreExists(long id)
        {
          return (_context.Conductores?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
