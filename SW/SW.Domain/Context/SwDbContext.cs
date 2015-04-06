using System.Data.Entity;
using SW.Domain.Vendas.Entidades;

namespace SW.Domain.Context
{
    public class SwDbContext : DbContext
    {
        public SwDbContext() : base("SwDb") { }

        public DbSet<Produto> Produto { get; set; }
        public DbSet<Promocao> Promocao { get; set; }
    }
}
