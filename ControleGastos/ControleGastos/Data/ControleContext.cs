using ControleGastos.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleGastos.Data
{
    public class ControleContext : DbContext
    {
        public ControleContext(DbContextOptions<ControleContext> options) : base(options)
        {
        }

        public DbSet<Pessoa> Pessoa { get; set; }
        public DbSet<Transacao> Transacao { get; set; }

    }
}
