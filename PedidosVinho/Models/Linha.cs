using System.Collections.Generic;

namespace PedidosVinho.Models
{
    public class Linha
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public ICollection<Produto> Produtos { get; set; } = new List<Produto>();
        public Linha()
        {
        }

        public Linha(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public void AddProduto(Produto produto)
        {
            Produtos.Add(produto);
        }
    }
}
