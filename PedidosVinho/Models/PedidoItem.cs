using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PedidosVinho.Models
{
    public class PedidoItem
    {
        public int Id { get; set; }
        public decimal ValorUnitario { get; set; }
        public int Quantidade { get; set; }
        public decimal ValorTotal { get; set; }
        public Pedido Pedido { get; set; }
        public int PedidoId { get; set; }
        public ICollection<Produto> Produtos { get; set; } = new List<Produto>();
    }
}
