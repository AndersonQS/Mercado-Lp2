using System.Collections.Generic;

namespace MercadoLp2.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public double Preco { get; set; }
        public int Qtde { get; set; }

        public ICollection<Vendedor> Vendedors { get; set; } = new List<Vendedor>();

        public Produto()
        {

        }

        public Produto(int id, string nome, double preco, int qtde)
        {
            Id = id;
            Nome = nome;
            Preco = preco;
            Qtde = qtde;
        }

    }
}
