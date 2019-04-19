using System;
using System.Collections.Generic;

namespace MercadoLp2.Models
{
    public class RegistroVendas
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public int Valor { get; set; }
        public String Status { get; set; }

        public ICollection<ProdutosVendidos> Vendidos { get; set; } = new List<ProdutosVendidos>();

        public RegistroVendas()
        {
        }

        public RegistroVendas(int id, DateTime data, int valor, String status)
        {
            Id = id;
            Data = data;
            Valor = valor;
            Status = status;
        }
    }
}
