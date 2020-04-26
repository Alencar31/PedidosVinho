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
    public class PedidoItemsController : Controller
    {
        private readonly PedidosVinhoContext _context;

        public PedidoItemsController(PedidosVinhoContext context)
        {
            _context = context;
        }

        // GET: PedidoItems
        public async Task<IActionResult> Index()
        {
            var pedidosVinhoContext = _context.PedidoItem.Include(p => p.Pedido);
            return View(await pedidosVinhoContext.ToListAsync());
        }

        // GET: PedidoItems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedidoItem = await _context.PedidoItem
                .Include(p => p.Pedido)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pedidoItem == null)
            {
                return NotFound();
            }

            return View(pedidoItem);
        }

        // GET: PedidoItems/Create
        public IActionResult Create()
        {
            ViewData["PedidoId"] = new SelectList(_context.Pedido, "Id", "Id");
            return View();
        }

        // POST: PedidoItems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ValorUnitario,Quantidade,ValorTotal,PedidoId")] PedidoItem pedidoItem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pedidoItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PedidoId"] = new SelectList(_context.Pedido, "Id", "Id", pedidoItem.PedidoId);
            return View(pedidoItem);
        }

        // GET: PedidoItems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedidoItem = await _context.PedidoItem.FindAsync(id);
            if (pedidoItem == null)
            {
                return NotFound();
            }
            ViewData["PedidoId"] = new SelectList(_context.Pedido, "Id", "Id", pedidoItem.PedidoId);
            return View(pedidoItem);
        }

        // POST: PedidoItems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ValorUnitario,Quantidade,ValorTotal,PedidoId")] PedidoItem pedidoItem)
        {
            if (id != pedidoItem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pedidoItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PedidoItemExists(pedidoItem.Id))
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
            ViewData["PedidoId"] = new SelectList(_context.Pedido, "Id", "Id", pedidoItem.PedidoId);
            return View(pedidoItem);
        }

        // GET: PedidoItems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedidoItem = await _context.PedidoItem
                .Include(p => p.Pedido)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pedidoItem == null)
            {
                return NotFound();
            }

            return View(pedidoItem);
        }

        // POST: PedidoItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pedidoItem = await _context.PedidoItem.FindAsync(id);
            _context.PedidoItem.Remove(pedidoItem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PedidoItemExists(int id)
        {
            return _context.PedidoItem.Any(e => e.Id == id);
        }
    }
}
