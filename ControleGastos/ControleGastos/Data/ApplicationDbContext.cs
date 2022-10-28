using ControleGastos.Data.Map;
using ControleGastos.Models;
using Microsoft.EntityFrameworkCore;
namespace ControleGastos.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Transacao> Transacoes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pessoa>().ToTable("Pessoa");
            modelBuilder.Entity<Transacao>().ToTable("Transacao");

            modelBuilder.ApplyConfiguration(new TransacaoMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
