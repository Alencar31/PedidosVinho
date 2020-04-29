using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PedidosVinho.Models;
using PedidosVinho.Models.ViewModels;
using PedidosVinho.Services;
using PedidosVinho.Services.Exceções;

namespace PedidosVinho.Controllers
{
    public class ProdutosController : Controller
    {
        private readonly PedidosVinhoContext _context;
        private readonly LinhaService _linhaservice;
        private readonly ProdutoService _produtoservice;

        public ProdutosController(PedidosVinhoContext context,LinhaService linhaService,ProdutoService produtoService)
        {
            _context = context;
            _linhaservice = linhaService;
            _produtoservice = produtoService;
        }

        // GET: Produtos
        public async Task<IActionResult> Index()
        {
            var list = _produtoservice.FindAllAsync();
            return View(await list);
            //return View(await _context.Produto.ToListAsync());
        }

        // GET: Produtos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var obj = await _produtoservice.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        // GET: Produtos/Create
        public async Task<IActionResult> Create()
        {
            var linhas = await _linhaservice.FindAllAsync();
            var viewModel = new ProdutoFormViewModel { Linhas = linhas };
            return View(viewModel);
        }

        // POST: Produtos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Produto produto)
        {
            if (ModelState.IsValid)
            {
                var linhas = await _linhaservice.FindAllAsync();
                var viewModel = new ProdutoFormViewModel { Produto = produto, Linhas = linhas };
                return View(viewModel);
            }
            await _produtoservice.insertAsync(produto);
            return RedirectToAction(nameof(Index));
        }

        // GET: Produtos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await _produtoservice.FindByIdAsync(id.Value);
            if (produto == null)
            {
                return NotFound();
            }
            List<Linha> linhas = await _linhaservice.FindAllAsync();
            ProdutoFormViewModel viewModel = new ProdutoFormViewModel { Produto = produto, Linhas = linhas };
            return View(viewModel);
        }

        // POST: Produtos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,LinhaId,Codigo,Nome,Preco")] Produto produto)
        {
            if (id != produto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(produto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProdutoExists(produto.Id))
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
            return View(produto);
        }

        // GET: Produtos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var obj = await _produtoservice.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        // POST: Produtos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var produto = await _context.Produto.FindAsync(id);
            _context.Produto.Remove(produto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProdutoExists(int id)
        {
            return _context.Produto.Any(e => e.Id == id);
        }

    }
}
