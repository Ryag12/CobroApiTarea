using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CobroApiP2.Models;

namespace CobroApiP2.Controllers
{
    public class CobrosController : Controller
    {
        private readonly CobroApiP2Context _context;

        public CobrosController(CobroApiP2Context context)
        {
            _context = context;    
        }

        // GET: Cobros
        public async Task<IActionResult> Index()
        {
            return View(await _context.Cobros.ToListAsync());
        }

        // GET: Cobros/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cobros = await _context.Cobros
                .SingleOrDefaultAsync(m => m.IdCobro == id);
            if (cobros == null)
            {
                return NotFound();
            }

            return View(cobros);
        }

        // GET: Cobros/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cobros/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCobro,Fecha,Referencia,IdRemoto,IdRuta,Mora,Monto,Latitud,Longitud,EsNulo")] Cobros cobros)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cobros);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(cobros);
        }

        // GET: Cobros/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cobros = await _context.Cobros.SingleOrDefaultAsync(m => m.IdCobro == id);
            if (cobros == null)
            {
                return NotFound();
            }
            return View(cobros);
        }

        // POST: Cobros/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCobro,Fecha,Referencia,IdRemoto,IdRuta,Mora,Monto,Latitud,Longitud,EsNulo")] Cobros cobros)
        {
            if (id != cobros.IdCobro)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cobros);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CobrosExists(cobros.IdCobro))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(cobros);
        }

        // GET: Cobros/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cobros = await _context.Cobros
                .SingleOrDefaultAsync(m => m.IdCobro == id);
            if (cobros == null)
            {
                return NotFound();
            }

            return View(cobros);
        }

        // POST: Cobros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cobros = await _context.Cobros.SingleOrDefaultAsync(m => m.IdCobro == id);
            _context.Cobros.Remove(cobros);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool CobrosExists(int id)
        {
            return _context.Cobros.Any(e => e.IdCobro == id);
        }
    }
}
