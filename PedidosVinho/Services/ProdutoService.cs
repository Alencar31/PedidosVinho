using Microsoft.EntityFrameworkCore;
using PedidosVinho.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PedidosVinho.Services;
using PedidosVinho.Services.Exceções;

namespace PedidosVinho.Services
{
    public class ProdutoService
    {
        private readonly PedidosVinhoContext _context;

        public ProdutoService(PedidosVinhoContext context)
        {
            _context = context;
        }

        public async Task<List<Produto>> FindAllAsync()
        {
            return await _context.Produto.OrderBy(x => x.Nome).ToListAsync();
        }

        public async Task insertAsync(Produto obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }

        public async Task<Produto> FindByIdAsync(int id)
        {
            return await _context.Produto.Include(obj => obj.Linha).FirstOrDefaultAsync(obj => obj.Id == id);            
        }

        public void Remove(int id)
        {
            try
            {
                var obj = _context.Produto.Find(id);
                _context.Produto.Remove(obj);
                _context.SaveChanges();
            }
            catch (DbUpdateException e)
            {
                throw new IntegretyException("Não é possivel deletar o Produto pois possue pedidos.");
            }
        }

        public void DbUpdate(Produto obj)
        {
            bool hasAny = _context.Produto.Any(x => x.Id == obj.Id);
            if (!hasAny)
            {
                throw new NotFoundException("Produto não encontrado.");
            }
            try
            {
                _context.Update(obj);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }
    }
}
