using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MercadoLp2.Models;

namespace MercadoLp2.Data
{
    public abstract class Carrinho
    {
        public static List<ProdutosVendidos> listaCarrinho = new List<ProdutosVendidos>();
        public static RegistroVendas Venda { get; set; }
    }
}
