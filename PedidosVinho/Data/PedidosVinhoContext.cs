using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PedidosVinho.Models;

namespace PedidosVinho.Models
{
    public class PedidosVinhoContext : DbContext
    {
        public PedidosVinhoContext (DbContextOptions<PedidosVinhoContext> options)
            : base(options)
        {
        }

        public DbSet<Linha> Linha { get; set; }

        public DbSet<Produto> Produto { get; set; }
    }
}
