using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MercadoLp2.Models
{
    public class MercadoLp2Context : DbContext
    {
        public MercadoLp2Context (DbContextOptions<MercadoLp2Context> options)
            : base(options)
        {
        }

        public DbSet<MercadoLp2.Models.Produto> Produto { get; set; }
    }
}
