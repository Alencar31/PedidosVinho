using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PedidosVinho.Models;

namespace PedidosVinho.Controllers
{
    public class LinhasController : Controller
    {
        private readonly PedidosVinhoContext _context;

        public LinhasController(PedidosVinhoContext context)
        {
            _context = context;
        }

        // GET: Linhas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Linha.ToListAsync());
        }

        // GET: Linhas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var linha = await _context.Linha
                .FirstOrDefaultAsync(m => m.Id == id);
            if (linha == null)
            {
                return NotFound();
            }

            return View(linha);
        }

        // GET: Linhas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Linhas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Codigo,Nome")] Linha linha)
        {
            if (ModelState.IsValid)
            {
                _context.Add(linha);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(linha);
        }

        // GET: Linhas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var linha = await _context.Linha.FindAsync(id);
            if (linha == null)
            {
                return NotFound();
            }
            return View(linha);
        }

        // POST: Linhas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Codigo,Nome")] Linha linha)
        {
            if (id != linha.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(linha);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LinhaExists(linha.Id))
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
            return View(linha);
        }

        // GET: Linhas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var linha = await _context.Linha
                .FirstOrDefaultAsync(m => m.Id == id);
            if (linha == null)
            {
                return NotFound();
            }

            return View(linha);
        }

        // POST: Linhas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var linha = await _context.Linha.FindAsync(id);
            _context.Linha.Remove(linha);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LinhaExists(int id)
        {
            return _context.Linha.Any(e => e.Id == id);
        }
    }
}
