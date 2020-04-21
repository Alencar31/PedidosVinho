using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PedidosVinho.Models
{
    public class PedidosVinhoContext : DbContext
    {
        public PedidosVinhoContext (DbContextOptions<PedidosVinhoContext> options)
            : base(options)
        {
        }

        public DbSet<PedidosVinho.Models.Linha> Linha { get; set; }
    }
}
