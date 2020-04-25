
namespace PedidosVinho.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public Linha Linha { get; set; }
        public int LinhaId { get; set; }


        public Produto()
        {
        }

        public Produto(int id, int codigo, string nome, decimal preco, Linha linha)
        {
            Id = id;
            Codigo = codigo;
            Nome = nome;
            Preco = preco;
            Linha = linha;
        }
    }
}
