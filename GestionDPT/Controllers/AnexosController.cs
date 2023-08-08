using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GestionDPT.Models;

namespace GestionDPT.Controllers
{
    public class AnexosController : Controller
    {
        private readonly GestionProyectosDBContext _context;

        public AnexosController(GestionProyectosDBContext context)
        {
            _context = context;
        }

        // GET: Anexos
        public async Task<IActionResult> Index()
        {
            var gestionProyectosDBContext = _context.Anexos.Include(a => a.Tarea);
            return View(await gestionProyectosDBContext.ToListAsync());
        }

        // GET: Anexos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Anexos == null)
            {
                return NotFound();
            }

            var anexo = await _context.Anexos
                .Include(a => a.Tarea)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (anexo == null)
            {
                return NotFound();
            }

            return View(anexo);
        }

        // GET: Anexos/Create
        public IActionResult Create()
        {
            ViewData["TareaId"] = new SelectList(_context.Tareas, "Id", "Id");
            return View();
        }

        // POST: Anexos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TareaId,NombreArchivo,RutaArchivo")] Anexo anexo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(anexo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TareaId"] = new SelectList(_context.Tareas, "Id", "Id", anexo.TareaId);
            return View(anexo);
        }

        // GET: Anexos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Anexos == null)
            {
                return NotFound();
            }

            var anexo = await _context.Anexos.FindAsync(id);
            if (anexo == null)
            {
                return NotFound();
            }
            ViewData["TareaId"] = new SelectList(_context.Tareas, "Id", "Id", anexo.TareaId);
            return View(anexo);
        }

        // POST: Anexos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TareaId,NombreArchivo,RutaArchivo")] Anexo anexo)
        {
            if (id != anexo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(anexo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnexoExists(anexo.Id))
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
            ViewData["TareaId"] = new SelectList(_context.Tareas, "Id", "Id", anexo.TareaId);
            return View(anexo);
        }

        // GET: Anexos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Anexos == null)
            {
                return NotFound();
            }

            var anexo = await _context.Anexos
                .Include(a => a.Tarea)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (anexo == null)
            {
                return NotFound();
            }

            return View(anexo);
        }

        // POST: Anexos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Anexos == null)
            {
                return Problem("Entity set 'GestionProyectosDBContext.Anexos'  is null.");
            }
            var anexo = await _context.Anexos.FindAsync(id);
            if (anexo != null)
            {
                _context.Anexos.Remove(anexo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AnexoExists(int id)
        {
          return (_context.Anexos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
