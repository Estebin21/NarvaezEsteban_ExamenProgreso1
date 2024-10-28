using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NarvaezEsteban_ExamenProgreso1.Models;

namespace NarvaezEsteban_ExamenProgreso1.Controllers
{
    public class NarvaezsController : Controller
    {
        private readonly UsuarioContext _context;

        public NarvaezsController(UsuarioContext context)
        {
            _context = context;
        }

        // GET: Narvaezs
        public async Task<IActionResult> Index()
        {
            var usuarioContext = _context.Narvaez.Include(n => n.Celular);
            return View(await usuarioContext.ToListAsync());
        }

        // GET: Narvaezs/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var narvaez = await _context.Narvaez
                .Include(n => n.Celular)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (narvaez == null)
            {
                return NotFound();
            }

            return View(narvaez);
        }

        // GET: Narvaezs/Create
        public IActionResult Create()
        {
            ViewData["IdCelular"] = new SelectList(_context.Celular, "IdCelular", "Modelo");
            return View();
        }

        // POST: Narvaezs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Edad,Altura,Nacionalidad,Fechanacimiento,IdCelular")] Narvaez narvaez)
        {
            if (ModelState.IsValid)
            {
                _context.Add(narvaez);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCelular"] = new SelectList(_context.Celular, "IdCelular", "Modelo", narvaez.IdCelular);
            return View(narvaez);
        }

        // GET: Narvaezs/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var narvaez = await _context.Narvaez.FindAsync(id);
            if (narvaez == null)
            {
                return NotFound();
            }
            ViewData["IdCelular"] = new SelectList(_context.Celular, "IdCelular", "Modelo", narvaez.IdCelular);
            return View(narvaez);
        }

        // POST: Narvaezs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Nombre,Edad,Altura,Nacionalidad,Fechanacimiento,IdCelular")] Narvaez narvaez)
        {
            if (id != narvaez.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(narvaez);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NarvaezExists(narvaez.Id))
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
            ViewData["IdCelular"] = new SelectList(_context.Celular, "IdCelular", "Modelo", narvaez.IdCelular);
            return View(narvaez);
        }

        // GET: Narvaezs/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var narvaez = await _context.Narvaez
                .Include(n => n.Celular)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (narvaez == null)
            {
                return NotFound();
            }

            return View(narvaez);
        }

        // POST: Narvaezs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var narvaez = await _context.Narvaez.FindAsync(id);
            if (narvaez != null)
            {
                _context.Narvaez.Remove(narvaez);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NarvaezExists(string id)
        {
            return _context.Narvaez.Any(e => e.Id == id);
        }
    }
}
