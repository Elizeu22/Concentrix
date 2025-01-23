using Concentrix.Models;
using Microsoft.EntityFrameworkCore;





namespace Concentrix.DB
{
    public class PedidosDbContext: DbContext
    {

        public PedidosDbContext(DbContextOptions<PedidosDbContext> options) : base(options) { }

        public DbSet<Pedidos> gerarPedidos { get; set; }
        
        public DbSet<Itens> gerarItens { get;set; }

    }
}
