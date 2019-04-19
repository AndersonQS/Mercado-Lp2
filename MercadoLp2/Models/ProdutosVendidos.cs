using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoLp2.Models
{
    public class ProdutosVendidos
    {
        public int Id { get; set; }
        public int Qtde { get; set; }
        public double Preco { get; set; }
        public Produto Prod { get; set; }

        public ProdutosVendidos()
        {
        }

        public ProdutosVendidos(int id, int qtde, double preco, Produto prod)
        {
            Id = id;
            Qtde = qtde;
            Preco = preco;
            Prod = prod;
        }

    }
        

}
