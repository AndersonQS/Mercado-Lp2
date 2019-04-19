using System.Collections.Generic;

namespace MercadoLp2.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Usuario { get; set; }
        public string Senha { get; set; }

        public ICollection<Endereco> Enderecos { get; set; } = new List<Endereco>();

        public Cliente()
        {
        }

        public Cliente(int id, string nome, string email, string usuario, string senha)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Usuario = usuario;
            Senha = senha;
        }
       
    }
}
