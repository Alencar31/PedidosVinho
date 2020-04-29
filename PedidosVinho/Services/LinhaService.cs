using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PedidosVinho.Models;
using PedidosVinho.Services;

namespace PedidosVinho.Services
{
    public class LinhaService
    {
        private readonly PedidosVinhoContext _context;

        public LinhaService(PedidosVinhoContext context)
        {
            _context = context;
        }

        public async Task<List<Linha>> FindAllAsync()
        {
            return await _context.Linha.OrderBy(x => x.Nome).ToListAsync();
        }
    }
}
